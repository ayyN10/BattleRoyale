using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace battlePerso.Classes
{
    class Database
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public Database()
        {
            Initialiser();
        }

        private void Initialiser()
        {
            server = "phpmyadmin.exedesk.fr";
            database = "EXE_34_9ngvd";
            uid = "EXE_34_9ngvd";
            password = "-5nbE93Uh6Fbyj8*";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.

                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Impossible de se connecter au serveur");
                        break;

                    case 1045:
                        Console.WriteLine("Identifiants de la base de données érronés");
                        break;
                }
                return false;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public string RécupérerDernierUtilisateurTest()
        {
            string query = "SELECT NomUtilisateur FROM Utilisateur";

            //Create a list to store the result
            string id = null;

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    id = dataReader.GetString("NomUtilisateur");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return id;
            }
            else
            {
                return id;
            }
        }

        public int VérifUser(string NomAConnecter)
        {
            string query = "SELECT id FROM Utilisateur WHERE NomUtilisateur = \"" + NomAConnecter + "\";";

            //Create a list to store the result
            int idUtil = 0;

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                
                if (cmd.ExecuteScalar() is null) // Si l'identification est incorrect
                {
                    idUtil = -1;
                }
                else // Sinon on lui attribue l'id de son compte
                {
                    idUtil = int.Parse(cmd.ExecuteScalar() + "");
                }

                //close Connection
                this.CloseConnection();

                return idUtil;
            }
            else
            {
                return idUtil;
            }
        }
        /*
        public void InsertStatistique(int idUtilisateur, string Personnage, int DégatsInfligés, bool Victoire)
        {
            string query = "INSERT INTO Statistique (idUtil, Personnage, DegatsInfliges, Victoire) VALUES(\"" + idUtilisateur + "\", \"" + + "\"       )";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }*/
    }
}
