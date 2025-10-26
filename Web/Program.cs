using AdventOfCodeWeb.Endpoints;

var app = WebApplication.CreateBuilder(args).Build();

app.MapEndpoints();
app.UseStaticFiles();

await app.RunAsync();
