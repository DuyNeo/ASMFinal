#pragma checksum "D:\asmfinal\asmfinal\Views\Shared\_alert.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8d396c5412df653d6f1ca936ff6df67d2c6f6892"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__alert), @"mvc.1.0.view", @"/Views/Shared/_alert.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\asmfinal\asmfinal\Views\_ViewImports.cshtml"
using asmfinal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\asmfinal\asmfinal\Views\_ViewImports.cshtml"
using asmfinal.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8d396c5412df653d6f1ca936ff6df67d2c6f6892", @"/Views/Shared/_alert.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"90ee546ce726a57c9b2fd791596f4bb6e760ec90", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__alert : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\asmfinal\asmfinal\Views\Shared\_alert.cshtml"
  

    string message = TempData["message"] as string;





#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"alert alert-success\">");
#nullable restore
#line 10 "D:\asmfinal\asmfinal\Views\Shared\_alert.cshtml"
                            Write(message);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591