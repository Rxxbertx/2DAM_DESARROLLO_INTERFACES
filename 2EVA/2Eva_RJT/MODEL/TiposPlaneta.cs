using CORE;
using MySqlConnector;
using practicaLoginRJT.database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Eva_RJT.MODEL
{
    public class TiposPlaneta
    {



        public int Id { get; set; }
        public string Nombre { get; set; }

        public TiposPlaneta()
        {
            Id = 0;
            Nombre = "";
        }

        public TiposPlaneta(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public override string ToString()
        {
            return Nombre;
        }

    }

    public class  TiposPlanetasCollection : ObservableCollection<TiposPlaneta>
    {


        // read all

        public void ReadAll()
        {
            DBConnection db = DBConnection.DBInit();

            try
            {

                String query = "SELECT * FROM tipoPlaneta";
                using (MySqlCommand command = new MySqlCommand(query, DBConnection.OpenConnection(db)))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            Add(new TiposPlaneta(reader.GetInt32(0), reader.GetString(1)));

                        }
                    }
                }
            }

            catch (MySqlException)
            {

            }
        }

        
    }
}
