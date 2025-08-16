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
        private string GetConnectionString()
        {
            try
            {
                string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "auebd.mdb");

                if (!File.Exists(dbPath))
                {
                    throw new FileNotFoundException($"Arquivo de banco de dados não encontrado: {dbPath}");
                }

                return $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={dbPath};";
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao configurar conexão: {ex.Message}");
            }
        }
     

        public bool Create(Contact contact)
        {
            try
            {
                using (var connection = new OleDbConnection(GetConnectionString()))
                {
                    connection.Open();

                    string sql = "INSERT INTO Contatos (CodContato, Nome, Sexo, [Data], Cidade) VALUES (?, ?, ?, ?, ?)";
                    using (var command = new OleDbCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("?", GetNextId());
                        command.Parameters.AddWithValue("?", contact.Name ?? string.Empty);
                        command.Parameters.AddWithValue("?", contact.Sex ?? string.Empty);
                        command.Parameters.AddWithValue("?", contact.CreatedAt.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("?", contact.City ?? string.Empty);

                        command.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao criar contato: {ex.Message}\n\nVerifique:\n- Se todos os campos estão preenchidos\n- Se a data está no formato correto",
                    "Erro ao Salvar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public Contact GetById(int id)
        {
            try
            {
                using (var connection = new OleDbConnection(GetConnectionString()))
                {
                    connection.Open();

                    string sql = "SELECT CodContato, Nome, Sexo, [Data], Cidade FROM Contatos WHERE CodContato = ?";
                    using (var command = new OleDbCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("?", id);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Contact
                                {
                                    Id = Convert.ToInt32(reader["CodContato"]),
                                    Name = reader["Nome"]?.ToString() ?? string.Empty,
                                    City = reader["Cidade"]?.ToString() ?? string.Empty,
                                    Sex = reader["Sexo"]?.ToString() ?? string.Empty,
                                    CreatedAt = reader["Data"] != DBNull.Value ? Convert.ToDateTime(reader["Data"]) : DateTime.Now
                                };
                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar contato por ID: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public List<Contact> GetAll()
        {
            var contacts = new List<Contact>();

            try
            {
                using (var connection = new OleDbConnection(GetConnectionString()))
                {
                    connection.Open();

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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar todos os contatos: {ex.Message}",
                    "Erro ao Carregar Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return contacts;
        }

        public bool Update(Contact contact)
        {
            try
            {
                using (var connection = new OleDbConnection(GetConnectionString()))
                {
                    connection.Open();

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
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar contato: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using (var connection = new OleDbConnection(GetConnectionString()))
                {
                    connection.Open();

                    string sql = "DELETE FROM Contatos WHERE CodContato = ?";
                    using (var command = new OleDbCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("?", id);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao deletar contato: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private int GetNextId()
        {
            try
            {
                using (var connection = new OleDbConnection(GetConnectionString()))
                {
                    connection.Open();

                    string getMaxIdSql = "SELECT MAX(CodContato) FROM Contatos";
                    using (var maxIdCommand = new OleDbCommand(getMaxIdSql, connection))
                    {
                        var result = maxIdCommand.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            return Convert.ToInt32(result) + 1;
                        }
                        else
                        {
                            return 1;
                        }
                    }
                }
            }
            catch
            {
                return 1; 
            }
        }
    }
}