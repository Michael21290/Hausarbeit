#pragma checksum "C:\Users\gerbm\Desktop\Hausrabeit\Hausarbeit_StreamingDienst\StreamingDienst\Pages\AdminAnsicht\FolgenListe.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "427d942a6f75fb15894a1697e1cf359b8b098a3a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(StreamingDienst.Pages.AdminAnsicht.Pages_AdminAnsicht_FolgenListe), @"mvc.1.0.razor-page", @"/Pages/AdminAnsicht/FolgenListe.cshtml")]
namespace StreamingDienst.Pages.AdminAnsicht
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
#line 1 "C:\Users\gerbm\Desktop\Hausrabeit\Hausarbeit_StreamingDienst\StreamingDienst\Pages\_ViewImports.cshtml"
using StreamingDienst;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"427d942a6f75fb15894a1697e1cf359b8b098a3a", @"/Pages/AdminAnsicht/FolgenListe.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"49b041a89ebc3c550782eaa3f8d45cc79da87672", @"/Pages/_ViewImports.cshtml")]
    public class Pages_AdminAnsicht_FolgenListe : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Folgen/FolgeHinzufuegen", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./SerienListe", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\gerbm\Desktop\Hausrabeit\Hausarbeit_StreamingDienst\StreamingDienst\Pages\AdminAnsicht\FolgenListe.cshtml"
  
    ViewData["Title"] = "FolgenListe";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Serie: ");
#nullable restore
#line 8 "C:\Users\gerbm\Desktop\Hausrabeit\Hausarbeit_StreamingDienst\StreamingDienst\Pages\AdminAnsicht\FolgenListe.cshtml"
      Write(Html.DisplayFor(modelItem => Model.Serie.SerienTitel));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n<hr />\r\n<br />\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "427d942a6f75fb15894a1697e1cf359b8b098a3a4285", async() => {
                WriteLiteral("Neue Folge hinzufügen");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-SerienID", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 12 "C:\Users\gerbm\Desktop\Hausrabeit\Hausarbeit_StreamingDienst\StreamingDienst\Pages\AdminAnsicht\FolgenListe.cshtml"
                                                    WriteLiteral(Model.Serie.ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["SerienID"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-SerienID", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["SerienID"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 12 "C:\Users\gerbm\Desktop\Hausrabeit\Hausarbeit_StreamingDienst\StreamingDienst\Pages\AdminAnsicht\FolgenListe.cshtml"
                                                                                        WriteLiteral(Model.Admin.ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["AdminID"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-AdminID", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["AdminID"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                Titel\r\n            </th>\r\n            <th>\r\n                Länge\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 24 "C:\Users\gerbm\Desktop\Hausrabeit\Hausarbeit_StreamingDienst\StreamingDienst\Pages\AdminAnsicht\FolgenListe.cshtml"
           Write(Html.DisplayNameFor(model => model.Folge[0].Kaufpreis));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 27 "C:\Users\gerbm\Desktop\Hausrabeit\Hausarbeit_StreamingDienst\StreamingDienst\Pages\AdminAnsicht\FolgenListe.cshtml"
           Write(Html.DisplayNameFor(model => model.Folge[0].Leihpreis));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 33 "C:\Users\gerbm\Desktop\Hausrabeit\Hausarbeit_StreamingDienst\StreamingDienst\Pages\AdminAnsicht\FolgenListe.cshtml"
 foreach (var item in Model.Folge.Where(x => x.FSerienID.ID == Model.Serie.ID)) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 36 "C:\Users\gerbm\Desktop\Hausrabeit\Hausarbeit_StreamingDienst\StreamingDienst\Pages\AdminAnsicht\FolgenListe.cshtml"
           Write(Html.DisplayFor(modelItem => item.FolgenTitel));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 39 "C:\Users\gerbm\Desktop\Hausrabeit\Hausarbeit_StreamingDienst\StreamingDienst\Pages\AdminAnsicht\FolgenListe.cshtml"
           Write(Html.DisplayFor(modelItem => item.FolgenLaenge));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 42 "C:\Users\gerbm\Desktop\Hausrabeit\Hausarbeit_StreamingDienst\StreamingDienst\Pages\AdminAnsicht\FolgenListe.cshtml"
           Write(Html.DisplayFor(modelItem => item.Kaufpreis));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 45 "C:\Users\gerbm\Desktop\Hausrabeit\Hausarbeit_StreamingDienst\StreamingDienst\Pages\AdminAnsicht\FolgenListe.cshtml"
           Write(Html.DisplayFor(modelItem => item.Leihpreis));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 48 "C:\Users\gerbm\Desktop\Hausrabeit\Hausarbeit_StreamingDienst\StreamingDienst\Pages\AdminAnsicht\FolgenListe.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "427d942a6f75fb15894a1697e1cf359b8b098a3a10344", async() => {
                WriteLiteral("Zurück");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-AdminID", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 51 "C:\Users\gerbm\Desktop\Hausrabeit\Hausarbeit_StreamingDienst\StreamingDienst\Pages\AdminAnsicht\FolgenListe.cshtml"
                                   WriteLiteral(Model.Admin.ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["AdminID"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-AdminID", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["AdminID"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<StreamingDienst.Pages.AdminAnsicht.FolgenListeModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<StreamingDienst.Pages.AdminAnsicht.FolgenListeModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<StreamingDienst.Pages.AdminAnsicht.FolgenListeModel>)PageContext?.ViewData;
        public StreamingDienst.Pages.AdminAnsicht.FolgenListeModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591