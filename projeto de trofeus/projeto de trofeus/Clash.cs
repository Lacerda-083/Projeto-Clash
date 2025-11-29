using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;


namespace Projeto_CR
{
    class Clash
    {
        private static string connectionString = "Server=localhost;Database=ClashDB;Integrated Security=True;";


        public static void RegistrarJogador(string nick, int trofeus)
        {
            string query = "INSERT INTO Jogadores (Nick, Trofeus) VALUES (@Nick, @Trofeus)";

            using SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Nick", nick);
            command.Parameters.AddWithValue("@Trofeus", trofeus);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine($"Jogador '{nick}' registrado com {trofeus} troféus!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao registrar jogador: " + ex.Message);
            }
        }

       
        public static void ListarJogadores()
        {
            string query = "SELECT Nick, Trofeus FROM Jogadores";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    Console.WriteLine("\nJogadores no Clã:");
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["Nick"]} - {reader["Trofeus"]} troféus");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao listar jogadores: " + ex.Message);
                }
            }
        }

        public static bool JogadorExistente(string nick)
        {
            string query = "SELECT COUNT(*) FROM Jogadores WHERE Nick = @Nick";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nick", nick);

                try
                {
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao verificar jogador: " + ex.Message);
                    return false;
                }
            }
        }
    }
}
