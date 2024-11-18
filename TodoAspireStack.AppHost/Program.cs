using Microsoft.Extensions.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

// Database
var SqlServer = builder.AddPostgres("Postgress");


if (builder.Environment.IsDevelopment())
{
    //Web interface on port 8080
    //SqlServer.WithPgAdmin(container => container.WithHostPort(8080));
}

var todoDB = SqlServer.AddDatabase("TodoDB");

//TodoApp
var TodoApi = builder.AddProject<Projects.Todo_Api>("todo-api")
                     .WithReference(todoDB);

builder.Build().Run();
