#pragma checksum "C:\Users\willa\Documents\GitHub\OrderingSystem\OrderingSystem\OrderingSystem\Views\Shared\Admin\_Item.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a27ba5ed800ba29f5fc8d6ddc20a1bd1916cdcd1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Admin__Item), @"mvc.1.0.view", @"/Views/Shared/Admin/_Item.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a27ba5ed800ba29f5fc8d6ddc20a1bd1916cdcd1", @"/Views/Shared/Admin/_Item.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7e498e080dbca134f0f95d4ffb519c98deeb7518", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Admin__Item : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Item>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"col-sm-12 col-md-4 col-lg-3 mb-3\">\r\n    <div class=\"card mb-3 h-100\">\r\n        <img class=\"card-img-top\"");
            BeginWriteAttribute("src", " src=\"", 131, "\"", 152, 1);
#nullable restore
#line 5 "C:\Users\willa\Documents\GitHub\OrderingSystem\OrderingSystem\OrderingSystem\Views\Shared\Admin\_Item.cshtml"
WriteAttributeValue("", 137, Model.ImageUrl, 137, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 153, "\"", 170, 1);
#nullable restore
#line 5 "C:\Users\willa\Documents\GitHub\OrderingSystem\OrderingSystem\OrderingSystem\Views\Shared\Admin\_Item.cshtml"
WriteAttributeValue("", 159, Model.Name, 159, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n        <div class=\"card-body\">\r\n            <h5 class=\"card-title\">\r\n                ");
#nullable restore
#line 8 "C:\Users\willa\Documents\GitHub\OrderingSystem\OrderingSystem\OrderingSystem\Views\Shared\Admin\_Item.cshtml"
           Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - £");
#nullable restore
#line 8 "C:\Users\willa\Documents\GitHub\OrderingSystem\OrderingSystem\OrderingSystem\Views\Shared\Admin\_Item.cshtml"
                          Write(Model.Price.ToString("0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </h5>\r\n            <p class=\"card-text\">\r\n                ");
#nullable restore
#line 11 "C:\Users\willa\Documents\GitHub\OrderingSystem\OrderingSystem\OrderingSystem\Views\Shared\Admin\_Item.cshtml"
           Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </p>\r\n        </div>\r\n        <div></div>\r\n        <div>\r\n");
#nullable restore
#line 16 "C:\Users\willa\Documents\GitHub\OrderingSystem\OrderingSystem\OrderingSystem\Views\Shared\Admin\_Item.cshtml"
             if (Model.Available == false)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <button");
            BeginWriteAttribute("onclick", " onclick=\"", 548, "\"", 577, 3);
            WriteAttributeValue("", 558, "EditItem(", 558, 9, true);
#nullable restore
#line 18 "C:\Users\willa\Documents\GitHub\OrderingSystem\OrderingSystem\OrderingSystem\Views\Shared\Admin\_Item.cshtml"
WriteAttributeValue("", 567, Model.Id, 567, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 576, ")", 576, 1, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger btn-block\">Withdrawn - Edit Item</button>\r\n");
#nullable restore
#line 19 "C:\Users\willa\Documents\GitHub\OrderingSystem\OrderingSystem\OrderingSystem\Views\Shared\Admin\_Item.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <button");
            BeginWriteAttribute("onclick", " onclick=\"", 715, "\"", 744, 3);
            WriteAttributeValue("", 725, "EditItem(", 725, 9, true);
#nullable restore
#line 22 "C:\Users\willa\Documents\GitHub\OrderingSystem\OrderingSystem\OrderingSystem\Views\Shared\Admin\_Item.cshtml"
WriteAttributeValue("", 734, Model.Id, 734, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 743, ")", 743, 1, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary btn-block\">Edit Item</button>\r\n");
#nullable restore
#line 23 "C:\Users\willa\Documents\GitHub\OrderingSystem\OrderingSystem\OrderingSystem\Views\Shared\Admin\_Item.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>");
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