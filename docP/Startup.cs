using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(docP.Startup))]
namespace docP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
