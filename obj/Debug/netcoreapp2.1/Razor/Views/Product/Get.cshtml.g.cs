#pragma checksum "F:\projects\ZadaniePraca\ZadaniePraca\Views\Product\Get.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7e14920d44bbd20f2976c0b34ece9a26cd437136"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_Get), @"mvc.1.0.view", @"/Views/Product/Get.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Product/Get.cshtml", typeof(AspNetCore.Views_Product_Get))]
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
#line 1 "F:\projects\ZadaniePraca\ZadaniePraca\Views\_ViewImports.cshtml"
using ZadaniePraca;

#line default
#line hidden
#line 2 "F:\projects\ZadaniePraca\ZadaniePraca\Views\_ViewImports.cshtml"
using ZadaniePraca.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7e14920d44bbd20f2976c0b34ece9a26cd437136", @"/Views/Product/Get.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e9ed09c56ca415e8a3a6ae8535c50252f1454305", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_Get : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ZadaniePraca.Models.Product>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(36, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "F:\projects\ZadaniePraca\ZadaniePraca\Views\Product\Get.cshtml"
  
    ViewData["Title"] = "Get certain product";

#line default
#line hidden
            BeginContext(93, 73, true);
            WriteLiteral("\r\n<h2>Get certain product</h2>\r\n\r\n<p>Here\'s your product name and price: ");
            EndContext();
            BeginContext(167, 10, false);
#line 9 "F:\projects\ZadaniePraca\ZadaniePraca\Views\Product\Get.cshtml"
                                  Write(Model.Name);

#line default
#line hidden
            EndContext();
            BeginContext(177, 9, true);
            WriteLiteral(" at cost ");
            EndContext();
            BeginContext(187, 11, false);
#line 9 "F:\projects\ZadaniePraca\ZadaniePraca\Views\Product\Get.cshtml"
                                                      Write(Model.Price);

#line default
#line hidden
            EndContext();
            BeginContext(198, 10, true);
            WriteLiteral("  PLN!</p>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ZadaniePraca.Models.Product> Html { get; private set; }
    }
}
#pragma warning restore 1591
