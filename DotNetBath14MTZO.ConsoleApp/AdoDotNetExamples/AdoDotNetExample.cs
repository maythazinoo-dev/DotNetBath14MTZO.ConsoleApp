using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBath14MTZO.ConsoleApp.AdoDotNetExample
{
    public class AdoDotNetExample
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder= new SqlConnectionStringBuilder() 
        { 
            DataSource=".",
            InitialCatalog="WalletDB",
            UserID="sa",
            Password="mtzoo@123",
            TrustServerCertificate=true        
        };

        public void Read()
        {
            SqlConnection sqlConnection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();

            string query = "select * from Tbl_Blog";
            SqlCommand cmd = new SqlCommand(query,sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            sqlConnection.Close();

            foreach(DataRow row in dt.Rows)
            {
                Console.WriteLine(row["BlogId"]);
                Console.WriteLine(row["BlogTitle"]);
                Console.WriteLine(row["BlogAuthor"]);
                Console.WriteLine(row["BlogContent"]);

            }
        }

        public void Edit(string id)
        {
            string qry = $"select * from Tbl_Blog where [BlogId]='{id}'";
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            
            connection.Open();
            SqlCommand cmd = new SqlCommand(qry, connection);
            SqlDataAdapter sqladater = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqladater.Fill(dt);

            connection.Close();

            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("Not Data found");
                return;
            }

            DataRow row = dt.Rows[0];

            Console.WriteLine(row["BlogID"]);
            Console.WriteLine(row["BlogTitle"]);
            Console.WriteLine(row["BlogAuthor"]);
            Console.WriteLine(row["BlogContent"]);


        }

        public void Create(string title, string author,string content)
        {
            string query = $@"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
            ('{title}'
           ,'{author}'
           ,'{content}')";
            SqlConnection sqlConnection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataAdapter adapter= new SqlDataAdapter(cmd);

            var result = cmd.ExecuteNonQuery();
            string message = result > 0 ? "Saving successful" : "Saving Failed";
            Console.WriteLine(message);
            
        }

        public void Update(string id,string title,string author,string content)
        {
            string query = $@"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = '{title}'
      ,[BlogAuthor] = '{author}'
      ,[BlogContent] = '{content}'
 WHERE BlogId = '{id}'";
            SqlConnection sqlConnection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(query,sqlConnection) ;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            var result = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            string message = result > 0 ? "Updating Successful" : "Updating Failed";
            Console.WriteLine(message);
        }

        public void Delete(string id)
        {
            string query = $"delete from Tbl_Blog where BlogId = '{id}'";
            SqlConnection sqlConnection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString) ;
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            var result = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            string message = result > 0 ? "Delete is successful" : "Delete is failed";
            Console.WriteLine(message);
           

        }

    }
}



