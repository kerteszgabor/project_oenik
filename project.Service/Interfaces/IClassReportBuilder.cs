using project.Domain.DTO.ClassReport;
using project.Domain.Helpers.ClassReportBuilder;
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
        ICanRequireCompilation WithMethod(MethodInfoData method);
        ICanCompile WithParameters(object[] parameters);
    }
}