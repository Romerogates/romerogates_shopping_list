var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Endpoint test
app.MapGet("/api/test", () => new { message = "API is working!" });

app.Run();
