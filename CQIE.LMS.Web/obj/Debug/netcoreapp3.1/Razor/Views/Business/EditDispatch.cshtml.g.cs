#pragma checksum "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Business\EditDispatch.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d858a3f8c0ea40fe1871814b75ec65f2b43489e7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Business_EditDispatch), @"mvc.1.0.view", @"/Views/Business/EditDispatch.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d858a3f8c0ea40fe1871814b75ec65f2b43489e7", @"/Views/Business/EditDispatch.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"717be080286442179c7dcaa49b9839c5f7aaa00e", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Business_EditDispatch : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CQIE.LMS.Models.FreightDispatchOrder>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("~/Business/SaveDispatch"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d858a3f8c0ea40fe1871814b75ec65f2b43489e74151", async() => {
                WriteLiteral(@"
    <div>
        <table border=""1"" style=""border-collapse: collapse;"">
            <tbody>
                <tr>
                    <td colspan=""6"" style=""text-align: center; font-size:35px"" height=""100px"" valign=""top"">
                        <h2>调度单</h2>
                        <span style=""text-align:right; color:red"">NO.");
#nullable restore
#line 11 "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Business\EditDispatch.cshtml"
                                                                Write(Model.DispatchNumber);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n                        <input type=\"hidden\" name=\"CCO_Id\"");
                BeginWriteAttribute("value", " value=\"", 525, "\"", 546, 1);
#nullable restore
#line 12 "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Business\EditDispatch.cshtml"
WriteAttributeValue("", 533, Model.CCO_Id, 533, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                        <input type=\"hidden\" name=\"FD_Id\"");
                BeginWriteAttribute("value", " value=\"", 609, "\"", 629, 1);
#nullable restore
#line 13 "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Business\EditDispatch.cshtml"
WriteAttributeValue("", 617, Model.FD_Id, 617, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                        <input type=\"hidden\" name=\"DispatchNumber\"");
                BeginWriteAttribute("value", " value=\"", 701, "\"", 730, 1);
#nullable restore
#line 14 "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Business\EditDispatch.cshtml"
WriteAttributeValue("", 709, Model.DispatchNumber, 709, 21, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                        <input type=\"hidden\" name=\"Id\"");
                BeginWriteAttribute("value", " value=\"", 790, "\"", 807, 1);
#nullable restore
#line 15 "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Business\EditDispatch.cshtml"
WriteAttributeValue("", 798, Model.Id, 798, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                    </td>\r\n                    \r\n                </tr>\r\n                <tr>\r\n                    <td style=\"min-width: 200px\">车辆：<input type=\"text\" name=\"Car\"");
                BeginWriteAttribute("value", " value=\"", 988, "\"", 1006, 1);
#nullable restore
#line 20 "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Business\EditDispatch.cshtml"
WriteAttributeValue("", 996, Model.Car, 996, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" /></td>\r\n                    <td>司机：<input type=\"text\" name=\"DriverName\"");
                BeginWriteAttribute("value", " value=\"", 1080, "\"", 1105, 1);
