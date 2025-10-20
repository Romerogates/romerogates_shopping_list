using Npgsql;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

string cs = builder.Configuration.GetConnectionString("DefaultConnection");

app.MapGet("/dbtest", async () =>
{
    try
    {
        await using var conn = new NpgsqlConnection(cs);
        await conn.OpenAsync();
        await using var cmd = new NpgsqlCommand("SELECT version();", conn);
        var version = await cmd.ExecuteScalarAsync();
        return Results.Ok(new { Status = "Connected", PostgreSQLVersion = version });
    }
    catch (Exception ex)
    {
        return Results.Problem(title: "Erreur de connexion", detail: ex.Message);
    }
});

app.Run();
