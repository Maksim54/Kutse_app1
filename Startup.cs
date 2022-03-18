using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Kutse_app.StartupOwin))]

namespace Kutse_app
{
    public partial class StartupOwin
    {
        public void Configuration(IAppBuilder app)
        {
            //AuthStartup.ConfigureAuth(app);
        }
    }
}
