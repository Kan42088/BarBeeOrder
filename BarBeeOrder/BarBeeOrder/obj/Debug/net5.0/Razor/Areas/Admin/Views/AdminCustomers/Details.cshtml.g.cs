#pragma checksum "E:\BarBeeOrderProject\BarBeeOrder\BarBeeOrder\BarBeeOrder\Areas\Admin\Views\AdminCustomers\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a6884e77efbcb58fd8fa8f52a45bb6c78dc02a9f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_AdminCustomers_Details), @"mvc.1.0.view", @"/Areas/Admin/Views/AdminCustomers/Details.cshtml")]
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
#line 1 "E:\BarBeeOrderProject\BarBeeOrder\BarBeeOrder\BarBeeOrder\Areas\Admin\Views\_ViewImports.cshtml"
using BarBeeOrder;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\BarBeeOrderProject\BarBeeOrder\BarBeeOrder\BarBeeOrder\Areas\Admin\Views\_ViewImports.cshtml"
using BarBeeOrder.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a6884e77efbcb58fd8fa8f52a45bb6c78dc02a9f", @"/Areas/Admin/Views/AdminCustomers/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b803e61478af4ded3268e21d659e86b28f6fcd40", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_AdminCustomers_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BarBeeOrder.Models.Customer>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("breadcrumb-item"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "AdminAccounts", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\BarBeeOrderProject\BarBeeOrder\BarBeeOrder\BarBeeOrder\Areas\Admin\Views\AdminCustomers\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Areas/Admin/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"page-header\">\r\n    <div class=\"header-sub-title\">\r\n        <nav class=\"breadcrumb breadcrumb-dash\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a6884e77efbcb58fd8fa8f52a45bb6c78dc02a9f5277", async() => {
                WriteLiteral("<i class=\"anticon anticon-home m-r-5\"></i>Trang ch???");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a6884e77efbcb58fd8fa8f52a45bb6c78dc02a9f6980", async() => {
                WriteLiteral("Danh s??ch kh??ch h??ng");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            <span class=\"breadcrumb-item active\">Chi ti???t t??i kho???n: ");
#nullable restore
#line 12 "E:\BarBeeOrderProject\BarBeeOrder\BarBeeOrder\BarBeeOrder\Areas\Admin\Views\AdminCustomers\Details.cshtml"
                                                                Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
        </nav>
    </div>
</div>

<div class=""card"">
    <div class=""card-body"">
        <h4 class=""card-title"">Th??ng tin t??i kho???n</h4>
        <div class=""table-responsive"">
            <table class=""product-info-table m-t-20"">
                <tbody>
                    <tr>
                        <td>ID:</td>
                        <td class=""text-dark font-weight-semibold"">");
#nullable restore
#line 25 "E:\BarBeeOrderProject\BarBeeOrder\BarBeeOrder\BarBeeOrder\Areas\Admin\Views\AdminCustomers\Details.cshtml"
                                                              Write(Model.CustomerId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td>H??? v?? t??n:</td>\r\n                        <td>");
#nullable restore
#line 29 "E:\BarBeeOrderProject\BarBeeOrder\BarBeeOrder\BarBeeOrder\Areas\Admin\Views\AdminCustomers\Details.cshtml"
                       Write(Model.Fullname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td>Email:</td>\r\n                        <td>");
#nullable restore
#line 33 "E:\BarBeeOrderProject\BarBeeOrder\BarBeeOrder\BarBeeOrder\Areas\Admin\Views\AdminCustomers\Details.cshtml"
                       Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td>??i???n tho???i:</td>\r\n                        <td>");
#nullable restore
#line 37 "E:\BarBeeOrderProject\BarBeeOrder\BarBeeOrder\BarBeeOrder\Areas\Admin\Views\AdminCustomers\Details.cshtml"
                       Write(Model.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td>Ho???t ?????ng:</td>\r\n                        <td>\r\n");
#nullable restore
#line 42 "E:\BarBeeOrderProject\BarBeeOrder\BarBeeOrder\BarBeeOrder\Areas\Admin\Views\AdminCustomers\Details.cshtml"
                             if (Model.Status)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div class=\"form-group d-flex align-items-center\">\r\n                                    <div class=\"switch d-inline m-r-10\">\r\n                                        <input type=\"checkbox\" id=\"switch-4\"");
            BeginWriteAttribute("disabled", " disabled=\"", 1929, "\"", 1940, 0);
            EndWriteAttribute();
            BeginWriteAttribute("checked", " checked=\"", 1941, "\"", 1951, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                        <label for=\"switch-4\"></label>\r\n                                    </div>\r\n                                    \r\n                                </div>\r\n");
#nullable restore
#line 51 "E:\BarBeeOrderProject\BarBeeOrder\BarBeeOrder\BarBeeOrder\Areas\Admin\Views\AdminCustomers\Details.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div class=\"form-group d-flex align-items-center\">\r\n                                    <div class=\"switch d-inline m-r-10\">\r\n                                        <input type=\"checkbox\" id=\"switch-4\"");
            BeginWriteAttribute("disabled", " disabled=\"", 2479, "\"", 2490, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                        <label for=\"switch-4\"></label>\r\n                                    </div>\r\n                                    \r\n                                </div>\r\n");
#nullable restore
#line 61 "E:\BarBeeOrderProject\BarBeeOrder\BarBeeOrder\BarBeeOrder\Areas\Admin\Views\AdminCustomers\Details.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td>L???n ????ng nh???p cu???i:</td>\r\n                        <td>");
#nullable restore
#line 66 "E:\BarBeeOrderProject\BarBeeOrder\BarBeeOrder\BarBeeOrder\Areas\Admin\Views\AdminCustomers\Details.cshtml"
                       Write(Model.LastLogin);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td>Ng??y t???o:</td>\r\n                        <td>");
#nullable restore
#line 70 "E:\BarBeeOrderProject\BarBeeOrder\BarBeeOrder\BarBeeOrder\Areas\Admin\Views\AdminCustomers\Details.cshtml"
                       Write(Model.CreatedDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td>Quy???n truy c???p:</td>\r\n                        <td>");
#nullable restore
#line 74 "E:\BarBeeOrderProject\BarBeeOrder\BarBeeOrder\BarBeeOrder\Areas\Admin\Views\AdminCustomers\Details.cshtml"
                       Write(Model.Role.RoleName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n\r\n                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BarBeeOrder.Models.Customer> Html { get; private set; }
    }
}
#pragma warning restore 1591
