using AdventOfCode2024;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseStaticFiles();
app.MapEndpoint();
app.Run();
