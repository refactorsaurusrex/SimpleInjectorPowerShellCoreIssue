# What is this?
I'm trying to create a PowerShell Core binary cmdlet library that uses SimpleInjector, but am encountering a problem where the SimpleInjector dll cannot be found. This repo demonstrates the problem.

# How to reproduce the problem
1. Clone this repo and open the solution in Visual Studio.
1. Run the solution. (Both projects should be set as 'StartUp Projects', so two PowerShell windows should open.)
1. In each window, run `Test-JsonDotNetDependency` then `Test-SimpleInjectorDependency`. Both succeed using PowerShell 5, but the latter fails with PowerShell Core, resulting in a `FileNotFoundException` as shown below.

```
[Cmdlet(VerbsDiagnostic.Test, "SimpleInjectorDependency")]
public class TestSimpleInjectorDependencyCmdlet : PSCmdlet
{
    protected override void ProcessRecord()
    {
        var container = new Container();
        WriteObject("Success!");
    }
}

[Cmdlet(VerbsDiagnostic.Test, "JsonDotNetDependency")]
public class TestJsonDotNetDependencyCmdlet : PSCmdlet
{
    protected override void ProcessRecord()
    {
        var j = new JObject();
        WriteObject("Success!");
    }
}
```

![error](https://raw.githubusercontent.com/refactorsaurusrex/SimpleInjectorPowerShellCoreIssue/master/images/PSCoreError.png)

## Notes

- There are two projects in the solution, both of which should be set as 'startup projects'.
    1. `MyNetFrameworkProject` targets .NET 4.6.1, uses the `Microsoft.PowerShell.5.ReferenceAssemblies` package, and runs `powershell.exe`.
    1. `MyNetStandardProject` targets .NET Standard 2.0, uses the `PowerShellStandard.Library` package (v5.1.0-RC1), and runs `pwsh.exe`.
- I included the json.net test only to demonstrate that packages other than SimpleInjector seem to work as expected. 

# The Question
I can "make" the `MyNetStandardProject` work correctly if I manually copy the SimpleInjector.dll into the `bin\Debug\netstandard2.0`... but that really shouldn't be necessary. I really want to understand what I'm doing wrong that's causing the `FileNotFoundException`.

Thanks in advance to any/all help!
