#pragma checksum "E:\BarBeeOrderProject\BarBeeOrder\BarBeeOrder\BarBeeOrder\Views\Product\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "09d512f2ff756ed97320d52ac4f6647f16704958"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_Details), @"mvc.1.0.view", @"/Views/Product/Details.cshtml")]
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
#line 1 "E:\BarBeeOrderProject\BarBeeOrder\BarBeeOrder\BarBeeOrder\Views\_ViewImports.cshtml"
using BarBeeOrder;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\BarBeeOrderProject\BarBeeOrder\BarBeeOrder\BarBeeOrder\Views\_ViewImports.cshtml"
using BarBeeOrder.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"09d512f2ff756ed97320d52ac4f6647f16704958", @"/Views/Product/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b803e61478af4ded3268e21d659e86b28f6fcd40", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BarBeeOrder.Models.Product>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-full"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Product Image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("single-img gallery-popup"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Product Thumnail"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\BarBeeOrderProject\BarBeeOrder\BarBeeOrder\BarBeeOrder\Views\Product\Details.cshtml"
  
    ViewData["Title"] = Model.Tittle;
    Layout = "~/Views/Shared/_Layout.cshtml";
    List<Product> products = ViewBag.SanPham;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<!-- Begin Main Content Area  -->
<main class=""main-content"">
    <div class=""breadcrumb-area breadcrumb-height"" data-bg-image=""/assets/images/breadcrumb/bg/1-1-1920x373.jpg"">
        <div class=""container h-100"">
            <div class=""row h-100"">
                <div class=""col-lg-12"">
                    <div class=""breadcrumb-item"">
                        <h1 class=""breadcrumb-heading"">Chi tiết sản phẩm</h1>
                        <ul>
                            <li>
                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "09d512f2ff756ed97320d52ac4f6647f167049586301", async() => {
                WriteLiteral("Trang chủ <i class=\"pe-7s-angle-right\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                            </li>
                            <li>Chi tiết sản phẩm</li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class=""single-product-area section-space-top-100"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-6"">
                    <div class=""single-product-img h-100"">
                        <div class=""swiper-container single-product-slider"">
                            <div class=""swiper-wrapper"">
                                <div class=""swiper-slide"">
                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "09d512f2ff756ed97320d52ac4f6647f167049588395", async() => {
                WriteLiteral("\r\n                                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "09d512f2ff756ed97320d52ac4f6647f167049588690", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 1614, "~/images/products/", 1614, 18, true);
#nullable restore
#line 36 "E:\BarBeeOrderProject\BarBeeOrder\BarBeeOrder\BarBeeOrder\Views\Product\Details.cshtml"
AddHtmlAttributeValue("", 1632, Model.Thumb, 1632, 12, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1480, "~/images/products/", 1480, 18, true);
#nullable restore
#line 35 "E:\BarBeeOrderProject\BarBeeOrder\BarBeeOrder\BarBeeOrder\Views\Product\Details.cshtml"
AddHtmlAttributeValue("", 1498, Model.Thumb, 1498, 12, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                </div>\r\n");
            WriteLiteral(@"                            </div>
                            <!-- Add Pagination -->
                            <div class=""swiper-pagination""></div>
                        </div>
                    </div>
                </div>
                <div class=""col-lg-6"">
                    <div class=""product-thumb-with-content row"">
                        <div class=""col-12 order-lg-1 order-2 pt-10 pt-lg-0"">
                            <div class=""single-product-content"">
                                <h2 class=""title"">");
#nullable restore
#line 54 "E:\BarBeeOrderProject\BarBeeOrder\BarBeeOrder\BarBeeOrder\Views\Product\Details.cshtml"
                                             Write(Model.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                                <div class=\"price-box pb-1\">\r\n                                    <span class=\"new-price text-danger\">");
#nullable restore
#line 56 "E:\BarBeeOrderProject\BarBeeOrder\BarBeeOrder\BarBeeOrder\Views\Product\Details.cshtml"
                                                                   Write(Model.Price.ToString("#,##0"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@" VND</span>

                                </div>
                                <div class=""rating-box-wrap pb-7"">
                                    <div class=""rating-box"">
                                        <ul>
                                            <li><i class=""pe-7s-star""></i></li>
                                            <li><i class=""pe-7s-star""></i></li>
                                            <li><i class=""pe-7s-star""></i></li>
                                            <li><i class=""pe-7s-star""></i></li>
                                            <li><i class=""pe-7s-star""></i></li>
                                        </ul>
                                    </div>
                                </div>
                                <p class=""short-desc mb-6"">
                                    ");
#nullable restore
#line 71 "E:\BarBeeOrderProject\BarBeeOrder\BarBeeOrder\BarBeeOrder\Views\Product\Details.cshtml"
                               Write(Model.ShortDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                </p>
                                <ul class=""quantity-with-btn pb-7"">
                                    <li class=""quantity"">
                                        <div class=""cart-plus-minus"">
                                            <input id=""txtsoluong"" name=""txtsoluong"" class=""cart-plus-minus-box"" value=""1"" type=""text"">
                                        </div>
                                    </li>
                                    <li class=""add-to-cart"">
                                        <a class=""btn btn-custom-size lg-size btn-primary btn-secondary-hover rounded-0"" href=""javascript:void(0)"">Thêm vào giỏ hàng</a>
                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "09d512f2ff756ed97320d52ac4f6647f1670495815088", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("hidden", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
#nullable restore
#line 81 "E:\BarBeeOrderProject\BarBeeOrder\BarBeeOrder\BarBeeOrder\Views\Product\Details.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.ProductId);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                    </li>
                                    <li class=""wishlist-btn-wrap"">
                                        <a class=""btn rounded-0"" href=""wishlist.html"">
                                            <i class=""pe-7s-like""></i>
                                        </a>
                                    </li>
                                </ul>
                                <div class=""product-category text-matterhorn pb-2"">
                                    <span class=""title"">Danh mục :</span>
                                    <ul>
                                        <li>
                                            <a");
            BeginWriteAttribute("href", " href=\"", 5216, "\"", 5254, 2);
            WriteAttributeValue("", 5223, "/cua-hang-", 5223, 10, true);
#nullable restore
#line 93 "E:\BarBeeOrderProject\BarBeeOrder\BarBeeOrder\BarBeeOrder\Views\Product\Details.cshtml"
WriteAttributeValue("", 5233, Model.Category.Alias, 5233, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 93 "E:\BarBeeOrderProject\BarBeeOrder\BarBeeOrder\BarBeeOrder\Views\Product\Details.cshtml"
                                                                                 Write(Model.Category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a>
                                        </li>

                                    </ul>
                                </div>
                                <div class=""social-link align-items-center pb-lg-8"">
                                    <span class=""title pe-3"">Share:</span>
                                    <ul>
                                        <li>
                                            <a");
            BeginWriteAttribute("href", " href=\"", 5710, "\"", 5717, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                                                <i class=""fa fa-pinterest-p""></i>
                                            </a>
                                        </li>
                                        <li>
                                            <a");
            BeginWriteAttribute("href", " href=\"", 5993, "\"", 6000, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                                                <i class=""fa fa-twitter""></i>
                                            </a>
                                        </li>
                                        <li>
                                            <a");
            BeginWriteAttribute("href", " href=\"", 6272, "\"", 6279, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                                                <i class=""fa fa-tumblr""></i>
                                            </a>
                                        </li>
                                        <li>
                                            <a");
            BeginWriteAttribute("href", " href=\"", 6550, "\"", 6557, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                                                <i class=""fa fa-dribbble""></i>
                                            </a>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <div class=""col-12 order-lg-2 order-1 pt-10 pt-lg-0"">
                            <div class=""swiper-container single-product-thumbs"">
                                <div class=""swiper-wrapper"">
                                    <a href=""javascript:void(0)"" class=""swiper-slide"">
                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "09d512f2ff756ed97320d52ac4f6647f1670495820823", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 7267, "~/images/products/", 7267, 18, true);
#nullable restore
#line 129 "E:\BarBeeOrderProject\BarBeeOrder\BarBeeOrder\BarBeeOrder\Views\Product\Details.cshtml"
AddHtmlAttributeValue("", 7285, Model.Thumb, 7285, 12, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                    </a>\r\n");
            WriteLiteral(@"                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class=""product-tab-area section-space-top-100"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-12"">
                    <ul class=""nav product-tab-nav product-tab-style-2"" role=""tablist"">
                        <li class=""nav-item"" role=""presentation"">
                            <a class=""active btn btn-custom-size"" id=""description-tab"" data-bs-toggle=""tab"" href=""#description"" role=""tab"" aria-controls=""description"" aria-selected=""true"">
                                Mô tả
                            </a>
                        </li>
");
            WriteLiteral(@"                        <li class=""nav-item"" role=""presentation"">
                            <a class=""btn btn-custom-size"" id=""shipping-tab"" data-bs-toggle=""tab"" href=""#shipping"" role=""tab"" aria-controls=""shipping"" aria-selected=""false"">
                                Thông tin giao hàng
                            </a>
                        </li>
                    </ul>
                    <div class=""tab-content product-tab-content"">
                        <div class=""tab-pane fade show active"" id=""description"" role=""tabpanel"" aria-labelledby=""description-tab"">
                            <div class=""product-description-body"">
                                <p class=""short-desc mb-0"">");
#nullable restore
#line 166 "E:\BarBeeOrderProject\BarBeeOrder\BarBeeOrder\BarBeeOrder\Views\Product\Details.cshtml"
                                                      Write(Html.Raw(Model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n                        </div>\r\n");
            WriteLiteral(@"                        <div class=""tab-pane fade"" id=""shipping"" role=""tabpanel"" aria-labelledby=""shipping-tab"">
                            <div class=""product-shipping-body"">
                                <h4 class=""title"">Giao hàng</h4>
                                <p class=""short-desc mb-4"">The item will be shipped from China. So it need 15-20 days to deliver. Our product is good with reasonable price and we believe you will worth it. So please wait for it patiently! Thanks.Any question please kindly to contact us and we promise to work hard to help you to solve the problem</p>
                                <h4 class=""title"">Về yêu cầu trả hàng</h4>
                                <p class=""short-desc mb-4"">If you don't need the item with worry, you can contact us then we will help you to solve the problem, so please close the return request! Thanks</p>
                                <h4 class=""title"">Quyền lợi</h4>
                                <p class=""short-desc mb-0"">If it is the qua");
            WriteLiteral(@"lity question, we will resend or refund to you; If you receive damaged or wrong items, please contact us and attach some pictures about product, we will exchange a new correct item to you after the confirmation.</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class=""product-slider-area section-space-top-95 section-space-bottom-100"">
        <div class=""container"">
            <div class=""section-title text-center pb-55"">
                <span class=""sub-title text-primary"">Có thể bạn sẽ thích</span>
                <h2 class=""title mb-0"">Các sản phẩm tương tự</h2>
            </div>
            <div class=""row"">
                <div class=""col-lg-12"">
                    <div class=""swiper-slider-holder swiper-arrow"">
                        <div class=""swiper-container product-slider border-issue"">
                            <div class=""swiper-wrapper"">
");
#nullable restore
#line 301 "E:\BarBeeOrderProject\BarBeeOrder\BarBeeOrder\BarBeeOrder\Views\Product\Details.cshtml"
                                 if (products != null)
                                {
                                    foreach (var item in products)
                                    {
                                        string url = $"/cua-hang/{item.Alias}-{item.ProductId}.html";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                        <div class=""swiper-slide"">
                                            <div class=""product-item"">
                                                <div class=""product-img img-zoom-effect"">
                                                    <a");
            BeginWriteAttribute("href", " href=\"", 18781, "\"", 18792, 1);
#nullable restore
#line 309 "E:\BarBeeOrderProject\BarBeeOrder\BarBeeOrder\BarBeeOrder\Views\Product\Details.cshtml"
WriteAttributeValue("", 18788, url, 18788, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "09d512f2ff756ed97320d52ac4f6647f1670495827927", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 18879, "~/images/products/", 18879, 18, true);
#nullable restore
#line 310 "E:\BarBeeOrderProject\BarBeeOrder\BarBeeOrder\BarBeeOrder\Views\Product\Details.cshtml"
AddHtmlAttributeValue("", 18897, item.Thumb, 18897, 11, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 310 "E:\BarBeeOrderProject\BarBeeOrder\BarBeeOrder\BarBeeOrder\Views\Product\Details.cshtml"
AddHtmlAttributeValue("", 18915, item.Tittle, 18915, 12, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                                    </a>
                                                    <div class=""product-add-action"">
                                                        <ul>
                                                            <li>
                                                                <a href=""cart.html"">
                                                                    <i class=""pe-7s-cart""></i>
                                                                </a>
                                                            </li>
");
            WriteLiteral(@"                                                            <li>
                                                                <a href=""wishlist.html"">
                                                                    <i class=""pe-7s-like""></i>
                                                                </a>
                                                            </li>
                                                        </ul>
                                                    </div>
                                                </div>
                                                <div class=""product-content texx"">
                                                    <a class=""product-name""");
            BeginWriteAttribute("href", " href=\"", 20645, "\"", 20656, 1);
#nullable restore
#line 333 "E:\BarBeeOrderProject\BarBeeOrder\BarBeeOrder\BarBeeOrder\Views\Product\Details.cshtml"
WriteAttributeValue("", 20652, url, 20652, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 333 "E:\BarBeeOrderProject\BarBeeOrder\BarBeeOrder\BarBeeOrder\Views\Product\Details.cshtml"
                                                                                   Write(item.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                                    <div class=\"price-box pb-1\">\r\n                                                        <span class=\"new-price\">");
#nullable restore
#line 335 "E:\BarBeeOrderProject\BarBeeOrder\BarBeeOrder\BarBeeOrder\Views\Product\Details.cshtml"
                                                                           Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                                                    </div>
                                                    <div class=""rating-box"">
                                                        <ul>
                                                            <li><i class=""pe-7s-star""></i></li>
                                                            <li><i class=""pe-7s-star""></i></li>
                                                            <li><i class=""pe-7s-star""></i></li>
                                                            <li><i class=""pe-7s-star""></i></li>
                                                            <li><i class=""pe-7s-star""></i></li>
                                                        </ul>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
");
#nullable restore
#line 349 "E:\BarBeeOrderProject\BarBeeOrder\BarBeeOrder\BarBeeOrder\Views\Product\Details.cshtml"
                                    }
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            </div>
                        </div>
                        <!-- Add Arrows -->
                        <div class=""swiper-button-next""></div>
                        <div class=""swiper-button-prev""></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</main>
<!-- Main Content Area End Here  -->
");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
<script>
    $(document).ready(function(){
        $(function (){
            $("".add-to-cart"").click(function(){
                var productid = $('#ProductId').val();
                var soluong = $('#txtsoluong').val();
                $.ajax({
                    url:'/api/cart/add',
                    type: ""POST"",
                    dataType: ""JSON"",
                    data: {
                        productID: productid,
                        amount: soluong

                    },
                    success: function(response){
                        loadHeaderCart();
                        location.reload();
                    },
                    error: function(error){
                        alert(""Có lỗi khi cập nhật giỏ hàng!"");
                    }
                });
            });
        });

        function loadHeaderCart(){
            $('#miniCart').load(""AjaxContent/HeaderCart"");
            $('#numberCart').load(""AjaxContent/NumberCart"");
   ");
                WriteLiteral("     }\r\n\r\n\r\n    });\r\n</script>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BarBeeOrder.Models.Product> Html { get; private set; }
    }
}
#pragma warning restore 1591