#nullable restore
#line 21 "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Business\EditDispatch.cshtml"
WriteAttributeValue("", 1088, Model.DriverName, 1088, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("/></td>\r\n                    <td colspan=\"4\">司机电话：<input type=\"text\" name=\"DriverTelephone\"");
                BeginWriteAttribute("value", " value=\"", 1197, "\"", 1227, 1);
#nullable restore
#line 22 "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Business\EditDispatch.cshtml"
WriteAttributeValue("", 1205, Model.DriverTelephone, 1205, 22, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" /></td>\r\n                </tr>\r\n                <tr>\r\n                    <td colspan=\"2\">托运人名称：<input type=\"text\" name=\"SenderName\"");
                BeginWriteAttribute("value", " value=\"", 1361, "\"", 1403, 1);
#nullable restore
#line 25 "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Business\EditDispatch.cshtml"
WriteAttributeValue("", 1369, Model.consignmentOrder.SenderName, 1369, 34, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" /></td>\r\n                    <td style=\"min-width: 200px\">托运人电话：<input type=\"text\" name=\"SenderTelephone\"");
                BeginWriteAttribute("value", " value=\"", 1510, "\"", 1557, 1);
#nullable restore
#line 26 "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Business\EditDispatch.cshtml"
WriteAttributeValue("", 1518, Model.consignmentOrder.SenderTelephone, 1518, 39, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" /></td>\r\n                    <td colspan=\"2\">托运人地址：<input type=\"text\" name=\"SenderAddress\"");
                BeginWriteAttribute("value", " value=\"", 1649, "\"", 1694, 1);
#nullable restore
#line 27 "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Business\EditDispatch.cshtml"
WriteAttributeValue("", 1657, Model.consignmentOrder.SenderAddress, 1657, 37, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" /></td>\r\n                </tr>\r\n                <tr>\r\n                    <td colspan=\"2\">收货人名称：<input type=\"text\" name=\"ConsigneeName\"");
                BeginWriteAttribute("value", " value=\"", 1831, "\"", 1876, 1);
#nullable restore
#line 30 "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Business\EditDispatch.cshtml"
WriteAttributeValue("", 1839, Model.consignmentOrder.ConsigneeName, 1839, 37, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" /></td>\r\n                    <td style=\"min-width: 200px\">收货人电话：<input type=\"text\" name=\"ConsigneeTelephone\"");
                BeginWriteAttribute("value", " value=\"", 1986, "\"", 2036, 1);
#nullable restore
#line 31 "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Business\EditDispatch.cshtml"
WriteAttributeValue("", 1994, Model.consignmentOrder.ConsigneeTelephone, 1994, 42, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" /></td>\r\n                    <td colspan=\"2\">收货人地址：<input type=\"text\" name=\"ConsigneeAddress\"");
                BeginWriteAttribute("value", " value=\"", 2131, "\"", 2179, 1);
#nullable restore
#line 32 "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Business\EditDispatch.cshtml"
WriteAttributeValue("", 2139, Model.consignmentOrder.ConsigneeAddress, 2139, 40, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" /></td>
                </tr>
                <tr>
                    <td style=""text-align: center"">货物名称</td>
                    <td style=""text-align: center"">数量</td>
                    <td style=""text-align: center"">规格</td>
                    <td style=""text-align: center"">重量（KG）</td>
                    <td style=""text-align: center"">体积（立方）</td>
                </tr>
");
#nullable restore
#line 41 "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Business\EditDispatch.cshtml"
                 foreach (var order in Model.consignmentOrder.Freights)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <tr>\r\n                        <td><input type=\"text\" name=\"Name\"");
                BeginWriteAttribute("value", " value=\"", 2744, "\"", 2763, 1);
#nullable restore
#line 44 "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Business\EditDispatch.cshtml"
WriteAttributeValue("", 2752, order.Name, 2752, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" /></td>\r\n                        <td><input type=\"text\" name=\"Quantity\"");
                BeginWriteAttribute("value", " value=\"", 2836, "\"", 2859, 1);
#nullable restore
#line 45 "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Business\EditDispatch.cshtml"
WriteAttributeValue("", 2844, order.Quantity, 2844, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" /></td>\r\n                        <td><input type=\"text\" name=\"GoodsSKU\"");
                BeginWriteAttribute("value", " value=\"", 2932, "\"", 2955, 1);
#nullable restore
#line 46 "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Business\EditDispatch.cshtml"
WriteAttributeValue("", 2940, order.GoodsSKU, 2940, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" /></td>\r\n                        <td><input type=\"text\" name=\"GoodsWeight\"");
                BeginWriteAttribute("value", " value=\"", 3031, "\"", 3054, 1);
#nullable restore
#line 47 "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Business\EditDispatch.cshtml"
WriteAttributeValue("", 3039, order.GoodsSKU, 3039, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" /></td>\r\n                        <td><input type=\"text\" name=\"GoodsWeight\"");
                BeginWriteAttribute("value", " value=\"", 3130, "\"", 3156, 1);
#nullable restore
#line 48 "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Business\EditDispatch.cshtml"
WriteAttributeValue("", 3138, order.GoodsWeight, 3138, 18, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" /></td>\r\n                    </tr>\r\n");
#nullable restore
#line 50 "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Business\EditDispatch.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("                <tr>\r\n                    <td colspan=\"5\">备注：<input type=\"text\" name=\"Notes\"");
                BeginWriteAttribute("value", " value=\"", 3305, "\"", 3325, 1);
#nullable restore
#line 52 "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Business\EditDispatch.cshtml"
WriteAttributeValue("", 3313, Model.Notes, 3313, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" /></td>\r\n                </tr>\r\n                <tr>\r\n                    <td colspan=\"4\">制单时间：");
#nullable restore
#line 55 "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Business\EditDispatch.cshtml"
                                    Write(Model.CreateTime);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>制单人: ");
#nullable restore
#line 56 "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Business\EditDispatch.cshtml"
                        Write(Model.DispatchPersonnel.NormalizedUserName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                </tr>\r\n            </tbody>\r\n        </table>\r\n    </div>\r\n     <div>\r\n        <input type=\"submit\" value=\"提交\" style=\"border: solid 0px\" />\r\n    </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CQIE.LMS.Models.FreightDispatchOrder> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
