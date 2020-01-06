#pragma checksum "C:\Users\willa\Documents\GitHub\OrderingSystem\OrderingSystem\OrderingSystem\Views\Order\OrderComplete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "429c59da3784b09cc601974a0ce1ffb6c8eb2c91"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_OrderComplete), @"mvc.1.0.view", @"/Views/Order/OrderComplete.cshtml")]
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
#line 2 "C:\Users\willa\Documents\GitHub\OrderingSystem\OrderingSystem\OrderingSystem\Views\_ViewImports.cshtml"
using OrderingSystem.Models.Database.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\willa\Documents\GitHub\OrderingSystem\OrderingSystem\OrderingSystem\Views\_ViewImports.cshtml"
using OrderingSystem.Models.Ordering;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\willa\Documents\GitHub\OrderingSystem\OrderingSystem\OrderingSystem\Views\_ViewImports.cshtml"
using OrderingSystem.Models.AdminAccount;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"429c59da3784b09cc601974a0ce1ffb6c8eb2c91", @"/Views/Order/OrderComplete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2e9feac0d70f4d3a4f0022754af177a018eded7a", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_OrderComplete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\willa\Documents\GitHub\OrderingSystem\OrderingSystem\OrderingSystem\Views\Order\OrderComplete.cshtml"
  
    ViewData["Title"] = "Order Complete";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!--Order complete page - Showing Order number and name-->
<div class=""vertical-center"">
    <div class=""container h-100"">
        <div class=""col-12 text-center"">
            <h1 class=""font-weight-light"">Your order has been placed.</h1>
            <p class=""lead"">To view and edit your order, please use your name and the order number:</p>
            <h3 class=""font-weight-normal"">Order Number: <b>");
#nullable restore
#line 11 "C:\Users\willa\Documents\GitHub\OrderingSystem\OrderingSystem\OrderingSystem\Views\Order\OrderComplete.cshtml"
                                                       Write(ViewData["OrderNo"].ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></h3>\r\n            <h3 class=\"font-weight-normal\">Name: <b>");
#nullable restore
#line 12 "C:\Users\willa\Documents\GitHub\OrderingSystem\OrderingSystem\OrderingSystem\Views\Order\OrderComplete.cshtml"
                                               Write(ViewData["OrderName"].ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></h3>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591