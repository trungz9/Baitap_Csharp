using MySqlConnector;

namespace WinFormsApp2.data.DAO;

public class DataHelper
{
    public const string ConnectionString =
        "Server=localhost;Port=3306;Database=QLSV;User ID=root;Password=dmcvmkii28;";

    public DataHelper() { }

    public int InsertUpdateDelete(string commandText, params MySqlParameter[] parameters)
    {
        return WithConnection(connection =>
        {
            using var command = new MySqlCommand(commandText, connection);
            command.Parameters.AddRange(parameters);
            return command.ExecuteNonQuery();
        });
    }

    public T? ExecuteScalar<T>(string commandText, params MySqlParameter[] parameters)
    {
        return WithConnection(connection =>
        {
            using var command = new MySqlCommand(commandText, connection);
            command.Parameters.AddRange(parameters);
            var result = command.ExecuteScalar();
            return result is null or DBNull ? default : (T)Convert.ChangeType(result, typeof(T));
        });
    }

    public List<T> Select<T>(
        string commandText,
        Func<MySqlDataReader, T> map,
        params MySqlParameter[] parameters)
    {
        return WithConnection(connection =>
        {
            using var command = new MySqlCommand(commandText, connection);
            command.Parameters.AddRange(parameters);
            using var reader = command.ExecuteReader();
            var results = new List<T>();
            while (reader.Read())
            {
                results.Add(map(reader));
            }

            return results;
        });
    }

    public MySqlConnection CreateConnection()
    {
        return new MySqlConnection(ConnectionString);
    }

    public T WithConnection<T>(Func<MySqlConnection, T> operation)
    {
        using var connection = CreateConnection();
        OpenConnection(connection);
        try
        {
            return operation(connection);
        }
        finally
        {
            connection.Close();
        }
    }

    public static void OpenConnection(MySqlConnection connection)
    {
        if (connection.State != System.Data.ConnectionState.Open)
        {
            connection.Open();
        }
    }

    public static MySqlParameter Parameter(string name, object? value)
    {
        return new MySqlParameter(name, value ?? DBNull.Value);
    }
}
