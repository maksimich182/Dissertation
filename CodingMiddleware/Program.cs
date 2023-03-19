using CodingMiddleware.Middlewares;
using CodingMiddleware.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<ICoder, ShennonFanoCoderService>();
var app = builder.Build();
app.UseCoding();
app.MapGet("/", () => "Hello World!");

app.Run();
