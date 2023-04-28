#pragma checksum "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\Report\SupplierReport.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "50b663941448fd66383b00db6f27d59a0be25bc4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Report_SupplierReport), @"mvc.1.0.view", @"/Views/Report/SupplierReport.cshtml")]
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
#line 1 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\Report\SupplierReport.cshtml"
using DataAccessLayer.DTO;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"50b663941448fd66383b00db6f27d59a0be25bc4", @"/Views/Report/SupplierReport.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bdd1659da1753dfc7ce70d0e00ab0f21563c3b64", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Report_SupplierReport : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\Report\SupplierReport.cshtml"
  
    ViewData["Title"] = "SupplierReport";
    Layout = "~/Views/Shared/_Layout.cshtml";

    var allTime = ViewBag.AllTime;
    var mountly = ViewBag.Mountly;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container-fluid"">
    <div class=""card shadow mb-4"">
        <div class=""card-header py-3"">
            <h6 class=""m-0 font-weight-bold text-primary"">Tedarikçi Raporu / Tüm Zaman</h6>
        </div>
        <div class=""card-body"">
            <div class=""table-responsive"">
                <table class=""table table-bordered"" id=""dataTable"" width=""100%"" cellspacing=""0"">
                    <thead>
                        <tr>
                            <th>Tedarikçi </th>
                            <th>Ürün </th>
                            <th>Genel Toplam</th>

                        </tr>
                    </thead>
                   
                    <tbody>
");
#nullable restore
#line 29 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\Report\SupplierReport.cshtml"
                        foreach (SupplierExpenseReportDTO vm in allTime)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\n                                <td>");
#nullable restore
#line 32 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\Report\SupplierReport.cshtml"
                               Write(vm.SupplierName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                <td>");
#nullable restore
#line 33 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\Report\SupplierReport.cshtml"
                               Write(vm.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                <td>");
#nullable restore
#line 34 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\Report\SupplierReport.cshtml"
                               Write(vm.Total);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                            </tr>\n");
#nullable restore
#line 36 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\Report\SupplierReport.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </tbody>
                </table>
            </div>
        </div>
    </div>

</div>
<hr />
<div class=""container-fluid"">
    <div class=""card shadow mb-4"">
        <div class=""card-header py-3"">
            <h6 class=""m-0 font-weight-bold text-primary"">Tedarikçi Raporu / Aylık</h6>
        </div>
        <div class=""card-body"">
            <div class=""table-responsive"">
                <table class=""table table-bordered"" id=""dataTable"" width=""100%"" cellspacing=""0"">
                    <thead>
                        <tr>
                            <th>Tedarikçi </th>
                            <th>Ürün </th>
                            <th>Genel Toplam</th>

                        </tr>
                    </thead>
                   
                    <tbody>
");
#nullable restore
#line 64 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\Report\SupplierReport.cshtml"
                         foreach (SupplierExpenseReportDTO vm in mountly)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\n                                <td>");
#nullable restore
#line 67 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\Report\SupplierReport.cshtml"
                               Write(vm.SupplierName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                <td>");
#nullable restore
#line 68 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\Report\SupplierReport.cshtml"
                               Write(vm.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                <td>");
#nullable restore
#line 69 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\Report\SupplierReport.cshtml"
                               Write(vm.Total);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                            </tr>\n");
#nullable restore
#line 71 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\Report\SupplierReport.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    </tbody>\n                </table>\n            </div>\n        </div>\n    </div>\n\n</div>\n\n");
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
