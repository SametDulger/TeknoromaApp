#pragma checksum "C:\Users\samet\source\repos\TeknoromaProject\WebUI\Views\Support\ClosedDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8a5ccfd02a2c0a261e7d1419aa0b0bf0a1b73c3c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Support_ClosedDetails), @"mvc.1.0.view", @"/Views/Support/ClosedDetails.cshtml")]
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
#line 2 "C:\Users\samet\source\repos\TeknoromaProject\WebUI\Views\_ViewImports.cshtml"
using BusinessLayer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\samet\source\repos\TeknoromaProject\WebUI\Views\_ViewImports.cshtml"
using DataAccessLayer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\samet\source\repos\TeknoromaProject\WebUI\Views\_ViewImports.cshtml"
using DataAccessLayer.DTO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\samet\source\repos\TeknoromaProject\WebUI\Views\_ViewImports.cshtml"
using EntityLayer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\samet\source\repos\TeknoromaProject\WebUI\Views\_ViewImports.cshtml"
using WebUI.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\samet\source\repos\TeknoromaProject\WebUI\Views\Support\ClosedDetails.cshtml"
using EntityLayer.Concrete;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8a5ccfd02a2c0a261e7d1419aa0b0bf0a1b73c3c", @"/Views/Support/ClosedDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bdd1659da1753dfc7ce70d0e00ab0f21563c3b64", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Support_ClosedDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Issue>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\samet\source\repos\TeknoromaProject\WebUI\Views\Support\ClosedDetails.cshtml"
  
    ViewData["Title"] = "ClosedDetails";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"card w-75\">\n    <div class=\"card-body\">\n        <h4>Oluşturan Kullanıcı</h4>\n");
#nullable restore
#line 11 "C:\Users\samet\source\repos\TeknoromaProject\WebUI\Views\Support\ClosedDetails.cshtml"
         foreach (AppUser item in ViewBag.AppUser)
        {
            if (item.Id == Model.AppUserId)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <h6>");
#nullable restore
#line 15 "C:\Users\samet\source\repos\TeknoromaProject\WebUI\Views\Support\ClosedDetails.cshtml"
               Write(item.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\n");
#nullable restore
#line 16 "C:\Users\samet\source\repos\TeknoromaProject\WebUI\Views\Support\ClosedDetails.cshtml"
            }
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h4>Konu</h4>\n        <h6 class=\"card-title\">");
#nullable restore
#line 19 "C:\Users\samet\source\repos\TeknoromaProject\WebUI\Views\Support\ClosedDetails.cshtml"
                          Write(Model.Subject);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\n        <h4>Sorun</h4>\n        <p class=\"card-text\">");
#nullable restore
#line 21 "C:\Users\samet\source\repos\TeknoromaProject\WebUI\Views\Support\ClosedDetails.cshtml"
                        Write(Model.Problem);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n        <h4>Cevap</h4>\n        <p>");
#nullable restore
#line 23 "C:\Users\samet\source\repos\TeknoromaProject\WebUI\Views\Support\ClosedDetails.cshtml"
      Write(Model.Answer);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n        ");
#nullable restore
#line 24 "C:\Users\samet\source\repos\TeknoromaProject\WebUI\Views\Support\ClosedDetails.cshtml"
   Write(Html.ActionLink("Geri Dön", "Index", "Support"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        \r\n    </div>\n</div>\n\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Issue> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
