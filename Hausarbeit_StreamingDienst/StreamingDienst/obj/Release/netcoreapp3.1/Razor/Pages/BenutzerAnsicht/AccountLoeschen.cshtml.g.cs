#pragma checksum "C:\Users\gerbm\Desktop\Hausrabeit\Hausarbeit_StreamingDienst\StreamingDienst\Pages\BenutzerAnsicht\AccountLoeschen.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9afd619d054b98c0b9b5c6d4318e2d3dba179f6c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(StreamingDienst.Pages.BenutzerAnsicht.Pages_BenutzerAnsicht_AccountLoeschen), @"mvc.1.0.razor-page", @"/Pages/BenutzerAnsicht/AccountLoeschen.cshtml")]
namespace StreamingDienst.Pages.BenutzerAnsicht
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9afd619d054b98c0b9b5c6d4318e2d3dba179f6c", @"/Pages/BenutzerAnsicht/AccountLoeschen.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"49b041a89ebc3c550782eaa3f8d45cc79da87672", @"/Pages/_ViewImports.cshtml")]
    public class Pages_BenutzerAnsicht_AccountLoeschen : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\gerbm\Desktop\Hausrabeit\Hausarbeit_StreamingDienst\StreamingDienst\Pages\BenutzerAnsicht\AccountLoeschen.cshtml"
  
    ViewData["Title"] = "Account Löschen";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Account Löschen</h1>\r\n\r\n<h3>Sind Sie sicher, dass Sie Ihren Account löschen möchten?</h3>\r\n<div>\r\n    <hr />\r\n    <br />\r\n    <br />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 17 "C:\Users\gerbm\Desktop\Hausrabeit\Hausarbeit_StreamingDienst\StreamingDienst\Pages\BenutzerAnsicht\AccountLoeschen.cshtml"
       Write(Html.DisplayNameFor(model => model.User.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 20 "C:\Users\gerbm\Desktop\Hausrabeit\Hausarbeit_StreamingDienst\StreamingDienst\Pages\BenutzerAnsicht\AccountLoeschen.cshtml"
       Write(Html.DisplayFor(model => model.User.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 23 "C:\Users\gerbm\Desktop\Hausrabeit\Hausarbeit_StreamingDienst\StreamingDienst\Pages\BenutzerAnsicht\AccountLoeschen.cshtml"
       Write(Html.DisplayNameFor(model => model.User.Vorname));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 26 "C:\Users\gerbm\Desktop\Hausrabeit\Hausarbeit_StreamingDienst\StreamingDienst\Pages\BenutzerAnsicht\AccountLoeschen.cshtml"
       Write(Html.DisplayFor(model => model.User.Vorname));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            E-Mail\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 32 "C:\Users\gerbm\Desktop\Hausrabeit\Hausarbeit_StreamingDienst\StreamingDienst\Pages\BenutzerAnsicht\AccountLoeschen.cshtml"
       Write(Html.DisplayFor(model => model.User.EMail));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 35 "C:\Users\gerbm\Desktop\Hausrabeit\Hausarbeit_StreamingDienst\StreamingDienst\Pages\BenutzerAnsicht\AccountLoeschen.cshtml"
       Write(Html.DisplayNameFor(model => model.User.IBAN));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 38 "C:\Users\gerbm\Desktop\Hausrabeit\Hausarbeit_StreamingDienst\StreamingDienst\Pages\BenutzerAnsicht\AccountLoeschen.cshtml"
       Write(Html.DisplayFor(model => model.User.IBAN));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 41 "C:\Users\gerbm\Desktop\Hausrabeit\Hausarbeit_StreamingDienst\StreamingDienst\Pages\BenutzerAnsicht\AccountLoeschen.cshtml"
       Write(Html.DisplayNameFor(model => model.User.BIC));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 44 "C:\Users\gerbm\Desktop\Hausrabeit\Hausarbeit_StreamingDienst\StreamingDienst\Pages\BenutzerAnsicht\AccountLoeschen.cshtml"
       Write(Html.DisplayFor(model => model.User.BIC));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 47 "C:\Users\gerbm\Desktop\Hausrabeit\Hausarbeit_StreamingDienst\StreamingDienst\Pages\BenutzerAnsicht\AccountLoeschen.cshtml"
       Write(Html.DisplayNameFor(model => model.User.Bank));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 50 "C:\Users\gerbm\Desktop\Hausrabeit\Hausarbeit_StreamingDienst\StreamingDienst\Pages\BenutzerAnsicht\AccountLoeschen.cshtml"
       Write(Html.DisplayFor(model => model.User.Bank));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 53 "C:\Users\gerbm\Desktop\Hausrabeit\Hausarbeit_StreamingDienst\StreamingDienst\Pages\BenutzerAnsicht\AccountLoeschen.cshtml"
       Write(Html.DisplayNameFor(model => model.User.Geburtsdatum));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 56 "C:\Users\gerbm\Desktop\Hausrabeit\Hausarbeit_StreamingDienst\StreamingDienst\Pages\BenutzerAnsicht\AccountLoeschen.cshtml"
       Write(Html.DisplayFor(model => model.User.Geburtsdatum));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 59 "C:\Users\gerbm\Desktop\Hausrabeit\Hausarbeit_StreamingDienst\StreamingDienst\Pages\BenutzerAnsicht\AccountLoeschen.cshtml"
       Write(Html.DisplayNameFor(model => model.User.Benutzername));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 62 "C:\Users\gerbm\Desktop\Hausrabeit\Hausarbeit_StreamingDienst\StreamingDienst\Pages\BenutzerAnsicht\AccountLoeschen.cshtml"
       Write(Html.DisplayFor(model => model.User.Benutzername));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 65 "C:\Users\gerbm\Desktop\Hausrabeit\Hausarbeit_StreamingDienst\StreamingDienst\Pages\BenutzerAnsicht\AccountLoeschen.cshtml"
       Write(Html.DisplayNameFor(model => model.User.Guthaben));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 68 "C:\Users\gerbm\Desktop\Hausrabeit\Hausarbeit_StreamingDienst\StreamingDienst\Pages\BenutzerAnsicht\AccountLoeschen.cshtml"
       Write(Html.DisplayFor(model => model.User.Guthaben));

#line default
#line hidden
#nullable disable
            WriteLiteral("€\r\n        </dd>\r\n    </dl>\r\n\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9afd619d054b98c0b9b5c6d4318e2d3dba179f6c11149", async() => {
                WriteLiteral("\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9afd619d054b98c0b9b5c6d4318e2d3dba179f6c11416", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 73 "C:\Users\gerbm\Desktop\Hausrabeit\Hausarbeit_StreamingDienst\StreamingDienst\Pages\BenutzerAnsicht\AccountLoeschen.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.User.ID);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        <input type=\"submit\" value=\"Löschen\" class=\"btn btn-danger\" /> |\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9afd619d054b98c0b9b5c6d4318e2d3dba179f6c13251", async() => {
                    WriteLiteral("Zurück");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-UserID", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 75 "C:\Users\gerbm\Desktop\Hausrabeit\Hausarbeit_StreamingDienst\StreamingDienst\Pages\BenutzerAnsicht\AccountLoeschen.cshtml"
                                    WriteLiteral(Model.User.ID);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["UserID"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-UserID", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["UserID"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<StreamingDienst.Pages.BenutzerAnsicht.AccountLoeschenModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<StreamingDienst.Pages.BenutzerAnsicht.AccountLoeschenModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<StreamingDienst.Pages.BenutzerAnsicht.AccountLoeschenModel>)PageContext?.ViewData;
        public StreamingDienst.Pages.BenutzerAnsicht.AccountLoeschenModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
