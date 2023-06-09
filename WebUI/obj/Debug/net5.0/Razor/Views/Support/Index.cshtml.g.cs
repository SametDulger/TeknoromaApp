#pragma checksum "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\Support\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e1609ae3db56340e118e084604ea4cad97192f82"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Support_Index), @"mvc.1.0.view", @"/Views/Support/Index.cshtml")]
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
#line 2 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\_ViewImports.cshtml"
using BusinessLayer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\_ViewImports.cshtml"
using DataAccessLayer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\_ViewImports.cshtml"
using DataAccessLayer.DTO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\_ViewImports.cshtml"
using EntityLayer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\_ViewImports.cshtml"
using WebUI.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\Support\Index.cshtml"
using EntityLayer.Concrete;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e1609ae3db56340e118e084604ea4cad97192f82", @"/Views/Support/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bdd1659da1753dfc7ce70d0e00ab0f21563c3b64", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Support_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\Support\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

    var open = ViewBag.OpenIssue;
    var checking = ViewBag.CheckingIssue;
    var closed = ViewBag.ClosedIssue;


#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container-fluid"">
    <div class=""card shadow mb-4"">
        <div class=""card-header py-3"">
            <h6 class=""m-0 font-weight-bold text-primary"">Oluşturulan Kayıtlar</h6>
        </div>
        <div class=""card-body"">
            <div class=""table-responsive"">
                <table class=""table table-bordered"" id=""dataTable"" width=""100%"" cellspacing=""0"">
                    <thead>
                        <tr>
                            <th>Kayıt NO</th>
                            <th>Konu</th>
                            <th>Oluşturan Personel</th>
                            <th>Kayıt Durumu</th>
                            <th>İşlemler</th>
                    </thead>
                   
                    <tbody>
");
#nullable restore
#line 31 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\Support\Index.cshtml"
                         foreach (Issue openIssue in open)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\n\n                                <td>");
#nullable restore
#line 35 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\Support\Index.cshtml"
                               Write(openIssue.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                <td>");
#nullable restore
#line 36 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\Support\Index.cshtml"
                               Write(openIssue.Subject);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n");
#nullable restore
#line 37 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\Support\Index.cshtml"
                                 foreach (AppUser appUser in ViewBag.AppUser)
                                {
                                    if (openIssue.AppUserId == appUser.Id)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <td>");
#nullable restore
#line 41 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\Support\Index.cshtml"
                                       Write(appUser.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n");
#nullable restore
#line 42 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\Support\Index.cshtml"
                                    }
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td>");
#nullable restore
#line 44 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\Support\Index.cshtml"
                               Write(openIssue.IssueStatus);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                <td>\n                                    ");
#nullable restore
#line 46 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\Support\Index.cshtml"
                               Write(Html.ActionLink("Kaydı İncele", "Details", "Support", new { id = openIssue.Id }, new { @class = "btn btn-primary" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </td>\n                            </tr>\n");
#nullable restore
#line 49 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\Support\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </tbody>
                </table>
            </div>
        </div>
    </div>
</div>
<hr />
<div class=""container-fluid"">
    <div class=""card shadow mb-4"">
        <div class=""card-header py-3"">
            <h6 class=""m-0 font-weight-bold text-primary"">İşlemde Olan Kayıtlar</h6>
        </div>
        <div class=""card-body"">
            <div class=""table-responsive"">
                <table class=""table table-bordered"" id=""dataTable"" width=""100%"" cellspacing=""0"">
                    <thead>
                        <tr>
                            <th>Kayıt NO</th>
                            <th>Konu</th>
                            <th>Oluşturan Personel</th>
                            <th>Kayıt Durumu</th>
                            <th>İşlemler</th>
                    </thead>
                   
                    <tbody>
");
#nullable restore
#line 75 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\Support\Index.cshtml"
                         foreach (Issue checkingIssue in checking)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\n\n                                <td>");
#nullable restore
#line 79 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\Support\Index.cshtml"
                               Write(checkingIssue.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                <td>");
#nullable restore
#line 80 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\Support\Index.cshtml"
                               Write(checkingIssue.Subject);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n");
#nullable restore
#line 81 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\Support\Index.cshtml"
                                 foreach (AppUser appUser in ViewBag.AppUser)
                                {
                                    if (checkingIssue.AppUserId == appUser.Id)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <td>");
#nullable restore
#line 85 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\Support\Index.cshtml"
                                       Write(appUser.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n");
#nullable restore
#line 86 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\Support\Index.cshtml"
                                    }
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td>");
#nullable restore
#line 88 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\Support\Index.cshtml"
                               Write(checkingIssue.IssueStatus);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                <td>\n                                    ");
#nullable restore
#line 90 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\Support\Index.cshtml"
                               Write(Html.ActionLink("Kaydı Sonuçlandır", "Edit", "Support", new { id = checkingIssue.Id }, new { @class = "btn btn-primary" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </td>\n                            </tr>\n");
#nullable restore
#line 93 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\Support\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </tbody>
                </table>
            </div>
        </div>
    </div>
</div>
<hr />
<div class=""container-fluid"">
    <div class=""card shadow mb-4"">
        <div class=""card-header py-3"">
            <h6 class=""m-0 font-weight-bold text-primary"">Kapalı Kayıtlar</h6>
        </div>
        <div class=""card-body"">
            <div class=""table-responsive"">
                <table class=""table table-bordered"" id=""dataTable"" width=""100%"" cellspacing=""0"">
                    <thead>
                        <tr>
                            <th>Kayıt NO</th>
                            <th>Konu</th>
                            <th>Oluşturan Personel</th>
                            <th>Kayıt Durumu</th>
                            <th>İşlemler</th>
                    </thead>
                  
                    <tbody>
");
#nullable restore
#line 119 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\Support\Index.cshtml"
                         foreach (Issue closedIssue in closed)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\n\n                                <td>");
#nullable restore
#line 123 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\Support\Index.cshtml"
                               Write(closedIssue.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                <td>");
#nullable restore
#line 124 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\Support\Index.cshtml"
                               Write(closedIssue.Subject);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n");
#nullable restore
#line 125 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\Support\Index.cshtml"
                                 foreach (AppUser appUser in ViewBag.AppUser)
                                {
                                    if (closedIssue.AppUserId == appUser.Id)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <td>");
#nullable restore
#line 129 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\Support\Index.cshtml"
                                       Write(appUser.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n");
#nullable restore
#line 130 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\Support\Index.cshtml"
                                    }
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td>");
#nullable restore
#line 132 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\Support\Index.cshtml"
                               Write(closedIssue.IssueStatus);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                <td>\n                                    ");
#nullable restore
#line 134 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\Support\Index.cshtml"
                               Write(Html.ActionLink("İncele", "ClosedDetails", "Support", new { id = closedIssue.Id }, new { @class = "btn btn-warning" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </td>\n                            </tr>\n");
#nullable restore
#line 137 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\Support\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\n                </table>\n            </div>\n        </div>\n    </div>\n</div>\n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
