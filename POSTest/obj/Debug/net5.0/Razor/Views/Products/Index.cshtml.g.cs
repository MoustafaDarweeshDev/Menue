#pragma checksum "T:\_CODE___\task\ASP.NET CORE\POSTest\POSTest\Views\Products\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8c0e6c8b75b78c36cde13d6e08368ffad124dba0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(POSTest.Pages.Products.Views_Products_Index), @"mvc.1.0.view", @"/Views/Products/Index.cshtml")]
namespace POSTest.Pages.Products
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
#line 1 "T:\_CODE___\task\ASP.NET CORE\POSTest\POSTest\Views\_ViewImports.cshtml"
using POSTest;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8c0e6c8b75b78c36cde13d6e08368ffad124dba0", @"/Views/Products/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b58f35ae4b5537b39057ab47fead5ece8e5f8f02", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Products_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "products", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 1 "T:\_CODE___\task\ASP.NET CORE\POSTest\POSTest\Views\Products\Index.cshtml"
  
    ViewData["Title"] = "Products";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""page-header d-md-flex justify-content-between"">
    <div>
        <h3>Users</h3>
        <nav aria-label=""breadcrumb"" class=""d-flex align-items-start"">
            <ol class=""breadcrumb"">
                <li class=""breadcrumb-item"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8c0e6c8b75b78c36cde13d6e08368ffad124dba04028", async() => {
                WriteLiteral("Products list");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
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
            </ol>
        </nav>
    </div>
</div>

<div class=""row"">
    <div class=""col-md-12"">
        <div class=""row"">
            <div class=""col-md-4 col-xs-6"">
                <div class=""card"">
                    <div class=""card-body"">
                        <div class=""my-3"">
                            <a href=""#"" title=""Vase"">
                                <img src=""../../assets/media/image/products/product1.png""
                                     class=""img-fluid rounded"" alt=""Vase"">
                            </a>
                        </div>
                        <div class=""text-center"">
                            <a href=""#"">
                                <h4>Cheese Burger - Small</h4>
                            </a>
                            <p>
                                <span class=""text-truncate"">1.3 BHD</span>
                            </p>
                            <div class=""mt-2"">
                           ");
            WriteLiteral(@"     <button class=""btn btn-primary add-to-card"">Add to Cart</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""col-md-4 col-xs-6"">
                <div class=""card"">
                    <div class=""card-body"">
                        <div class=""my-3"">
                            <a href=""#"" title=""Vase"">
                                <img src=""../../assets/media/image/products/product1.png""
                                     class=""img-fluid rounded"" alt=""Vase"">
                            </a>
                        </div>
                        <div class=""text-center"">
                            <a href=""#"">
                                <h4>Cheese Burger - Large</h4>
                            </a>
                            <p>
                                <span class=""text-truncate"">1.6 BHD</span>
                            </p>
                     ");
            WriteLiteral(@"       <div class=""mt-2"">
                                <button class=""btn btn-primary add-to-card"">Add to Cart</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""col-md-4 col-xs-6"">
                <div class=""card"">
                    <div class=""card-body"">
                        <div class=""my-3"">
                            <a href=""#"" title=""Vase"">
                                <img src=""../../assets/media/image/products/product1.png""
                                     class=""img-fluid rounded"" alt=""Vase"">
                            </a>
                        </div>
                        <div class=""text-center"">
                            <a href=""#"">
                                <h4>Cheese Burger - Medium</h4>
                            </a>
                            <p>
                                <span class=""text-truncate"">1.4 BHD</span>
");
            WriteLiteral(@"                            </p>
                            <div class=""mt-2"">
                                <button class=""btn btn-primary add-to-card"">Add to Cart</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>");
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