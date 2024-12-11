using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBath14MTZO.ConsoleApp.EFCoreExamples
{
    public class EFCoreExample
    {
        private readonly AppDbContext _db = new AppDbContext();

        public void Read() 
        { 
            var list = _db.BlogTables.ToList();

            foreach (var item in list)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Title);
                Console.WriteLine(item.Author);
                Console.WriteLine(item.Content);
            }
        }

        public void Edit(string id)
        {
            var item = _db.BlogTables.FirstOrDefault(x => x.Id == id);
            if (item is null)
            {
                Console.WriteLine("Not found Data");
                return;
            }
            Console.WriteLine(item.Id);
            Console.WriteLine(item.Title);
            Console.WriteLine(item.Author);
            Console.WriteLine(item.Content);
        }

        public void Create(string title, string author, string content)
        {
            var blog = new BlogTable
            {
                Id = Guid.NewGuid().ToString(),
                Title = title,
                Author = author,
                Content = content
            };

            _db.BlogTables.Add(blog);
            int result = _db.SaveChanges();
            string message = result > 0 ? "Create is Successful" : "Create is Failed";
            Console.WriteLine(message);
        }

        public void Update(string id, string title, string author, string content)
        {
            var item = _db.BlogTables.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (item is null)
            {
                Console.WriteLine("Not found Data");
                return;
            }

            item.Title = title;
            item.Author = author;
            item.Content = content;
            _db.Entry(item).State = EntityState.Modified;
            int result = _db.SaveChanges();
            string message = result > 0 ? "Updating is successful" : "Updating is failed";
            Console.WriteLine(message);

        }

        public void Delete(string id)
        {
            var item = _db.BlogTables.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (item is null)
            {
                Console.WriteLine("Not found Data");
                return;
            }
            _db.Entry(item).State = EntityState.Deleted;
            int result = _db.SaveChanges();
            string message = result > 0 ? "Delete is Successful" : "Delete is Failed";
            Console.WriteLine(message);
        }

    }
}
