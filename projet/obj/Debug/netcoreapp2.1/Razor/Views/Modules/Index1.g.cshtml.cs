#pragma checksum "C:\Users\azerty\Documents\GitHub\projet-dotnet-core\projet\Views\Modules\Index1.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5c37e5afb486a5418d4783848a021110847fcac7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Modules_Index1), @"mvc.1.0.view", @"/Views/Modules/Index1.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Modules/Index1.cshtml", typeof(AspNetCore.Views_Modules_Index1))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c37e5afb486a5418d4783848a021110847fcac7", @"/Views/Modules/Index1.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fcc0a35fdeccc1df7504aa9b37c5d3fee80035b7", @"/Views/_ViewImports.cshtml")]
    public class Views_Modules_Index1 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<projet.Models.Module>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(42, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 4 "C:\Users\azerty\Documents\GitHub\projet-dotnet-core\projet\Views\Modules\Index1.cshtml"
  
    ViewData["Title"] = "Index1";

    Layout = "~/Views/Shared/_LayoutEnseignant.cshtml";

#line default
#line hidden
            BeginContext(147, 220, true);
            WriteLiteral("\r\n<center>\r\n    <center>\r\n        <br /><br /><br /><br />\r\n        <h2>   Liste des chapitres  </h2>\r\n        <br />  <br />\r\n        <button class=\"btn btn-success\" style=\"margin-bottom:10px\"><i class=\"fa fa-plus\"></i>");
            EndContext();
            BeginContext(368, 47, false);
#line 15 "C:\Users\azerty\Documents\GitHub\projet-dotnet-core\projet\Views\Modules\Index1.cshtml"
                                                                                        Write(Html.ActionLink("Add Module", "Add", "Modules"));

#line default
#line hidden
            EndContext();
            BeginContext(415, 108, true);
            WriteLiteral("</button>\r\n        <button class=\"btn btn-success\" style=\"margin-bottom:10px\"><i class=\"fa fa-calendar\"></i>");
            EndContext();
            BeginContext(524, 55, false);
#line 16 "C:\Users\azerty\Documents\GitHub\projet-dotnet-core\projet\Views\Modules\Index1.cshtml"
                                                                                            Write(Html.ActionLink("Calendrier", "Calendrier", "Etudiant"));

#line default
#line hidden
            EndContext();
            BeginContext(579, 683, true);
            WriteLiteral(@"</button>

        <center>
            <table class=""table table-bordered table-hover table-striped"">
                <thead class=""thead-dark"">
                    <tr>
                        <th>
                            Nom du module
                        </th>
                        <th>
                            Id du module
                        </th>
                        <th>
                            Nom de l'enseignant
                        </th>
                        <th>
                            Niveau
                        </th>


                        <th></th>
                    </tr>
                </thead>
");
            EndContext();
#line 39 "C:\Users\azerty\Documents\GitHub\projet-dotnet-core\projet\Views\Modules\Index1.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
            BeginContext(1327, 84, true);
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(1412, 42, false);
#line 43 "C:\Users\azerty\Documents\GitHub\projet-dotnet-core\projet\Views\Modules\Index1.cshtml"
                       Write(Html.DisplayFor(modelItem => item.nom_mod));

#line default
#line hidden
            EndContext();
            BeginContext(1454, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(1546, 41, false);
#line 46 "C:\Users\azerty\Documents\GitHub\projet-dotnet-core\projet\Views\Modules\Index1.cshtml"
                       Write(Html.DisplayFor(modelItem => item.id_mod));

#line default
#line hidden
            EndContext();
            BeginContext(1587, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(1679, 49, false);
#line 49 "C:\Users\azerty\Documents\GitHub\projet-dotnet-core\projet\Views\Modules\Index1.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Enseignant.nom));

#line default
#line hidden
            EndContext();
            BeginContext(1728, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(1820, 49, false);
#line 52 "C:\Users\azerty\Documents\GitHub\projet-dotnet-core\projet\Views\Modules\Index1.cshtml"
                       Write(Html.DisplayFor(modelItem => item.niveau.nom_niv));

#line default
#line hidden
            EndContext();
            BeginContext(1869, 188, true);
            WriteLiteral("\r\n                        </td>\r\n\r\n\r\n\r\n                        <td>\r\n                            <button class=\"btn btn-warning\" style=\"margin-left:5px\"><i class=\"fas fa-info-circle\"></i> ");
            EndContext();
            BeginContext(2058, 63, false);
#line 58 "C:\Users\azerty\Documents\GitHub\projet-dotnet-core\projet\Views\Modules\Index1.cshtml"
                                                                                                                  Write(Html.ActionLink("Details", "Details", new { id = item.id_mod }));

#line default
#line hidden
            EndContext();
            BeginContext(2121, 126, true);
            WriteLiteral(" </button>\r\n\r\n                            <button class=\"btn btn-warning\" style=\"margin-left:5px\"><i class=\"fas fa-plus\"></i> ");
            EndContext();
            BeginContext(2248, 87, false);
#line 60 "C:\Users\azerty\Documents\GitHub\projet-dotnet-core\projet\Views\Modules\Index1.cshtml"
                                                                                                           Write(Html.ActionLink("Ajouter un chapitre", "Create", "chapitres", new { id = item.id_mod }));

#line default
#line hidden
            EndContext();
            BeginContext(2335, 72, true);
            WriteLiteral(" </button>\r\n\r\n                        </td>\r\n                    </tr>\r\n");
            EndContext();
#line 64 "C:\Users\azerty\Documents\GitHub\projet-dotnet-core\projet\Views\Modules\Index1.cshtml"
                }

#line default
#line hidden
            BeginContext(2426, 73, true);
            WriteLiteral("            </table>\r\n        </center>\r\n    </center>\r\n\r\n\r\n</center>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<projet.Models.Module>> Html { get; private set; }
    }
}
#pragma warning restore 1591