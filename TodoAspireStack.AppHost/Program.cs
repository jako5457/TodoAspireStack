using Microsoft.Extensions.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

// Database
var SqlServer = builder.AddPostgres("Postgress");
var todoDB = SqlServer.AddDatabase("TodoDB");

//TodoApp
var TodoApi = builder.AddProject<Projects.Todo_Api>("todo-api")
                     .WithReference(todoDB);

#region PgAdmin
if (builder.Environment.IsDevelopment())
{
    
    //Web interface on port 8080
    //SqlServer.WithPgAdmin(container => container.WithHostPort(8080));

}
#endregion PgAdmin

#region Custom container
// gets jako5457/shops:latest from docker hub
//var ShopApp = builder.AddContainer("ShopIndex","jako5457/shops","latest")
//                     .WithEndpoint(port: 8081, targetPort: 80,"http");
#endregion

builder.Build().Run();
