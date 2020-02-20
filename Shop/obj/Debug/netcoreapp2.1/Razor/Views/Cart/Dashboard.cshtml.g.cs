#pragma checksum "C:\Users\HP\Desktop\Shop\Shop\Views\Cart\Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ee3592bd750f634c2598969b1d70ac6a400842f2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cart_Dashboard), @"mvc.1.0.view", @"/Views/Cart/Dashboard.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Cart/Dashboard.cshtml", typeof(AspNetCore.Views_Cart_Dashboard))]
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
#line 1 "C:\Users\HP\Desktop\Shop\Shop\Views\_ViewImports.cshtml"
using Shop;

#line default
#line hidden
#line 2 "C:\Users\HP\Desktop\Shop\Shop\Views\_ViewImports.cshtml"
using Shop.Models;

#line default
#line hidden
#line 33 "C:\Users\HP\Desktop\Shop\Shop\Views\Cart\Dashboard.cshtml"
using Microsoft.Extensions.Options;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ee3592bd750f634c2598969b1d70ac6a400842f2", @"/Views/Cart/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc6b55325b0ab971ba758bcc34a0cc77645e073f", @"/Views/_ViewImports.cshtml")]
    public class Views_Cart_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/Cart/Charge"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\HP\Desktop\Shop\Shop\Views\Cart\Dashboard.cshtml"
  
    List<Cart> items = ViewBag.items as List<Cart>;

#line default
#line hidden
            BeginContext(60, 1174, true);
            WriteLiteral(@"    <section id=""main"">
        <div>
            <h1>DASHBOARD</h1>
            <h3>Total - ${{total}}</h3>
            <button class=""btn btn-warning"">BUY</button>
            <br />
            <br />
            <table class=""table table-bordered table-dark"">
                <tr>
                    <th>id</th>
                    <th>name</th>
                    <th>price</th>
                    <th>quantity</th>
                    <th>subtotal</th>
                    <th>actions</th>

                </tr>
                <tr v-for=""item in products"">
                    <td>{{item.product.id}}</td>
                    <td>{{item.product.name}}</td>
                    <td>${{item.product.price}}</td>
                    <td>{{item.quantity}}</td>
                    <td>${{item.product.price*item.quantity}}</td>
                    <td>
                        <input v-on:change=""changeQuantity(item)"" type=""number"" v-model=""item.quantity"" />
                    </td>
     ");
            WriteLiteral("               <td><button v-on:click=\"remove(item)\" class=\"btn btn-danger remove\">Remove</button></td>\r\n                </tr>\r\n            </table>\r\n");
            EndContext();
            BeginContext(1283, 12, true);
            WriteLiteral("            ");
            EndContext();
            BeginContext(1336, 36, true);
            WriteLiteral("\r\n\r\n        </div>\r\n    </section>\r\n");
            EndContext();
            BeginContext(1372, 414, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0fef100938224e2995c1dd06c9ec517e", async() => {
                BeginContext(1414, 41, true);
                WriteLiteral("\r\n    <article>\r\n        <label>Amount: $");
                EndContext();
                BeginContext(1456, 13, false);
#line 41 "C:\Users\HP\Desktop\Shop\Shop\Views\Cart\Dashboard.cshtml"
                   Write(ViewBag.total);

#line default
#line hidden
                EndContext();
                BeginContext(1469, 139, true);
                WriteLiteral("</label>\r\n    </article>\r\n    <script src=\"//checkout.stripe.com/v2/checkout.js\"\r\n            class=\"stripe-button\"\r\n            data-key=\"");
                EndContext();
                BeginContext(1609, 27, false);
#line 45 "C:\Users\HP\Desktop\Shop\Shop\Views\Cart\Dashboard.cshtml"
                 Write(Stripe.Value.PublishableKey);

#line default
#line hidden
                EndContext();
                BeginContext(1636, 106, true);
                WriteLiteral("\"\r\n            data-locale=\"auto\"\r\n            data-description=\"Sample Charge\"\r\n            data-amount=\'");
                EndContext();
                BeginContext(1743, 13, false);
#line 48 "C:\Users\HP\Desktop\Shop\Shop\Views\Cart\Dashboard.cshtml"
                    Write(ViewBag.total);

#line default
#line hidden
                EndContext();
                BeginContext(1756, 23, true);
                WriteLiteral("*100\'>\r\n    </script>\r\n");
                EndContext();
            }
            );
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
            EndContext();
            BeginContext(1786, 2530, true);
            WriteLiteral(@"
<script src=""https://cdnjs.cloudflare.com/ajax/libs/fetch/3.0.0/fetch.js""></script>
<script src=""https://cdnjs.cloudflare.com/ajax/libs/vue/2.6.10/vue.js""></script>
<script>
    new Vue({
        el: ""#main"",
        data: {
            products: [],
            user_id: 0,
            total: 0
        },
        methods: {
            changeQuantity: function (item) {
                if (item.quantity == 0) {
                    this.products.splice(this.products.indexOf(item), 1)
                }
                let u = this.user_id;
                let obj = {
                    product: +item.product.id,
                    quantity: +item.quantity,
                    user_id: +u
                }
                fetch(""https://localhost:44375/Cart/UpdateQuantity"", {
                    method: 'POST',
                    headers: {
                        'Accept': 'application/json',
                        'Content-Type': 'application/json'
                    },
       ");
            WriteLiteral(@"             body: JSON.stringify(obj)
                }).then(res => res.json())
                    .then(res => {
                        console.log(res)
                        this.calculate();



                    });

            },
            remove: function (item) {
                fetch(""https://localhost:44375/Cart/Remove"", {
                    method: 'POST',
                    headers: {
                        'Accept': 'application/json',
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify({ product: item.product.id, user_id: item.user })
                }).then(r => {
                    this.products.splice(this.products.indexOf(item), 1)

                })
            }

            ,
            calculate: function () {
                let s = 0;
                for (let i = 0; i < this.products.length; i++) {
                    s += this.products[i].product.price * this.products[i].");
            WriteLiteral(@"quantity
                }
                this.total = s;
            }
        },
        created: function () {


            fetch(""https://localhost:44375/Cart/GetCartData"", {
                method: 'POST',

            }).then(res => res.json())
                .then(res => {
                    this.products = res;
                    this.user_id = res[0].user;

                    this.calculate();

                });
        }
    })
</script>
");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IOptions<StripeSettings> Stripe { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591