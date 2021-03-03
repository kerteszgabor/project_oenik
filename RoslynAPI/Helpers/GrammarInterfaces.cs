using System;
using System.Collections.Generic;
using System.Text;

namespace RoslynAPITest.Helpers
{
    interface ICanCallBuild
    {
        ClassReport Build();
        ICanRequireCompilation WithMethod(string methodName);
        ICanRequireCompilation WithMethod(string methodName, Type expectedReturnType);
        ICanRequireCompilation WithMethod(string methodName, ParamList expectedParameters);
        ICanRequireCompilation WithMethod(string methodName, ParamList expectedParameters, Type expectedReturnType);
    }
    interface ICanRequireCompilation : ICanCallBuild
    {
        ICanCompile AlsoCompile();
    }
    interface ICanCompile : ICanCallBuild
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
