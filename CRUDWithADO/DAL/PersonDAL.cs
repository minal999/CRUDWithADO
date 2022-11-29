using System.Data.SqlClient;

namespace CRUDWithADO.DAL
{
    public class PersonDAL
    {
        private readonly IConfiguration configuration;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public PersonDAL(IConfiguration configuration)
        {
            this.configuration = configuration;
            string str = this.configuration.GetConnectionString("defaultConnection");
            con = new SqlConnection(str);
        }

        public List<Person> GetAllPersons()
        {

            List<Person> persons = new List<Person>();
            cmd = new SqlCommand("select * from person", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Person person = new Person();
                    person.Id = Convert.ToInt32(dr["id"]);
                    person.Name = dr["name"].ToString();
                    person.City = dr["city"].ToString();
                    person.Age = Convert.ToInt32(dr["age"]);
                    persons.Add(person);
                }

            }
            con.Close();
            return persons;
        }

        public Person GetPersonById(int id)
        {
            Person person = new Person();
            string qry = "select * from person where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    person.Id = Convert.ToInt32(dr["id"]);
                    person.Name = dr["name"].ToString();
                    person.City = dr["city"].ToString();
                    person.Age = Convert.ToInt32(dr["age"]);
                }

            }
            con.Close();
            return person;
        }
        public int AddPerson(Person person)
        {
            string qry = "insert into person values(@name,@city,@age)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", person.Name);
            cmd.Parameters.AddWithValue("@city", person.City);
            cmd.Parameters.AddWithValue("@age", person.Age);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int UpdatePerson(Person person)
        {
            string qry = "update person set name=@name,city=@city,age=@age where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", person.Name);
            cmd.Parameters.AddWithValue("@city", person.City);
            cmd.Parameters.AddWithValue("@age", person.Age);
            cmd.Parameters.AddWithValue("@id", person.Id);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeletePerson(int id)
        {
            string qry = "delete from person where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }



    }

}
