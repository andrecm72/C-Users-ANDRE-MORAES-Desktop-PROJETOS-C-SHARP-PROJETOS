Client client = null;
using (connection)
{
    using (var command = new SqlCommand("SELECT * FROM Clients WHERE Id = @id;", connection))
    {
        command.Parameters.Add(new SqlParameter("@id", id));
        connection.Open();
        using (var reader = command.ExecuteReader())
        {
            if (reader.Read())
            {
                client = new Client();
                client.Id = reader.GetString(0);
                client.Name = reader.GetString(1);
                client.Email = reader.GetString(2);
                client.Phone = reader.GetString(3);
            }
        }
    }
}
return client;