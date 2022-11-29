using System.Data.SqlClient;
namespace CRUDWithADO.DAL
{
    public class BookDAL
    {
        private readonly IConfiguration configuration;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public BookDAL(IConfiguration configuration)
        {
            this.configuration = configuration;
            string str = this.configuration.GetConnectionString("defaultConnection");
            con = new SqlConnection(str);
        }

        public List<Book> GetAllBooks()
        {

            List<Book> books = new List<Book>();
            cmd = new SqlCommand("select * from books", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Book book = new Book();
                    book.Id = Convert.ToInt32(dr["id"]);
                    book.Name = dr["name"].ToString();
                    book.Author = dr["author"].ToString();
                    book.Publisher = dr["publisher"].ToString();
                    book.Price = Convert.ToInt32(dr["price"]);
                    books.Add(book);
                }

            }
            con.Close();
            return books;
        }

        public Book GetBookById(int id)
        {
            Book book = new Book();
            string qry = "select * from books where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    book.Id = Convert.ToInt32(dr["id"]);
                    book.Name = dr["name"].ToString();
                    book.Author = dr["author"].ToString();
                    book.Publisher = dr["publisher"].ToString();
                    book.Price = Convert.ToInt32(dr["price"]);
                }

            }
            con.Close();
            return book;
        }
        public int AddBook(Book book)
        {
            string qry = "insert into books values(@name,@author,@publisher,@price)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", book.Name);
            cmd.Parameters.AddWithValue("@author", book.Author);
            cmd.Parameters.AddWithValue("@publisher", book.Publisher);
            cmd.Parameters.AddWithValue("@price", book.Price);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int UpdateBook(Book book)
        {
            string qry = "update books set name=@name,author=@author,publisher=@publisher,price=@price where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", book.Name);
            cmd.Parameters.AddWithValue("@author", book.Author);
            cmd.Parameters.AddWithValue("@publisher", book.Publisher);
            cmd.Parameters.AddWithValue("@price", book.Price);
            cmd.Parameters.AddWithValue("@id", book.Id);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteBook(int id)
        {
            string qry = "delete from books where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
