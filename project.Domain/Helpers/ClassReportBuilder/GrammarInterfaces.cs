using project.Domain.DTO.ClassReport;
using System;
using System.Collections.Generic;
using System.Text;

namespace project.Domain.Helpers.ClassReportBuilder
{
    public interface ICanCallBuild
    {
        ClassReport Build();
        ICanRequireCompilation WithMethod(string methodName);
        ICanRequireCompilation WithMethod(string methodName, string expectedReturnType);
        ICanRequireCompilation WithMethod(string methodName, ParamList expectedParameters);
        ICanRequireCompilation WithMethod(string methodName, ParamList expectedParameters, string expectedReturnType);
    }
    public interface ICanRequireCompilation : ICanCallBuild
    {
        ICanCompile AlsoCompile();
    }
    public interface ICanCompile : ICanCallBuild
    {
        //ICanRequireCompilation WithMethod(string methodName);
        //ICanRequireCompilation WithMethod(string methodName, Type expectedReturnType);
        //ICanRequireCompilation WithMethod(string methodName, ParamList expectedParameters);
        //ICanRequireCompilation WithMethod(string methodName, ParamList expectedParameters, Type expectedReturnType);
        ICanCompile WithParameters(object[] parameters);
        ICanCompile SetExpectedStringOutput(string expectedStringOutput);
        ICanCompile SetExpectedValue(object expectedOutput);
    }

    //interface ICanSetExpectedOutput 
    //{
    //    ICanCallBuild WithParameters();
    //}
    //interface ICanParameterizeCompilations : ICanSetExpectedOutput, ICanSetExpectedStringOutput
    //{
    //}
    //interface ICanSetExpectedStringOutput : ICanCallBuild
    //{
    //}

}
