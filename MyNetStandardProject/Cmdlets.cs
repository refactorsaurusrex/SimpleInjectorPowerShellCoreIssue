using System.Management.Automation;
using Newtonsoft.Json.Linq;
using SimpleInjector;

namespace MyNetStandardProject
{
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
}
