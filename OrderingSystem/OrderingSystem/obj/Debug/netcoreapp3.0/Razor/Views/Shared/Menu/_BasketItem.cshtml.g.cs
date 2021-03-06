#pragma checksum "C:\Users\willa\Documents\GitHub\OrderingSystem\OrderingSystem\OrderingSystem\Views\Shared\Menu\_BasketItem.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f481fb48d7bf74291a769db0b457fe480451d715"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Menu__BasketItem), @"mvc.1.0.view", @"/Views/Shared/Menu/_BasketItem.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f481fb48d7bf74291a769db0b457fe480451d715", @"/Views/Shared/Menu/_BasketItem.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2e9feac0d70f4d3a4f0022754af177a018eded7a", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Menu__BasketItem : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ItemDetailsModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<!--Basket item - Showing quantity and allowing addition/removal.-->\r\n<div class=\"card\">\r\n    <div class=\"row no-gutters\">\r\n        <div class=\"col-3\" >\r\n            <img class=\"w-100 h-100\" style=\"object-fit: cover;\"");
            BeginWriteAttribute("src", " src=\"", 244, "\"", 263, 1);
#nullable restore
#line 7 "C:\Users\willa\Documents\GitHub\OrderingSystem\OrderingSystem\OrderingSystem\Views\Shared\Menu\_BasketItem.cshtml"
WriteAttributeValue("", 250, Model.ImgUrl, 250, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 264, "\"", 281, 1);
#nullable restore
#line 7 "C:\Users\willa\Documents\GitHub\OrderingSystem\OrderingSystem\OrderingSystem\Views\Shared\Menu\_BasketItem.cshtml"
WriteAttributeValue("", 270, Model.Name, 270, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n        </div>\r\n        <div class=\"col-6\">\r\n            <div class=\"card-block px-1\">\r\n                <h5 class=\"card-title\">");
#nullable restore
#line 11 "C:\Users\willa\Documents\GitHub\OrderingSystem\OrderingSystem\OrderingSystem\Views\Shared\Menu\_BasketItem.cshtml"
                                  Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                <div class=\"btn-group mr-2\" role=\"group\"");
            BeginWriteAttribute("aria-label", " aria-label=\"", 486, "\"", 525, 4);
#nullable restore
#line 12 "C:\Users\willa\Documents\GitHub\OrderingSystem\OrderingSystem\OrderingSystem\Views\Shared\Menu\_BasketItem.cshtml"
WriteAttributeValue("", 499, Model.Name, 499, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 510, "Add", 511, 4, true);
            WriteAttributeValue(" ", 514, "and", 515, 4, true);
            WriteAttributeValue(" ", 518, "Remove", 519, 7, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <button type=\"button\"");
            BeginWriteAttribute("onclick", " onclick=\"", 570, "\"", 611, 3);
            WriteAttributeValue("", 580, "RemoveFromBasket(", 580, 17, true);
#nullable restore
#line 13 "C:\Users\willa\Documents\GitHub\OrderingSystem\OrderingSystem\OrderingSystem\Views\Shared\Menu\_BasketItem.cshtml"
WriteAttributeValue("", 597, Model.ItemId, 597, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 610, ")", 610, 1, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-light font-weight-bolder\">-</button>\r\n                    <a class=\"btn btn-light font-weight-bolder\">");
#nullable restore
#line 14 "C:\Users\willa\Documents\GitHub\OrderingSystem\OrderingSystem\OrderingSystem\Views\Shared\Menu\_BasketItem.cshtml"
                                                           Write(Model.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                    <button type=\"button\"");
            BeginWriteAttribute("onclick", " onclick=\"", 792, "\"", 828, 3);
            WriteAttributeValue("", 802, "AddToBasket(", 802, 12, true);
#nullable restore
#line 15 "C:\Users\willa\Documents\GitHub\OrderingSystem\OrderingSystem\OrderingSystem\Views\Shared\Menu\_BasketItem.cshtml"
WriteAttributeValue("", 814, Model.ItemId, 814, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 827, ")", 827, 1, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-light font-weight-bolder\">+</button>\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <div class=\"col-3 text-right\">\r\n            <h6>£");
#nullable restore
#line 20 "C:\Users\willa\Documents\GitHub\OrderingSystem\OrderingSystem\OrderingSystem\Views\Shared\Menu\_BasketItem.cshtml"
             Write((Model.Quantity * Model.Price).ToString("#.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h6>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ItemDetailsModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
