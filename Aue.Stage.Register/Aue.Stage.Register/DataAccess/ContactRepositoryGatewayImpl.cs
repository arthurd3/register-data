using Aue.Stage.Register.Gateway;
using Aue.Stage.Register.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace Aue.Stage.Register.DataAccess
{
    class ContactRepositoryGatewayImpl : ContactRepositoryGateway
    {
        private readonly string dbPath = "auebd.mdb";
        private string getConnectionString()
        {
            if (!File.Exists(dbPath))
                throw new FileNotFoundException($"Banco de Dados nao Encontrado: {dbPath}");
           
            try{
                return $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={dbPath};";

            }catch(Exception ex){

                MessageBox.Show($"Erro na conexao com DB: {ex.Message}",
                    "Erro de Conexao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
        private OleDbConnection createOpenConnection()
        {
            try{
                var connection = new OleDbConnection(getConnectionString());
                connection.Open();
                return connection;

            }catch(Exception ex) { 

                MessageBox.Show($"Erro ao abrir conexão com o banco de dados: {ex.Message}",
                    "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

        }

        public bool create(Contact contact)
        {
            using (var connection = createOpenConnection())
            {
                string sql = "INSERT INTO Contatos (CodContato, Nome, Sexo, [Data], Cidade) VALUES (?, ?, ?, ?, ?)";
                using (var command = new OleDbCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("?", getNextId());
                    command.Parameters.AddWithValue("?", contact.Name ?? string.Empty);
                    command.Parameters.AddWithValue("?", contact.Sex ?? string.Empty);
                    command.Parameters.AddWithValue("?", contact.CreatedAt.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("?", contact.City ?? string.Empty);

                    command.ExecuteNonQuery();
                }
            }
            return true;
        }

        public List<Contact> getAll()
        {
            var contacts = new List<Contact>();

            using (var connection = createOpenConnection())
            {
                string sql = "SELECT CodContato, Nome, Sexo, [Data], Cidade FROM Contatos ORDER BY CodContato";
                using (var command = new OleDbCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        contacts.Add(new Contact
                        {
                            Id = Convert.ToInt32(reader["CodContato"]),
                            Name = reader["Nome"]?.ToString() ?? string.Empty,
                            City = reader["Cidade"]?.ToString() ?? string.Empty,
                            Sex = reader["Sexo"]?.ToString() ?? string.Empty,
                            CreatedAt = reader["Data"] != DBNull.Value ? Convert.ToDateTime(reader["Data"]) : DateTime.Now
                        });
                    }
                }
            }
            return contacts;
        }

        public bool update(Contact contact)
        {
            using (var connection = createOpenConnection())
            {
                string sql = "UPDATE Contatos SET Nome = ?, Cidade = ?, Sexo = ?, [Data] = ? WHERE CodContato = ?";
                using (var command = new OleDbCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("?", contact.Name ?? string.Empty);
                    command.Parameters.AddWithValue("?", contact.City ?? string.Empty);
                    command.Parameters.AddWithValue("?", contact.Sex ?? string.Empty);
                    command.Parameters.AddWithValue("?", contact.CreatedAt);
                    command.Parameters.AddWithValue("?", contact.Id);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public bool delete(int id)
        {
            using (var connection = createOpenConnection())
            {
                string sql = "DELETE FROM Contatos WHERE CodContato = ?";
                using (var command = new OleDbCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("?", id);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        private int getNextId()
        {
            using (var connection = createOpenConnection())
            {
                string getMaxIdSql = "SELECT MAX(CodContato) FROM Contatos";
                using (var maxIdCommand = new OleDbCommand(getMaxIdSql, connection))
                {
                    var result = maxIdCommand.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                        return Convert.ToInt32(result) + 1;
                    
                    return 1;
                }
            }
        }

    }
}