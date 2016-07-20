using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebPhoneBook.Startup))]
namespace WebPhoneBook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
