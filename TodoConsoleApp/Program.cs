using Dumpify;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Net.Http;
using TodoConsoleApp;

string baseAddress = "http://localhost:5000";

using var log = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

AuthenticationService authenticationService = new AuthenticationService(baseAddress);

string Email = "User@User.com";
string Password = "P@ssw0rd";

log.Information("Register User...");
await authenticationService.RegisterAsync(Email, Password);

log.Information("User Login...");
var AccessTokenInfo = await authenticationService.LoginAsync(Email, Password);

AccessTokenInfo.Dump();

Console.ReadLine();