using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace AngularApp1.Server
{
    [ApiController]
    [Route("[controller]")]
    public class ContactDetailsController : ControllerBase
    {
        string connectionString = @"Data Source=(LocalDB)\\MSSQLLocalDB;Database=master;Integrated Security=true;";

        [HttpPost]
        public void PostContactDetails([FromBody] DOContactDetails contactDetails)
        {
            AddContactDetail(contactDetails);

        }
        private void AddContactDetail(DOContactDetails contactDetails)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                String qry = "Insert into [dbo].[ContactDetails] (FirstName,LastName,Email,PhoneNumber,Address,City,State,Country,PostalCode) values ('" + contactDetails.FirstName + "','" + contactDetails.LastName + "','" + contactDetails.Email + "','" + contactDetails.PhoneNumber + "','" + contactDetails.Address + "','" + contactDetails.City + "','" + contactDetails.State + "','" + contactDetails.Country + "','" + contactDetails.PostalCode + ")";
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = qry;
                cmd.ExecuteNonQuery();
            }
            catch(Exception e) {
            }
        }
    }
}