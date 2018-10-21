# What is this?
I'm trying to create a PowerShell binary cmdlet library that uses SimpleInjector, but am encountering a problem where the SimpleInjector dll cannot be found. This repo demonstrates the problem.

# How to reproduce the problem
1. Clone this repo and open the solution in Visual Studio.
1. Run the solution.
1. In each window, run `Test-JsonDotNetDependency` then `Test-SimpleInjectorDependency`. Both succeed using PowerShell 5, but the latter fails with PowerShell Core and results in a `FileNotFoundException` as shown below.

![error]()

## Notes

There are two projects in the solution, both of which should be set as 'startup projects'. The first, `MyNetFrameworkProject`, targets .NET 4.6.1, uses the `Microsoft.PowerShell.5.ReferenceAssemblies` package, and runs `powershell.exe`. The