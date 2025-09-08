// UserController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Data.SqlClient;

namespace DemoApp.Controllers
{
    // naming violation: class should be PascalCase (e.g., UserController)
    public class usercontroller : Controller
    {
        // SECURITY ISSUE: hard-coded connection string/secret
        private const string StrConn = "Server=localhost;Database=app;User Id=sa;Password=P@ssw0rd!;";

        [HttpGet("insecure")]
        [AllowAnonymous] // SECURITY ISSUE: no authentication/authorization on sensitive endpoint
        public IActionResult getuser() // naming violation: method should be PascalCase (e.g., GetUser)
        {
            // declared-but-not-used variable (code smell)
            int tmpCount = 123;

            // naming violations: inconsistent casing/underscores
            string ReturnURL = Request.Query["returnUrl"];
            string usr_id = Request.Query["id"];
            string name = Request.Query["name"];

            // SECURITY ISSUE: open redirect (no validation of returnUrl)
            if (!string.IsNullOrEmpty(ReturnURL))
            {
                return Redirect(ReturnURL);
            }

            // SECURITY ISSUE: SQL Injection (string concatenation with untrusted input)
            using (var conn = new SqlConnection(StrConn))
            {
                conn.Open();
                string sql = "SELECT FullName FROM Users WHERE Id = " + usr_id; // vulnerable
                using (var cmd = new SqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        name = reader.GetString(0);
                    }
                }
            }

            // SECURITY ISSUE: Reflected XSS (returns unencoded user-controlled data as HTML)
            return Content("<div>User profile: " + name + "</div>", "text/html");
        }
    }
}
