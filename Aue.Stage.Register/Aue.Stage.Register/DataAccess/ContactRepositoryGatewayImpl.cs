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
    internal class ContactRepositoryGatewayImpl : ContactRepositoryGateway
    {
        private string GetConnectionString()
        {
            try
            {
                var configConnectionString = ConfigurationManager.ConnectionStrings["AueDatabase"]?.ConnectionString;

                if (!string.IsNullOrEmpty(configConnectionString))
                {
                    string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "auebd.mdb");

                    if (File.Exists(dbPath))
                    {
                        return configConnectionString.Replace("auebd.mdb", dbPath);
                    }
                }

                string defaultDbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "auebd.mdb");
                if (File.Exists(defaultDbPath))
                {
                    return $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={defaultDbPath};";
                }

                throw new FileNotFoundException($"Arquivo de banco de dados não encontrado: {defaultDbPath}");
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

                    int nextId = GetNextId();

                    string sql = "INSERT INTO Contatos (CodContato, Nome, Cidade, Sexo) VALUES (?, ?, ?, ?)";
                    using (var command = new OleDbCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("?", nextId);
                        command.Parameters.AddWithValue("?", contact.Name ?? string.Empty);
                        command.Parameters.AddWithValue("?", contact.City ?? string.Empty);
                        command.Parameters.AddWithValue("?", contact.Sex);
                     
                        command.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao criar contato: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    string sql = "SELECT CodContato, Nome, Cidade, Sexo FROM Contatos WHERE CodContato = ?";
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
                                    Sex = (char)(reader["Sexo"].ToString()?[0])
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

                    string sql = "SELECT CodContato, Nome, Cidade, Sexo FROM Contatos ORDER BY CodContato";
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
                                Sex = (char)(reader["Sexo"].ToString()?[0])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar todos os contatos: {ex.Message}\n\nDetalhes técnicos:\n- Verifique se o arquivo auebd.mdb existe\n- Verifique se a tabela 'Contatos' existe\n- Verifique se as colunas estão corretas",
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

                    string sql = "UPDATE Contatos SET Nome = ?, Cidade = ?, Sexo = ? WHERE CodContato = ?";
                    using (var command = new OleDbCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("?", contact.Name ?? string.Empty);
                        command.Parameters.AddWithValue("?", contact.City ?? string.Empty);
                        command.Parameters.AddWithValue("?", contact.Sex);
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
            using (var connection = new OleDbConnection(GetConnectionString()))
            {
                connection.Open();

                int nextId = 1;
                string getMaxIdSql = "SELECT MAX(CodContato) FROM Contatos";
                using (var maxIdCommand = new OleDbCommand(getMaxIdSql, connection))
                {
                    var result = maxIdCommand.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        nextId = Convert.ToInt32(result) + 1;
                    }
                }
                return nextId;
            }
        }
    }
}