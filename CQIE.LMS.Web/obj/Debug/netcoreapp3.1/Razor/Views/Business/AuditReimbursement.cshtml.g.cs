#pragma checksum "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Business\AuditReimbursement.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fb9b2a7d625cb4cc1e89510ca01096a3d8a23bde"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Business_AuditReimbursement), @"mvc.1.0.view", @"/Views/Business/AuditReimbursement.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fb9b2a7d625cb4cc1e89510ca01096a3d8a23bde", @"/Views/Business/AuditReimbursement.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"717be080286442179c7dcaa49b9839c5f7aaa00e", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Business_AuditReimbursement : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CQIE.LMS.Models.ExpenseReimbursementOrder>
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
            WriteLiteral("\r\n\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fb9b2a7d625cb4cc1e89510ca01096a3d8a23bde4195", async() => {
                WriteLiteral(@"
    <div>
        <table border=""1"" style=""border-collapse: collapse;"">
            <tbody>
                <tr>
                    <td colspan=""3"" style=""text-align: center"">
                        <h2>报销单</h2>
                        <span style=""text-align:right; color:red"">NO.");
#nullable restore
#line 12 "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Business\AuditReimbursement.cshtml"
                                                                Write(Model.DetailsNumber);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n                        <input type=\"hidden\" name=\"FAD_Id\"");
                BeginWriteAttribute("value", " value=\"", 492, "\"", 513, 1);
#nullable restore
#line 13 "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Business\AuditReimbursement.cshtml"
WriteAttributeValue("", 500, Model.FAD_Id, 500, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                        <input type=\"hidden\" name=\"FD_Id\"");
                BeginWriteAttribute("value", " value=\"", 576, "\"", 596, 1);
#nullable restore
#line 14 "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Business\AuditReimbursement.cshtml"
WriteAttributeValue("", 584, Model.FD_Id, 584, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                        <input type=\"hidden\" name=\"DetailsNumber\"");
                BeginWriteAttribute("value", " value=\"", 667, "\"", 695, 1);
#nullable restore
#line 15 "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Business\AuditReimbursement.cshtml"
WriteAttributeValue("", 675, Model.DetailsNumber, 675, 20, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                        <input type=\"hidden\" name=\"Id\"");
                BeginWriteAttribute("value", " value=\"", 755, "\"", 772, 1);
#nullable restore
#line 16 "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Business\AuditReimbursement.cshtml"
WriteAttributeValue("", 763, Model.Id, 763, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                    </td>\r\n\r\n                </tr>\r\n                <tr>\r\n                    <td>姓名:<input type=\"text\"");
                BeginWriteAttribute("value", " value=\"", 897, "\"", 941, 1);
#nullable restore
#line 21 "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Business\AuditReimbursement.cshtml"
WriteAttributeValue("", 905, Model.FreightDispatOrder.DriverName, 905, 36, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" /></td>\r\n                    <td>电话:<input type=\"text\"");
                BeginWriteAttribute("value", " value=\"", 997, "\"", 1046, 1);
#nullable restore
#line 22 "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Business\AuditReimbursement.cshtml"
WriteAttributeValue("", 1005, Model.FreightDispatOrder.DriverTelephone, 1005, 41, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" /></td>\r\n                    <td>时间:<input type=\"text\" name=\"Time\"");
                BeginWriteAttribute("value", " value=\"", 1114, "\"", 1133, 1);
#nullable restore
#line 23 "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Business\AuditReimbursement.cshtml"
WriteAttributeValue("", 1122, Model.Time, 1122, 11, false);

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
                BeginWriteAttribute("value", " value=\"", 1408, "\"", 1446, 1);
#nullable restore
#line 31 "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Business\AuditReimbursement.cshtml"
WriteAttributeValue("", 1416, Model.SourceOfExpensesDetails, 1416, 30, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" /></td>\r\n                    <td><input type=\"text\" name=\"FeeAmount\"");
                BeginWriteAttribute("value", " value=\"", 1516, "\"", 1540, 1);
#nullable restore
#line 32 "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Business\AuditReimbursement.cshtml"
WriteAttributeValue("", 1524, Model.FeeAmount, 1524, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" /></td>\r\n                    <td><input type=\"text\"");
                BeginWriteAttribute("value", " value=\"", 1593, "\"", 1613, 1);
#nullable restore
#line 33 "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Business\AuditReimbursement.cshtml"
WriteAttributeValue("", 1601, Model.Notes, 1601, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" /></td>\r\n                </tr>\r\n                <tr>\r\n                    <td>\r\n                        报销状态:\r\n                        ");
#nullable restore
#line 38 "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Business\AuditReimbursement.cshtml"
                   Write(Html.RadioButton("Status", 1));

#line default
#line hidden
#nullable disable
                WriteLiteral("<span>通过</span>&nbsp;\r\n                        ");
#nullable restore
#line 39 "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Business\AuditReimbursement.cshtml"
                   Write(Html.RadioButton("Status", 2));

#line default
#line hidden
#nullable disable
                WriteLiteral("<span>不通过</span>&nbsp;\r\n                        ");
#nullable restore
#line 40 "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Business\AuditReimbursement.cshtml"
                   Write(Html.RadioButton("Status", 3));

#line default
#line hidden
#nullable disable
                WriteLiteral("<span>审核中</span>\r\n                    </td>\r\n\r\n                    <td colspan=\"2\">不通过说明:<input type=\"text\" name=\"Explain\"");
                BeginWriteAttribute("value", " value=\"", 2057, "\"", 2079, 1);
#nullable restore
#line 43 "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Business\AuditReimbursement.cshtml"
WriteAttributeValue("", 2065, Model.Explain, 2065, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" /></td>\r\n\r\n                </tr>\r\n            </tbody>\r\n        </table>\r\n    </div>\r\n    <div>\r\n        <input type=\"submit\" value=\"提交\" style=\"border: solid 0px\" />\r\n    </div>\r\n");
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
