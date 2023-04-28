#pragma checksum "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\Expense\Sales.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b40efd485cff2dcb1b5ca3c2002fa1a74dd15840"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Expense_Sales), @"mvc.1.0.view", @"/Views/Expense/Sales.cshtml")]
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
#line 1 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\Expense\Sales.cshtml"
using DataAccessLayer.DTO;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b40efd485cff2dcb1b5ca3c2002fa1a74dd15840", @"/Views/Expense/Sales.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bdd1659da1753dfc7ce70d0e00ab0f21563c3b64", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Expense_Sales : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<MonthlySalesDTO>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\Expense\Sales.cshtml"
  
    ViewData["Title"] = "Sales";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""container-fluid"">

    <div class=""card shadow mb-4"">
        <div class=""card-header py-3"">
            <h6 class=""m-0 font-weight-bold text-primary"">Siparişler</h6>
        </div>
        <div class=""card-body"">
            <div class=""table-responsive"">
                <table class=""table table-bordered"" id=""dataTable"" width=""100%"" cellspacing=""0"">
                    <thead>
                        <tr>
                            <th>Satış Tarihi</th>
                            <th>TCKN</th>
                            <th>Müşteri İsmi</th>
                            <th>Oluşturan Personel</th>
                            <th>Satış Tutarı</th>

                        </tr>
                    </thead>

                    <tbody>
");
#nullable restore
#line 28 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\Expense\Sales.cshtml"
                         foreach (MonthlySalesDTO item in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>");
#nullable restore
#line 31 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\Expense\Sales.cshtml"
                               Write(item.OrderDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 32 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\Expense\Sales.cshtml"
                               Write(item.TCKN);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 33 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\Expense\Sales.cshtml"
                               Write(item.CustomerName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 34 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\Expense\Sales.cshtml"
                               Write(item.EmployeUserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 35 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\Expense\Sales.cshtml"
                               Write(item.SalesTotal);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n");
#nullable restore
#line 37 "C:\Users\samet\Masaüstü\GitHub\TeknoromaProject\WebUI\Views\Expense\Sales.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<MonthlySalesDTO>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
