#pragma checksum "E:\asmfinal\asmfinal\Views\Shared\_countcart.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "40a6931cad746fe117822924dd0bbc42cb0a8735"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__countcart), @"mvc.1.0.view", @"/Views/Shared/_countcart.cshtml")]
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
#line 1 "E:\asmfinal\asmfinal\Views\_ViewImports.cshtml"
using asmfinal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\asmfinal\asmfinal\Views\_ViewImports.cshtml"
using asmfinal.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\asmfinal\asmfinal\Views\Shared\_countcart.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"40a6931cad746fe117822924dd0bbc42cb0a8735", @"/Views/Shared/_countcart.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"90ee546ce726a57c9b2fd791596f4bb6e760ec90", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__countcart : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\asmfinal\asmfinal\Views\Shared\_countcart.cshtml"
  

    var Cart = SessionHelper.GetObjectFormJson<List<ItemCart>>(HttpContextAccessor.HttpContext.Session,"cart");



#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 11 "E:\asmfinal\asmfinal\Views\Shared\_countcart.cshtml"
 if (Cart != null)
{


#line default
#line hidden
#nullable disable
            WriteLiteral("<div style=\"position: absolute; top: -15px; right: -15px;\r\n                        width: 20px; height: 20px; border-radius: 50%;\r\n                        background: red; color: white;\">");
#nullable restore
#line 16 "E:\asmfinal\asmfinal\Views\Shared\_countcart.cshtml"
                                                   Write(Cart.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 17 "E:\asmfinal\asmfinal\Views\Shared\_countcart.cshtml"

}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Microsoft.AspNetCore.Http.IHttpContextAccessor HttpContextAccessor { get; private set; }
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
