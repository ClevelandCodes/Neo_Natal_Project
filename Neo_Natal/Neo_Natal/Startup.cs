using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Neo_Natal.Startup))]
namespace Neo_Natal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
