using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NeoNatal1.Startup))]
namespace NeoNatal1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
