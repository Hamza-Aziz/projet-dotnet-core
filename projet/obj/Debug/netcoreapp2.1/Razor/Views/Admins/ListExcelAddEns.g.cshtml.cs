#pragma checksum "D:\s8\Version git\projet-dotnet-core\projet\Views\Admins\ListExcelAddEns.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "38a622ce97a029830dec20807312739bbf569560"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admins_ListExcelAddEns), @"mvc.1.0.view", @"/Views/Admins/ListExcelAddEns.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Admins/ListExcelAddEns.cshtml", typeof(AspNetCore.Views_Admins_ListExcelAddEns))]
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
#line 1 "D:\s8\Version git\projet-dotnet-core\projet\Views\_ViewImports.cshtml"
using projet;

#line default
#line hidden
#line 2 "D:\s8\Version git\projet-dotnet-core\projet\Views\_ViewImports.cshtml"
using projet.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"38a622ce97a029830dec20807312739bbf569560", @"/Views/Admins/ListExcelAddEns.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fcc0a35fdeccc1df7504aa9b37c5d3fee80035b7", @"/Views/_ViewImports.cshtml")]
    public class Views_Admins_ListExcelAddEns : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<projet.Models.Enseignant>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(46, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\s8\Version git\projet-dotnet-core\projet\Views\Admins\ListExcelAddEns.cshtml"
  
    Layout = "_LayoutAdmin";

#line default
#line hidden
            BeginContext(85, 126, true);
            WriteLiteral("\r\n\r\n\r\n<section id=\"main-content\">\r\n    <section class=\"wrapper\">\r\n        <h3 class=\"bg-success\"><i class=\"fa fa-list  \"></i> ");
            EndContext();
            BeginContext(212, 11, false);
#line 11 "D:\s8\Version git\projet-dotnet-core\projet\Views\Admins\ListExcelAddEns.cshtml"
                                                       Write(ViewBag.msg);

#line default
#line hidden
            EndContext();
            BeginContext(223, 771, true);
            WriteLiteral(@"</h3>
        <div class=""row"">
            <div class=""col-md-12"">
                <div class=""content-panel"">
                    <h4><i class=""fa fa-list  ""></i> The list of added teachers</h4>
                    <hr>
                    <table class=""table"">
                        <thead>
                            <tr class=""bg-success"">

                                <th>First Name</th>
                                <th>Last Name</th>
                                <th>Username</th>
                                <th>Password</th>
                                <th>Email</th>
                                <th>Number Phone</th>
                            </tr>
                        </thead>
                        <tbody>
");
            EndContext();
#line 30 "D:\s8\Version git\projet-dotnet-core\projet\Views\Admins\ListExcelAddEns.cshtml"
                             foreach (var item in Model)
                            {

#line default
#line hidden
            BeginContext(1083, 120, true);
            WriteLiteral("                                <tr>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(1204, 38, false);
#line 34 "D:\s8\Version git\projet-dotnet-core\projet\Views\Admins\ListExcelAddEns.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.nom));

#line default
#line hidden
            EndContext();
            BeginContext(1242, 127, true);
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(1370, 41, false);
#line 37 "D:\s8\Version git\projet-dotnet-core\projet\Views\Admins\ListExcelAddEns.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.prenom));

#line default
#line hidden
            EndContext();
            BeginContext(1411, 127, true);
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(1539, 43, false);
#line 40 "D:\s8\Version git\projet-dotnet-core\projet\Views\Admins\ListExcelAddEns.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.username));

#line default
#line hidden
            EndContext();
            BeginContext(1582, 127, true);
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(1710, 38, false);
#line 43 "D:\s8\Version git\projet-dotnet-core\projet\Views\Admins\ListExcelAddEns.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.mdp));

#line default
#line hidden
            EndContext();
            BeginContext(1748, 127, true);
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(1876, 40, false);
#line 46 "D:\s8\Version git\projet-dotnet-core\projet\Views\Admins\ListExcelAddEns.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.email));

#line default
#line hidden
            EndContext();
            BeginContext(1916, 127, true);
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(2044, 44, false);
#line 49 "D:\s8\Version git\projet-dotnet-core\projet\Views\Admins\ListExcelAddEns.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.telephone));

#line default
#line hidden
            EndContext();
            BeginContext(2088, 88, true);
            WriteLiteral("\r\n                                    </td>\r\n\r\n\r\n                                </tr>\r\n");
            EndContext();
#line 54 "D:\s8\Version git\projet-dotnet-core\projet\Views\Admins\ListExcelAddEns.cshtml"
                            }

#line default
#line hidden
            BeginContext(2207, 154, true);
            WriteLiteral("\r\n                        </tbody>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </section>\r\n</section>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<projet.Models.Enseignant>> Html { get; private set; }
    }
}
#pragma warning restore 1591
