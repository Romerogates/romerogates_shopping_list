using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Lire la connection string depuis appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

var app = builder.Build();

// Endpoint pour tester la connexion
app.MapGet("/dbtest", async () =>
{
    try
    {
        await using var conn = new NpgsqlConnection(connectionString);
        await conn.OpenAsync();

        // Test simple : récupérer la version de PostgreSQL
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
