#pragma checksum "D:\GitHub\EventsApp\EventsApp\Views\MainEvents\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "51c76ae07cbaaed25cb9b47177225b04307c317b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MainEvents_Index), @"mvc.1.0.view", @"/Views/MainEvents/Index.cshtml")]
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
#line 1 "D:\GitHub\EventsApp\EventsApp\Views\_ViewImports.cshtml"
using EventsApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\GitHub\EventsApp\EventsApp\Views\_ViewImports.cshtml"
using EventsApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"51c76ae07cbaaed25cb9b47177225b04307c317b", @"/Views/MainEvents/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"556cc88000505de1ab0ed9d83b8b223b743c093c", @"/Views/_ViewImports.cshtml")]
    public class Views_MainEvents_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<EventsApp.Models.MainEvent>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onsubmit", new global::Microsoft.AspNetCore.Html.HtmlString("event.preventDefault()"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-inline my-2 my-lg-0"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("EventLink text-center"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "MainEvents", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\GitHub\EventsApp\EventsApp\Views\MainEvents\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("<nav class=\"navbar navbar-expand-lg navbar-dark  own-nav\" style=\"border-top:solid;border-width:2px; margin:0px; background-color:#777\">\r\n    <div class=\"collapse navbar-collapse\" id=\"navbarColor02\">\r\n        <ul class=\"navbar-nav mr-auto\"");
            BeginWriteAttribute("style", " style=\"", 329, "\"", 337, 0);
            EndWriteAttribute();
            WriteLiteral(@">
            <li class=""nav-item active""> <a class=""nav-link"" href=""#"" data-abc=""true"">Home <span class=""sr-only"">(current)</span></a> </li>
            <li class=""nav-item""> <a class=""nav-link"" href=""#"" data-abc=""true"">Muzyka</a> </li>
            <li class=""nav-item""> <a class=""nav-link"" href=""#"" data-abc=""true"">Teatr</a> </li>
            <li class=""nav-item""> <a class=""nav-link"" href=""#"" data-abc=""true"">Religia</a> </li>
            <li class=""nav-item""> <a class=""nav-link"" href=""#"" data-abc=""true"">Nauka</a> </li>
            <li class=""nav-item""> <a class=""nav-link"" href=""#"" data-abc=""true"">Sztuka i kultura</a> </li>
            <li class=""nav-item""> <a class=""nav-link"" href=""#"" data-abc=""true"">Sport</a> </li>
        </ul>
        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "51c76ae07cbaaed25cb9b47177225b04307c317b6449", async() => {
                WriteLiteral("\r\n            <input class=\"form-control mr-sm-2\" type=\"text\" placeholder=\"Search\">\r\n            <button class=\"btn btn-primary my-2 my-sm-0\" type=\"submit\">Search</button>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</nav>\r\n<div class=\"MostInterestingEvents text-center\">\r\n    <h4 class=\"text-center\">Wydarzenia, które mogą Cię zainteresować</h4>\r\n        <div class=\"row\">\r\n");
#nullable restore
#line 26 "D:\GitHub\EventsApp\EventsApp\Views\MainEvents\Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "51c76ae07cbaaed25cb9b47177225b04307c317b8471", async() => {
                WriteLiteral("\r\n                    <div class=\"card card-block SingleEvent text-center\">\r\n                        <h4 class=\"card-title mt-3 mb-3\">");
#nullable restore
#line 30 "D:\GitHub\EventsApp\EventsApp\Views\MainEvents\Index.cshtml"
                                                    Write(item.title);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h4>\r\n");
#nullable restore
#line 31 "D:\GitHub\EventsApp\EventsApp\Views\MainEvents\Index.cshtml"
                          
                            var base64 = Convert.ToBase64String(item.picture);
                            var imgSrc = String.Format("data:image/gif;base64,{0}", base64);
                        

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <img");
                BeginWriteAttribute("src", " src=\'", 2126, "\'", 2139, 1);
#nullable restore
#line 35 "D:\GitHub\EventsApp\EventsApp\Views\MainEvents\Index.cshtml"
WriteAttributeValue("", 2132, imgSrc, 2132, 7, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" style=""max-width:200px; max-height:200px; margin-inline:auto""/>
                        <p class=""card-text"">
                            <ul style=""list-style-type:none;"">
                                <li style=""text-align:left""><i class=""fa fa-location-arrow"" style=""font-size:15px""></i>");
#nullable restore
#line 38 "D:\GitHub\EventsApp\EventsApp\Views\MainEvents\Index.cshtml"
                                                                                                                  Write(item.Place.name);

#line default
#line hidden
#nullable disable
                WriteLiteral(", ");
#nullable restore
#line 38 "D:\GitHub\EventsApp\EventsApp\Views\MainEvents\Index.cshtml"
                                                                                                                                    Write(item.Place.city);

#line default
#line hidden
#nullable disable
                WriteLiteral("</li>\r\n                                <li style=\"text-align:left\"><i class=\"fa fa-calendar\" style=\"font-size:15px\"></i>");
#nullable restore
#line 39 "D:\GitHub\EventsApp\EventsApp\Views\MainEvents\Index.cshtml"
                                                                                                            Write(item.dateStart);

#line default
#line hidden
#nullable disable
                WriteLiteral("</li>\r\n                            </ul>\r\n                        </p>\r\n                    </div>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 28 "D:\GitHub\EventsApp\EventsApp\Views\MainEvents\Index.cshtml"
                                                                                                    WriteLiteral(item.MainEventId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 44 "D:\GitHub\EventsApp\EventsApp\Views\MainEvents\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<EventsApp.Models.MainEvent>> Html { get; private set; }
    }
}
#pragma warning restore 1591
