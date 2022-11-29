using System.Data.SqlClient;

namespace CRUDWithADO.DAL
{
    public class EmployeeDAL
    {
        private readonly IConfiguration configuration;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public EmployeeDAL(IConfiguration configuration)
        {
            this.configuration = configuration;
            string str = this.configuration.GetConnectionString("defaultConnection");
            con = new SqlConnection(str);
        }
        public List<Employee> GetAllEmployees()
        {

            List<Employee> employees = new List<Employee>();
            cmd = new SqlCommand("select * from emp", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Employee emp = new Employee();
                    emp.Id = Convert.ToInt32(dr["id"]);
                    emp.Name = dr["name"].ToString();
                    emp.Salary = Convert.ToDecimal(dr["salary"]);
                    employees.Add(emp);
                }

            }
            con.Close();
            return employees;
        }
        public Employee GetEmployeeById(int id)
        {
            Employee emp = new Employee();
            string qry = "select * from emp where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    emp.Id = Convert.ToInt32(dr["id"]);
                    emp.Name = dr["name"].ToString();
                    emp.Salary = Convert.ToDecimal(dr["salary"]);
                }

            }
            con.Close();
            return emp;
        }
        public int AddEmployee(Employee emp)
        {
            string qry = "insert into emp values(@name,@sal)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", emp.Name);
            cmd.Parameters.AddWithValue("@sal", emp.Salary);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;

        }
        public int UpdateEmployee(Employee emp)
        {
            string qry = "update emp set name=@name,salary=@sal where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", emp.Name);
            cmd.Parameters.AddWithValue("@sal", emp.Salary);
            cmd.Parameters.AddWithValue("@id", emp.Id);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteEmployee(int id)
        {
            string qry = "delete from emp where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }


}

