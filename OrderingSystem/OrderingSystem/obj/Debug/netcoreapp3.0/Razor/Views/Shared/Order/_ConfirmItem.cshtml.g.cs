#pragma checksum "C:\Users\willa\Documents\GitHub\OrderingSystem\OrderingSystem\OrderingSystem\Views\Shared\Order\_ConfirmItem.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "abdaa9d827699facd6c8497cef264c26a856e4eb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Order__ConfirmItem), @"mvc.1.0.view", @"/Views/Shared/Order/_ConfirmItem.cshtml")]
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
using OrderingSystem.Models.Database;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\willa\Documents\GitHub\OrderingSystem\OrderingSystem\OrderingSystem\Views\_ViewImports.cshtml"
using OrderingSystem.Models.Items;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\willa\Documents\GitHub\OrderingSystem\OrderingSystem\OrderingSystem\Views\_ViewImports.cshtml"
using OrderingSystem.Models.AdminAccount;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"abdaa9d827699facd6c8497cef264c26a856e4eb", @"/Views/Shared/Order/_ConfirmItem.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f3ae2334b05b4c42c98a8d4a962711759145560b", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Order__ConfirmItem : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BasketItemModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"card mb-3\">\r\n    <div class=\"row no-gutters\">\r\n        <div class=\"col-3\">\r\n            <img class=\"h-100 w-100\"");
            BeginWriteAttribute("src", " src=\"", 148, "\"", 167, 1);
#nullable restore
#line 5 "C:\Users\willa\Documents\GitHub\OrderingSystem\OrderingSystem\OrderingSystem\Views\Shared\Order\_ConfirmItem.cshtml"
WriteAttributeValue("", 154, Model.ImgUrl, 154, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"...\">\r\n        </div>\r\n        <div class=\"col-9\">\r\n            <div class=\"card-body\">\r\n                <h5 class=\"card-title\">");
#nullable restore
#line 9 "C:\Users\willa\Documents\GitHub\OrderingSystem\OrderingSystem\OrderingSystem\Views\Shared\Order\_ConfirmItem.cshtml"
                                  Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                <p class=\"card-text\"></p>\r\n                <h4 class=\"text-right\">£");
#nullable restore
#line 11 "C:\Users\willa\Documents\GitHub\OrderingSystem\OrderingSystem\OrderingSystem\Views\Shared\Order\_ConfirmItem.cshtml"
                                    Write((Model.Quantity * Model.Price).ToString("#.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h4>\r\n                <div class=\"btn-group mr-2\" role=\"group\"");
            BeginWriteAttribute("aria-label", " aria-label=\"", 517, "\"", 556, 4);
#nullable restore
#line 12 "C:\Users\willa\Documents\GitHub\OrderingSystem\OrderingSystem\OrderingSystem\Views\Shared\Order\_ConfirmItem.cshtml"
WriteAttributeValue("", 530, Model.Name, 530, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 541, "Add", 542, 4, true);
            WriteAttributeValue(" ", 545, "and", 546, 4, true);
            WriteAttributeValue(" ", 549, "Remove", 550, 7, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <a class=\"btn btn-outline-dark\">Quantity</a>\r\n                    <a class=\"btn btn-outline-dark\">");
#nullable restore
#line 14 "C:\Users\willa\Documents\GitHub\OrderingSystem\OrderingSystem\OrderingSystem\Views\Shared\Order\_ConfirmItem.cshtml"
                                               Write(Model.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BasketItemModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
