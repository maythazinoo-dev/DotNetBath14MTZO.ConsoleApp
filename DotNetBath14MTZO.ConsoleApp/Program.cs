// See https://aka.ms/new-console-template for more information
using DotNetBath14MTZO.ConsoleApp.AdoDotNetExample;
using DotNetBath14MTZO.ConsoleApp.DapperExamples;
using DotNetBath14MTZO.ConsoleApp.EFCoreExamples;

Console.WriteLine("Hello, World!");

//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Edit("e9fc2b82-bf43-49da-a355-86a4cf073bdb");
//adoDotNetExample.Create("BlogTitel 11", "Blog Author 11", "Blog Content 11");
//adoDotNetExample.Update("ef6e1b6c-ba84-4618-b9b6-9ee1ca27af42", "Blog Title 12", "Blog Author 12", "Blog Content 12");
//adoDotNetExample.Delete("133a12dd-73a1-45e9-9622-3cf2300554d6");

//DapperExample dapperExample = new DapperExample();
//dapperExample.Read();
//dapperExample.Edit("AC9CB7FF-5792-47BA-A561-B289610AB182");
//dapperExample.Create("Blog Title", "Blog Author", "Blog Content");
//dapperExample.Update("e9fc2b82-bf43-49da-a355-86a4cf073bdb", "Blog Title 13", "Blog Author 13", "Blog Content 13");
//dapperExample.Delete("84d3af22-8f8b-4e2d-a587-2623dee094da");
//dapperExample.Delete("B231C22A-998F-4253-AC36-7AE6AB18E05F");

EFCoreExample eFCoreExample = new EFCoreExample();
eFCoreExample.Read();
eFCoreExample.Edit("8D7C0EB0-CB03-472E-9FD1-016A4CF20A85");
eFCoreExample.Create("Blog Title 14","Blog Author 14","Blog Content 14");
eFCoreExample.Update("f6e97fd7-1440-4086-843a-ce39133a85b2","Blog Titel 15","Blog Author 15", "Blog Content 15");
eFCoreExample.Delete("f6e97fd7-1440-4086-843a-ce39133a85b2");
