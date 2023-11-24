# Learn Csharp in 2024

I am learning C# from different Video Courses, Books, and Websites

## Chapter 01

```bash
dotnet new sln -n Ch01

dotnet new console -o HelloCS
dotnet sln add HelloCS/HelloCS.csproj
dotnet run --project .\HelloCS\HelloCS.csproj

dotnet new console -o HelloEnvironment
dotnet sln add HelloEnvironment/HelloEnvironment.csproj
dotnet run --project .\HelloEnvironment\HelloEnvironment.csproj
```

## Few Important Points

> 1. When using Visual Studio Code / dotnet CLI, to run a console app,
>    - it executes the app from the <projectname> folder.
>    - When using Visual Studio 2022 for Windows, it executes the app from the <projectname>\bin\Debug\net8.0 folder.
> 1. Good Practice: Although the source code, like the .csproj and .cs files, is identical, the bin and obj folders that are automatically generated by the compiler could have mismatches that give you errors.
> 1. If you want to open the same project in both Visual Studio 2022 and Visual Studio Code, delete the temporary bin and obj folders before opening the project in the other code editor.
> 1. `dotnet help build` will open the documentation for the build command.
> 1. `dotnet build --help` OR `dotnet build -h` OR `dotnet build -?` will open the documentation for the dotnet command.
