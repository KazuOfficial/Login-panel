using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace LoginPanel.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }

        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        public string Message;

        public void OnGet()
        {

        }
        public IActionResult onGetLogout()
        {
            HttpContext.Session.Remove("username");
            return Page();
        }

        [HttpPost]
        void connectionString()
        {
            con.ConnectionString = "data source=DESKTOP-UGKHTFI; database=Login; integrated security = SSPI;";
        }

        [HttpPost]
        public IActionResult OnPost()
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from hari where username='" + Username + "' and password='" + Password + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                HttpContext.Session.SetString("username", Username);
                return RedirectToPage("Welcome");
            }
            else
            {
                con.Close();
                Message = "Invalid login or password";
                return Page();
            }
        }
    }
}
