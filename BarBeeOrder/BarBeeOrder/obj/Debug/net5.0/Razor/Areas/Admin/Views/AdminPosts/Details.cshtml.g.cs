#pragma checksum "E:\BarBeeOrderProject\BarBeeOrder\BarBeeOrder\BarBeeOrder\Areas\Admin\Views\AdminPosts\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f4e2386e44a97f2ba3622da17abe10610aa677c3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_AdminPosts_Details), @"mvc.1.0.view", @"/Areas/Admin/Views/AdminPosts/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f4e2386e44a97f2ba3622da17abe10610aa677c3", @"/Areas/Admin/Views/AdminPosts/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b803e61478af4ded3268e21d659e86b28f6fcd40", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_AdminPosts_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BarBeeOrder.Models.Post>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("breadcrumb-item"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "AdminPosts", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "E:\BarBeeOrderProject\BarBeeOrder\BarBeeOrder\BarBeeOrder\Areas\Admin\Views\AdminPosts\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Areas/Admin/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"page-header\">\r\n    <div class=\"header-sub-title\">\r\n        <nav class=\"breadcrumb breadcrumb-dash\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f4e2386e44a97f2ba3622da17abe10610aa677c35250", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f4e2386e44a97f2ba3622da17abe10610aa677c36953", async() => {
                WriteLiteral("Danh s??ch b??i ????ng");
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
            WriteLiteral(@"
            <span class=""breadcrumb-item active"">Chi ti???t b??i ????ng</span>
        </nav>
    </div>
</div>

<div class=""card"">
    <div class=""card-body"">
        <h4 class=""card-title"">Th??ng tin b??i ????ng</h4>
        <div class=""table-responsive"">
            <table class=""product-info-table m-t-20"">
                <tbody>
                    <tr>
                        <td>ID:</td>
                        <td class=""text-dark font-weight-semibold"">");
#nullable restore
#line 26 "E:\BarBeeOrderProject\BarBeeOrder\BarBeeOrder\BarBeeOrder\Areas\Admin\Views\AdminPosts\Details.cshtml"
                                                              Write(Model.PostId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td>Ti??u ?????:</td>\r\n                        <td>");
#nullable restore
#line 30 "E:\BarBeeOrderProject\BarBeeOrder\BarBeeOrder\BarBeeOrder\Areas\Admin\Views\AdminPosts\Details.cshtml"
                       Write(Model.Tittle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td>T??c gi???:</td>\r\n                        <td>");
#nullable restore
#line 34 "E:\BarBeeOrderProject\BarBeeOrder\BarBeeOrder\BarBeeOrder\Areas\Admin\Views\AdminPosts\Details.cshtml"
                             if(Model.Customer!=null){

#line default
#line hidden
#nullable disable
            WriteLiteral("<p>");
#nullable restore
#line 34 "E:\BarBeeOrderProject\BarBeeOrder\BarBeeOrder\BarBeeOrder\Areas\Admin\Views\AdminPosts\Details.cshtml"
                                                    Write(Model.Customer.Fullname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>");
#nullable restore
#line 34 "E:\BarBeeOrderProject\BarBeeOrder\BarBeeOrder\BarBeeOrder\Areas\Admin\Views\AdminPosts\Details.cshtml"
                                                                                     }else{

#line default
#line hidden
#nullable disable
            WriteLiteral("<p>???n danh</p>");
#nullable restore
#line 34 "E:\BarBeeOrderProject\BarBeeOrder\BarBeeOrder\BarBeeOrder\Areas\Admin\Views\AdminPosts\Details.cshtml"
                                                                                                         }

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td>M?? t??? ng???n:</td>\r\n                        <td>");
#nullable restore
#line 38 "E:\BarBeeOrderProject\BarBeeOrder\BarBeeOrder\BarBeeOrder\Areas\Admin\Views\AdminPosts\Details.cshtml"
                       Write(Model.ShortContent);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td>Ng??y ????ng:</td>\r\n                        <td>");
#nullable restore
#line 42 "E:\BarBeeOrderProject\BarBeeOrder\BarBeeOrder\BarBeeOrder\Areas\Admin\Views\AdminPosts\Details.cshtml"
                       Write(Model.CreatedDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td>Ho???t ?????ng:</td>\r\n                        <td>\r\n");
#nullable restore
#line 47 "E:\BarBeeOrderProject\BarBeeOrder\BarBeeOrder\BarBeeOrder\Areas\Admin\Views\AdminPosts\Details.cshtml"
                             if (Model.Published)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div class=\"form-group d-flex align-items-center\">\r\n                                    <div class=\"switch d-inline m-r-10\">\r\n                                        <input type=\"checkbox\" id=\"switch-4\"");
            BeginWriteAttribute("disabled", " disabled=\"", 2127, "\"", 2138, 0);
            EndWriteAttribute();
            BeginWriteAttribute("checked", " checked=\"", 2139, "\"", 2149, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                        <label for=\"switch-4\"></label>\r\n                                    </div>\r\n                                    \r\n                                </div>\r\n");
#nullable restore
#line 56 "E:\BarBeeOrderProject\BarBeeOrder\BarBeeOrder\BarBeeOrder\Areas\Admin\Views\AdminPosts\Details.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div class=\"form-group d-flex align-items-center\">\r\n                                    <div class=\"switch d-inline m-r-10\">\r\n                                        <input type=\"checkbox\" id=\"switch-4\"");
            BeginWriteAttribute("disabled", " disabled=\"", 2677, "\"", 2688, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                        <label for=\"switch-4\"></label>\r\n                                    </div>\r\n                                    \r\n                                </div>\r\n");
#nullable restore
#line 66 "E:\BarBeeOrderProject\BarBeeOrder\BarBeeOrder\BarBeeOrder\Areas\Admin\Views\AdminPosts\Details.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td>N???i dung:</td>\r\n                        <td>(");
#nullable restore
#line 71 "E:\BarBeeOrderProject\BarBeeOrder\BarBeeOrder\BarBeeOrder\Areas\Admin\Views\AdminPosts\Details.cshtml"
                        Write(Model.PostContent);

#line default
#line hidden
#nullable disable
            WriteLiteral(")</td>\r\n                        \r\n                    </tr>\r\n\r\n                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BarBeeOrder.Models.Post> Html { get; private set; }
    }
}
#pragma warning restore 1591
