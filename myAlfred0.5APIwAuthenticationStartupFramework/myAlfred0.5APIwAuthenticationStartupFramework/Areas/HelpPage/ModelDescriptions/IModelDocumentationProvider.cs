using System;
using System.Reflection;

namespace myAlfred0._5APIwAuthenticationStartupFramework.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}