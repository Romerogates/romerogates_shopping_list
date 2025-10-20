using System.Net;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);
var cs = builder.Configuration.GetConnectionString("DefaultConnection");

// Forcer IPv4
var host = "db.lnjsaxrjzomapnlqfnno.supabase.co";
var ipv4 = Dns.GetHostAddresses(host).First(a => a.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);
cs = cs.Replace(host, ipv4.ToString());

var app = builder.Build();

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
