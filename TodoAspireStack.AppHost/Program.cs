using Microsoft.Extensions.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

// Database
var SqlServer = builder.AddPostgres("Postgress");
var todoDB = SqlServer.AddDatabase("TodoDB");

//TodoApp
var TodoApi = builder.AddProject<Projects.Todo_Api>("todo-api")
                     .WithReference(todoDB);

builder.Build().Run();
