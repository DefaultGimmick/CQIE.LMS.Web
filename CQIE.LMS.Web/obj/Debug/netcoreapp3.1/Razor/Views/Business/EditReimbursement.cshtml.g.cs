#pragma checksum "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Business\EditReimbursement.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "657896297ef65b4c67622ee51cadb0d7995296c4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Business_EditReimbursement), @"mvc.1.0.view", @"/Views/Business/EditReimbursement.cshtml")]
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
#line 1 "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\_ViewImports.cshtml"
using CQIE.LMS.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\_ViewImports.cshtml"
using CQIE.LMS.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"657896297ef65b4c67622ee51cadb0d7995296c4", @"/Views/Business/EditReimbursement.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"717be080286442179c7dcaa49b9839c5f7aaa00e", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Business_EditReimbursement : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CQIE.LMS.Models.ExpenseReimbursementOrder>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("~/Business/SaveReimbursement"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "657896297ef65b4c67622ee51cadb0d7995296c44182", async() => {
                WriteLiteral(@"
    <div>
        <table border=""1"" style=""border-collapse: collapse;"">
            <tbody>
                <tr>
                    <td colspan=""3"" style=""text-align: center"">
                        <h2>报销单</h2>
                        <span style=""text-align:right; color:red"">NO.");
#nullable restore
#line 10 "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Business\EditReimbursement.cshtml"
                                                                Write(Model.DetailsNumber);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n                        <input type=\"hidden\" name=\"FAD_Id\"");
                BeginWriteAttribute("value", " value=\"", 488, "\"", 509, 1);
#nullable restore
#line 11 "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Business\EditReimbursement.cshtml"
WriteAttributeValue("", 496, Model.FAD_Id, 496, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                        <input type=\"hidden\" name=\"FD_Id\"");
                BeginWriteAttribute("value", " value=\"", 572, "\"", 592, 1);
#nullable restore
#line 12 "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Business\EditReimbursement.cshtml"
WriteAttributeValue("", 580, Model.FD_Id, 580, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                        <input type=\"hidden\" name=\"DetailsNumber\"");
                BeginWriteAttribute("value", " value=\"", 663, "\"", 691, 1);
#nullable restore
#line 13 "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Business\EditReimbursement.cshtml"
WriteAttributeValue("", 671, Model.DetailsNumber, 671, 20, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                        <input type=\"hidden\" name=\"Id\"");
                BeginWriteAttribute("value", " value=\"", 751, "\"", 768, 1);
#nullable restore
#line 14 "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Business\EditReimbursement.cshtml"
WriteAttributeValue("", 759, Model.Id, 759, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n\r\n                    </td>\r\n\r\n                </tr>\r\n                <tr>\r\n                    <td>姓名:<input type=\"text\"");
                BeginWriteAttribute("value", " value=\"", 895, "\"", 939, 1);
#nullable restore
#line 20 "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Business\EditReimbursement.cshtml"
WriteAttributeValue("", 903, Model.FreightDispatOrder.DriverName, 903, 36, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" /></td>\r\n                    <td>电话:<input type=\"text\"");
                BeginWriteAttribute("value", " value=\"", 995, "\"", 1044, 1);
#nullable restore
#line 21 "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Business\EditReimbursement.cshtml"
WriteAttributeValue("", 1003, Model.FreightDispatOrder.DriverTelephone, 1003, 41, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" /></td>\r\n                    <td>时间:<input type=\"text\" name=\"Time\"");
                BeginWriteAttribute("value", " value=\"", 1112, "\"", 1131, 1);
#nullable restore
#line 22 "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Business\EditReimbursement.cshtml"
WriteAttributeValue("", 1120, Model.Time, 1120, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" /></td>
                </tr>
                <tr>
                    <td>费用说明</td>
                    <td>金额</td>
                    <td>备注</td>
                </tr>
                <tr>
                    <td><input type=""text"" name=""SourceOfExpensesDetails""");
                BeginWriteAttribute("value", " value=\"", 1406, "\"", 1444, 1);
#nullable restore
#line 30 "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Business\EditReimbursement.cshtml"
WriteAttributeValue("", 1414, Model.SourceOfExpensesDetails, 1414, 30, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" /></td>\r\n                    <td><input type=\"text\" name=\"FeeAmount\"");
                BeginWriteAttribute("value", " value=\"", 1514, "\"", 1538, 1);
#nullable restore
#line 31 "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Business\EditReimbursement.cshtml"
WriteAttributeValue("", 1522, Model.FeeAmount, 1522, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" /></td>\r\n                    <td><input type=\"text\"");
                BeginWriteAttribute("value", " value=\"", 1591, "\"", 1611, 1);
#nullable restore
#line 32 "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Business\EditReimbursement.cshtml"
WriteAttributeValue("", 1599, Model.Notes, 1599, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" /></td>\r\n                </tr>\r\n            </tbody>\r\n        </table>\r\n    </div>\r\n    <div>\r\n        <input type=\"submit\" value=\"提交\" style=\"border: solid 0px\" />\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CQIE.LMS.Models.ExpenseReimbursementOrder> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
