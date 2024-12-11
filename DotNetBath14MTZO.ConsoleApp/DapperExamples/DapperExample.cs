using Dapper;
using DotNetBath14MTZO.ConsoleApp.DapperExamples.BlogDtos;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBath14MTZO.ConsoleApp.DapperExamples
{
    public class DapperExample
    {
        private readonly string _connectionString = AppSetting.SqlConnectionStringBuilder.ConnectionString; 

        public void Read()
        {
            IDbConnection connection = new SqlConnection ( _connectionString );
            string query = "select * from Tbl_Blog";
            List<BlogDto>lst = connection.Query<BlogDto>(query).ToList();
            foreach (BlogDto item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);

            }
        }

        public void Edit(string id)
        {
            string query = $"select * from Tbl_Blog where [BlogId]='{id}'";
            IDbConnection connection = new SqlConnection(_connectionString);
            var item = connection.Query(query).FirstOrDefault();
            if (item is null)
            {
                Console.WriteLine("Not found Data");
                return;

            }

            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);

        }

        public void Create(string title,string author, string content)
        {
            string query = $@"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
            ('{title}'
           ,'{author}'
           ,'{content}')";

            IDbConnection connection = new SqlConnection( _connectionString );
            var result = connection.Execute(query);
            string message = result > 0 ? "Saving Successful" : "Saving Failed";
            Console.WriteLine(message);

        }

        public void Update (string id,string title,string author,string content)
        {
            string query = $@"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = '{title}'
      ,[BlogAuthor] = '{author}'
      ,[BlogContent] = '{content}'
 WHERE BlogId = '{id}'";
            IDbConnection connection= new SqlConnection ( _connectionString );
            int result = connection.Execute(query);
            string message = result > 0 ? "Updating Successful" : "Updating Failed";
            Console.WriteLine(message);
        }

        public void Delete(string id) 
        {
            string query = $"delete from Tbl_Blog where BlogId = '{id}'";
            IDbConnection connection = new SqlConnection ( _connectionString );
            int result = connection.Execute(query);
            string message = result > 0 ? "Delete is Successful" : "Delete is failed";
            Console.WriteLine(message);
        }
    }
}
