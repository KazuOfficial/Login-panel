using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LoginPanel.Pages;

namespace LoginPanel
{
    public class WelcomeModel : PageModel
    {
        public string Username;

        public void OnGet()
        {
            Username = HttpContext.Session.GetString("username");
        }
    }
}