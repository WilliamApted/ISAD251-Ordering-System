#pragma checksum "C:\Users\willa\Documents\GitHub\OrderingSystem\OrderingSystem\OrderingSystem\Views\Shared\Menu\_MenuItem.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f52fbecd0e71e7f2b4168232bc5e4da60029f5fe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Menu__MenuItem), @"mvc.1.0.view", @"/Views/Shared/Menu/_MenuItem.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f52fbecd0e71e7f2b4168232bc5e4da60029f5fe", @"/Views/Shared/Menu/_MenuItem.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f3ae2334b05b4c42c98a8d4a962711759145560b", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Menu__MenuItem : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Item>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"col-sm-12 col-md-6 col-lg-4 mb-3\">\r\n    <div class=\"card mb-3 h-100\">\r\n        <img class=\"card-img-top\"");
            BeginWriteAttribute("src", " src=\"", 131, "\"", 152, 1);
#nullable restore
#line 5 "C:\Users\willa\Documents\GitHub\OrderingSystem\OrderingSystem\OrderingSystem\Views\Shared\Menu\_MenuItem.cshtml"
WriteAttributeValue("", 137, Model.ImageUrl, 137, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 153, "\"", 170, 1);
#nullable restore
#line 5 "C:\Users\willa\Documents\GitHub\OrderingSystem\OrderingSystem\OrderingSystem\Views\Shared\Menu\_MenuItem.cshtml"
WriteAttributeValue("", 159, Model.Name, 159, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n        <div class=\"card-body\">\r\n            <h5 class=\"card-title\">\r\n                ");
#nullable restore
#line 8 "C:\Users\willa\Documents\GitHub\OrderingSystem\OrderingSystem\OrderingSystem\Views\Shared\Menu\_MenuItem.cshtml"
           Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - £");
#nullable restore
#line 8 "C:\Users\willa\Documents\GitHub\OrderingSystem\OrderingSystem\OrderingSystem\Views\Shared\Menu\_MenuItem.cshtml"
                          Write(Model.Price.ToString("0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </h5>\r\n            <p class=\"card-text\">\r\n                ");
#nullable restore
#line 11 "C:\Users\willa\Documents\GitHub\OrderingSystem\OrderingSystem\OrderingSystem\Views\Shared\Menu\_MenuItem.cshtml"
           Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </p>\r\n        </div>\r\n        <div></div>\r\n        <div");
            BeginWriteAttribute("class", " class=\"", 463, "\"", 471, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n            <button");
            BeginWriteAttribute("onclick", " onclick=\"", 494, "\"", 527, 3);
            WriteAttributeValue("", 504, "UpdateBasket(", 504, 13, true);
#nullable restore
#line 16 "C:\Users\willa\Documents\GitHub\OrderingSystem\OrderingSystem\OrderingSystem\Views\Shared\Menu\_MenuItem.cshtml"
WriteAttributeValue("", 517, Model.Id, 517, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 526, ")", 526, 1, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary btn-block\">Add to order</button>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Item> Html { get; private set; }
    }
}
#pragma warning restore 1591
