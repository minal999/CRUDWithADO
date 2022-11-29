using CRUDWithADO.DAL;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace CRUDWithADO.Models
{
 
    public class CustomerDAL
    {
        private readonly IConfiguration configuration;
        SqlConnection con;
        SqlDataReader dr;
        SqlCommand cmd;
        
        public CustomerDAL(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("defaultConnection"));
        }
        public int CustomerRegister(Customer cust)
        {
            string qry = "insert into customer values(@name,@email,@contact,@password)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", cust.Name);
            cmd.Parameters.AddWithValue("@email", cust.Email);
            cmd.Parameters.AddWithValue("@contact", cust.Contact);
            cmd.Parameters.AddWithValue("@password", cust.Password);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public Customer CustomerLogin(Customer cust)
        {
            Customer c = new Customer();
            string qry = "select * from customer where email=@email and password=@password";
            cmd=new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@email", cust.Email);
            cmd.Parameters.AddWithValue("@password", cust.Password);
            con.Open();
            dr=cmd.ExecuteReader();
            if(dr.HasRows)
            {
                if(dr.Read())
                {
                    c.Id = Convert.ToInt32(dr["id"]);
                    c.Email = dr["name"].ToString();
                    c.Password = dr["password"].ToString();
                }
                con.Close();
                return c;
            }
            else
            {
                return null;
            }

        }


    }
}
