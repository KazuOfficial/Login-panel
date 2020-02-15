using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoginPanel.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }

        public string Message;

        public void OnGet()
        {

        }
        public IActionResult onGetLogout()
        {
            HttpContext.Session.Remove("username");
            return Page();
        }

        public IActionResult OnPost()
        {
            if (Username.Equals("abc") && Password.Equals("def"))
            {
                HttpContext.Session.SetString("username", Username);
                return RedirectToPage("Welcome");
            }
            else
            {
                Message = "Invalid login or password";
                return Page();
            }
        }
    }
}
