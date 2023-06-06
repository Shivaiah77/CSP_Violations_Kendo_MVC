using Microsoft.Owin;
using Owin;
using System;
using System.Security.Cryptography;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(MVC_CSP.Startup))]

namespace MVC_CSP
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use((context, next) =>
            {
                var rng = new RNGCryptoServiceProvider();
                var nonceBytes = new byte[32];
                rng.GetBytes(nonceBytes);
                var nonce = Convert.ToBase64String(nonceBytes);
                context.Set("ScriptNonce", nonce);
                context.Response.Headers.Add("Content-Security-Policy",
                    new[] { string.Format("default-src * https: data:; connect-src 'self'; style-src 'self' 'nonce-{0}'; script-src 'self' 'nonce-{1}'; child-src 'nonce-{2}'; object-src 'nonce-{3}'", nonce, nonce, nonce, nonce) });
                return next();
            });
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
