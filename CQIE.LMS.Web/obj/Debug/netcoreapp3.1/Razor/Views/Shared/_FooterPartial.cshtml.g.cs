#pragma checksum "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Shared\_FooterPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0c125e454f3cb313b44a8c5f2961c7dc00dd2a1f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__FooterPartial), @"mvc.1.0.view", @"/Views/Shared/_FooterPartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0c125e454f3cb313b44a8c5f2961c7dc00dd2a1f", @"/Views/Shared/_FooterPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"717be080286442179c7dcaa49b9839c5f7aaa00e", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared__FooterPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"footer\">\r\n    <span>当前操作员：管理员</span>\r\n    <span>当前时间：");
#nullable restore
#line 3 "E:\文档\Tencent Files\QQ\CQIE.LMS.Web\CQIE.LMS.Web\Views\Shared\_FooterPartial.cshtml"
          Write(DateTime.Now);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n    <span>当前账套：XXXX科技有限公司</span>\r\n    <span>财务期间：5</span>\r\n    <span>业务期间：5</span>\r\n    <span>连接状态：正常</span>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
