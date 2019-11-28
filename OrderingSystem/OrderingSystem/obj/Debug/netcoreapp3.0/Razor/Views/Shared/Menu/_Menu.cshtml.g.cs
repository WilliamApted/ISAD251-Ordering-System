#pragma checksum "C:\Users\willa\Documents\GitHub\OrderingSystem\OrderingSystem\OrderingSystem\Views\Shared\Menu\_Menu.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a5a15892a6825e4898a1b590b21b11fc5f474a0b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Menu__Menu), @"mvc.1.0.view", @"/Views/Shared/Menu/_Menu.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a5a15892a6825e4898a1b590b21b11fc5f474a0b", @"/Views/Shared/Menu/_Menu.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f3ae2334b05b4c42c98a8d4a962711759145560b", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Menu__Menu : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Item>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<!--Used for showing the full menu. Will iterate through each item and display in a grid -->
<div class=""btn-group flex-wrap m-2"" data-toggle=""buttons"">
    
    <button class=""btn btn-light btn-lg"" type=""button"">Drinks</button>
    <button class=""btn btn-light btn-lg"" type=""button"">Snacks</button>

</div>

<div class=""row flex-column flex-md-row no-gutter"">
    <div class=""col-sm-9 col-lg-9"">
        <div class=""row no-gutter"">
");
#nullable restore
#line 13 "C:\Users\willa\Documents\GitHub\OrderingSystem\OrderingSystem\OrderingSystem\Views\Shared\Menu\_Menu.cshtml"
             foreach (var item in Model)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\willa\Documents\GitHub\OrderingSystem\OrderingSystem\OrderingSystem\Views\Shared\Menu\_Menu.cshtml"
           Write(await Html.PartialAsync("/Views/Shared/Menu/_MenuItem.cshtml", item));

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\willa\Documents\GitHub\OrderingSystem\OrderingSystem\OrderingSystem\Views\Shared\Menu\_Menu.cshtml"
                                                                                     
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Item>> Html { get; private set; }
    }
}
#pragma warning restore 1591
