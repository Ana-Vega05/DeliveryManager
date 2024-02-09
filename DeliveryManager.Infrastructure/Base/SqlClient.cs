using Dapper;
using DeliveryManager.Domain.Repositories;
using Npgsql;

namespace DeliveryManager.Infrastructure.Base;

public class SqlClient : ISqlClient
{
    private string _connectionString = "Host=localhost;Port=5432;Database=postgres;" +
                                      "User ID=postgres;Password=123456";
    public async Task<List<T>> ExecuteQuery<T>(string query, DynamicParameters? parameters = null)
    {
        var connection = new NpgsqlConnection(_connectionString);
        var response  = await connection.QueryAsync<T>(query, parameters );
        await connection.CloseAsync();
        return response.ToList();
    }
    

    public async Task<T?> ExecuteQuerySingle<T>(string query, DynamicParameters? parameters = null)
    {
        var connection = new NpgsqlConnection(_connectionString);
        var response = await connection.QuerySingleAsync<T>(query, parameters);
        await connection.CloseAsync();
        return response;
    }

    public async Task ExecuteCommand(string command, object? parameters = null)
    {
        var connection = new NpgsqlConnection(_connectionString);
        await connection.ExecuteAsync(command, parameters);
        await connection.CloseAsync();
    }
}