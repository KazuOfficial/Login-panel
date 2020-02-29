using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Http;
using System.Threading;

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
            com.CommandText = "INSERT INTO hari (username, password) VALUES ('"+ Username + "','" + Password + "')";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();;
                return Page();
            }
            else
            {
                con.Close();
                Message = "Account has been created!";
                return Page();
            }
        }
    }
}