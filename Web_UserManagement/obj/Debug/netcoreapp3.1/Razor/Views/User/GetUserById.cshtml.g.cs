#pragma checksum "D:\CouponManagement3\4BC-CouponManagement\Web_UserManagement\Views\User\GetUserById.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e08f9c49c64ce983adf7228392e741908591fc89"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_GetUserById), @"mvc.1.0.view", @"/Views/User/GetUserById.cshtml")]
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
#line 1 "D:\CouponManagement3\4BC-CouponManagement\Web_UserManagement\Views\_ViewImports.cshtml"
using MVC_UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\CouponManagement3\4BC-CouponManagement\Web_UserManagement\Views\_ViewImports.cshtml"
using MVC_UI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e08f9c49c64ce983adf7228392e741908591fc89", @"/Views/User/GetUserById.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"50cfe5b2535a5ae55c5a8ee0de5bb4c7bef7f708", @"/Views/_ViewImports.cshtml")]
    public class Views_User_GetUserById : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MVC_UI.Models.UserDetails>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\CouponManagement3\4BC-CouponManagement\Web_UserManagement\Views\User\GetUserById.cshtml"
  
    ViewData["Title"] = "GetUserById";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>GetUserById</h1>\r\n\r\n<div>\r\n    <h4>UserDetails</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 14 "D:\CouponManagement3\4BC-CouponManagement\Web_UserManagement\Views\User\GetUserById.cshtml"
       Write(Html.DisplayNameFor(model => model.UserId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 17 "D:\CouponManagement3\4BC-CouponManagement\Web_UserManagement\Views\User\GetUserById.cshtml"
       Write(Html.DisplayFor(model => model.UserId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 20 "D:\CouponManagement3\4BC-CouponManagement\Web_UserManagement\Views\User\GetUserById.cshtml"
       Write(Html.DisplayNameFor(model => model.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 23 "D:\CouponManagement3\4BC-CouponManagement\Web_UserManagement\Views\User\GetUserById.cshtml"
       Write(Html.DisplayFor(model => model.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 26 "D:\CouponManagement3\4BC-CouponManagement\Web_UserManagement\Views\User\GetUserById.cshtml"
       Write(Html.DisplayNameFor(model => model.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 29 "D:\CouponManagement3\4BC-CouponManagement\Web_UserManagement\Views\User\GetUserById.cshtml"
       Write(Html.DisplayFor(model => model.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 32 "D:\CouponManagement3\4BC-CouponManagement\Web_UserManagement\Views\User\GetUserById.cshtml"
       Write(Html.DisplayNameFor(model => model.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 35 "D:\CouponManagement3\4BC-CouponManagement\Web_UserManagement\Views\User\GetUserById.cshtml"
       Write(Html.DisplayFor(model => model.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 38 "D:\CouponManagement3\4BC-CouponManagement\Web_UserManagement\Views\User\GetUserById.cshtml"
       Write(Html.DisplayNameFor(model => model.UserPassword));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 41 "D:\CouponManagement3\4BC-CouponManagement\Web_UserManagement\Views\User\GetUserById.cshtml"
       Write(Html.DisplayFor(model => model.UserPassword));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 44 "D:\CouponManagement3\4BC-CouponManagement\Web_UserManagement\Views\User\GetUserById.cshtml"
       Write(Html.DisplayNameFor(model => model.EmailAddr));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 47 "D:\CouponManagement3\4BC-CouponManagement\Web_UserManagement\Views\User\GetUserById.cshtml"
       Write(Html.DisplayFor(model => model.EmailAddr));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 50 "D:\CouponManagement3\4BC-CouponManagement\Web_UserManagement\Views\User\GetUserById.cshtml"
       Write(Html.DisplayNameFor(model => model.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 53 "D:\CouponManagement3\4BC-CouponManagement\Web_UserManagement\Views\User\GetUserById.cshtml"
       Write(Html.DisplayFor(model => model.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 56 "D:\CouponManagement3\4BC-CouponManagement\Web_UserManagement\Views\User\GetUserById.cshtml"
       Write(Html.DisplayNameFor(model => model.UserAddress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 59 "D:\CouponManagement3\4BC-CouponManagement\Web_UserManagement\Views\User\GetUserById.cshtml"
       Write(Html.DisplayFor(model => model.UserAddress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
#nullable restore
#line 64 "D:\CouponManagement3\4BC-CouponManagement\Web_UserManagement\Views\User\GetUserById.cshtml"
Write(Html.ActionLink("Edit", "UpdateUser", new { id = TempData["userid"] }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n  \r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MVC_UI.Models.UserDetails> Html { get; private set; }
    }
}
#pragma warning restore 1591
