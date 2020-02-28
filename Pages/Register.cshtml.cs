using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Http;

namespace LoginPanel
{
    public class RegisterModel : PageModel
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
            com.CommandText = "INSERT INTO table VALUES (NULL,'"+ Username + "','" + Password + "')";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                HttpContext.Session.SetString("username", Username);
                return RedirectToPage("Index");
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