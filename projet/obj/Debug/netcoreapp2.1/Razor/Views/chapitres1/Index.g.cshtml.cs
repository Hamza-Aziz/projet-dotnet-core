#pragma checksum "C:\Users\azerty\Documents\GitHub\projet-dotnet-core\projet\Views\chapitres1\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "68973393804f8d5fe390076fbade26fc02b6ba3d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_chapitres1_Index), @"mvc.1.0.view", @"/Views/chapitres1/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/chapitres1/Index.cshtml", typeof(AspNetCore.Views_chapitres1_Index))]
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
#line 1 "C:\Users\azerty\Documents\GitHub\projet-dotnet-core\projet\Views\_ViewImports.cshtml"
using projet;

#line default
#line hidden
#line 2 "C:\Users\azerty\Documents\GitHub\projet-dotnet-core\projet\Views\_ViewImports.cshtml"
using projet.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"68973393804f8d5fe390076fbade26fc02b6ba3d", @"/Views/chapitres1/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fcc0a35fdeccc1df7504aa9b37c5d3fee80035b7", @"/Views/_ViewImports.cshtml")]
    public class Views_chapitres1_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<projet.Models.chapitre>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(44, 6, true);
            WriteLiteral("\r\n\r\n\r\n");
            EndContext();
#line 5 "C:\Users\azerty\Documents\GitHub\projet-dotnet-core\projet\Views\chapitres1\Index.cshtml"
  
    ViewData["Title"] = "Index"; Layout = "~/Views/Shared/_LayoutEnseignant.cshtml";


#line default
#line hidden
            BeginContext(145, 136, true);
            WriteLiteral("\r\n<h2>Index</h2>\r\n\r\n<br />  <br />  \r\n<table class=\"table table-striped\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(282, 40, false);
#line 17 "C:\Users\azerty\Documents\GitHub\projet-dotnet-core\projet\Views\chapitres1\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.type));

#line default
#line hidden
            EndContext();
            BeginContext(322, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(378, 43, false);
#line 20 "C:\Users\azerty\Documents\GitHub\projet-dotnet-core\projet\Views\chapitres1\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.contenu));

#line default
#line hidden
            EndContext();
            BeginContext(421, 73, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(495, 46, false);
#line 24 "C:\Users\azerty\Documents\GitHub\projet-dotnet-core\projet\Views\chapitres1\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.date_depot));

#line default
#line hidden
            EndContext();
            BeginContext(541, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(597, 47, false);
#line 27 "C:\Users\azerty\Documents\GitHub\projet-dotnet-core\projet\Views\chapitres1\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.responsable));

#line default
#line hidden
            EndContext();
            BeginContext(644, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(700, 42, false);
#line 30 "C:\Users\azerty\Documents\GitHub\projet-dotnet-core\projet\Views\chapitres1\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Module));

#line default
#line hidden
            EndContext();
            BeginContext(742, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 36 "C:\Users\azerty\Documents\GitHub\projet-dotnet-core\projet\Views\chapitres1\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(877, 60, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(938, 39, false);
#line 40 "C:\Users\azerty\Documents\GitHub\projet-dotnet-core\projet\Views\chapitres1\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.type));

#line default
#line hidden
            EndContext();
            BeginContext(977, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1045, 42, false);
#line 43 "C:\Users\azerty\Documents\GitHub\projet-dotnet-core\projet\Views\chapitres1\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.contenu));

#line default
#line hidden
            EndContext();
            BeginContext(1087, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1155, 45, false);
#line 46 "C:\Users\azerty\Documents\GitHub\projet-dotnet-core\projet\Views\chapitres1\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.date_depot));

#line default
#line hidden
            EndContext();
            BeginContext(1200, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1268, 46, false);
#line 49 "C:\Users\azerty\Documents\GitHub\projet-dotnet-core\projet\Views\chapitres1\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.responsable));

#line default
#line hidden
            EndContext();
            BeginContext(1314, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1382, 49, false);
#line 52 "C:\Users\azerty\Documents\GitHub\projet-dotnet-core\projet\Views\chapitres1\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Module.nom_mod));

#line default
#line hidden
            EndContext();
            BeginContext(1431, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1499, 109, false);
#line 55 "C:\Users\azerty\Documents\GitHub\projet-dotnet-core\projet\Views\chapitres1\Index.cshtml"
               Write(Html.ActionLink("Edit", "Edit", new { id = item.id_chap }, new { @class = "btn btn-primary btn-icon-split" }));

#line default
#line hidden
            EndContext();
            BeginContext(1608, 22, true);
            WriteLiteral("\r\n                    ");
            EndContext();
            BeginContext(1631, 112, false);
#line 56 "C:\Users\azerty\Documents\GitHub\projet-dotnet-core\projet\Views\chapitres1\Index.cshtml"
               Write(Html.ActionLink("Details", "Details", new { id = item.id_chap }, new { @class = "btn btn-info btn-icon-split" }));

#line default
#line hidden
            EndContext();
            BeginContext(1743, 22, true);
            WriteLiteral("\r\n                    ");
            EndContext();
            BeginContext(1766, 112, false);
#line 57 "C:\Users\azerty\Documents\GitHub\projet-dotnet-core\projet\Views\chapitres1\Index.cshtml"
               Write(Html.ActionLink("Delete", "Delete", new { id = item.id_chap }, new { @class = "btn btn-danger btn-icon-split" }));

#line default
#line hidden
            EndContext();
            BeginContext(1878, 46, true);
            WriteLiteral("\r\n\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 61 "C:\Users\azerty\Documents\GitHub\projet-dotnet-core\projet\Views\chapitres1\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(1935, 26, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<projet.Models.chapitre>> Html { get; private set; }
    }
}
#pragma warning restore 1591
