﻿using Ch01.Interfaces;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace Ch01.Utilities;

public class RunnableManager(ILogger<RunnableManager> logger) : IRunnableManager
{
    private readonly ILogger<RunnableManager> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    public IEnumerable<IRunnable?> GetRunnableInstances(string namespacePrefix)
    {
        Type runnableInterfaceType = typeof(IRunnable);
        Assembly assembly = Assembly.GetExecutingAssembly();

        if (runnableInterfaceType == null || assembly == null)
        {
            _logger.LogError("Unable to retrieve types due to null reflection objects.");
            return Enumerable.Empty<IRunnable?>();
        }

        List<IRunnable?> runnableInstances = assembly.GetTypes()
            .Where(type => type.IsClass && type.Namespace == namespacePrefix && runnableInterfaceType.IsAssignableFrom(type))
            .Select(type => (IRunnable?)Activator.CreateInstance(type))
            .ToList();

        if (!runnableInstances.Any())
        {
            _logger.LogWarning($"No runnables found in namespace '{namespacePrefix}'.");
        }

        return runnableInstances;
    }

    public void RunRunnable(IRunnable runnable)
    {
        try
        {
            runnable.Run();
        }
        catch (Exception ex)
        {
            _logger.LogError($"An error occurred while running {runnable.GetType().Name}: {ex.Message}");
        }
    }
}
