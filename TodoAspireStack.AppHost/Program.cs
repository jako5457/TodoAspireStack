var builder = DistributedApplication.CreateBuilder(args);

// Database
var SqlServer = builder.AddPostgres("Postgress");
var todoDB = SqlServer.AddDatabase("TodoDB");

//TodoApp
builder.AddProject<Projects.Todo_Api>("todo-api")
       .WithReference(todoDB)
       .WithExternalHttpEndpoints();

builder.Build().Run();
