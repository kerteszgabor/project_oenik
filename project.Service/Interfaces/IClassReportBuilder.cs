using project.Domain.DTO.ClassReport;
using project.Service.Helpers.ClassReportBuilder;
using System;

namespace project.Service.Interfaces
{
    public interface IClassReportBuilder
    {
        string CodeAsString { get; set; }

        ICanCallBuild GetReportOf(string codeToAnalyze);
        ICanCompile AlsoCompile();
        ClassReport Build();
        ICanCompile SetExpectedStringOutput(string expectedStringOutput);
        ICanCompile SetExpectedValue(object expectedOutput);
        ICanRequireCompilation WithMethod(string methodName);
        ICanRequireCompilation WithMethod(string methodName, ParamList expectedParameters);
        ICanRequireCompilation WithMethod(string methodName, ParamList expectedParameters, string expectedReturnType);
        ICanRequireCompilation WithMethod(string methodName, string expectedReturnType);
        ICanCompile WithParameters(object[] parameters);
    }
}