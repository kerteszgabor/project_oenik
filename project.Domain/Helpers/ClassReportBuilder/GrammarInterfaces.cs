using project.Domain.DTO.ClassReport;
using System;
using System.Collections.Generic;
using System.Text;

namespace project.Domain.Helpers.ClassReportBuilder
{
    public interface ICanCallBuild
    {
        ClassReport Build();
        ICanRequireCompilation WithMethod(MethodInfoData method);
    }
    public interface ICanRequireCompilation : ICanCallBuild
    {
        ICanCompile AlsoCompile();
    }
    public interface ICanCompile : ICanCallBuild
    {
        ICanCompile WithParameters(object[] parameters);
        ICanCompile SetExpectedStringOutput(string expectedStringOutput);
        ICanCompile SetExpectedValue(object expectedOutput);
    }
}
