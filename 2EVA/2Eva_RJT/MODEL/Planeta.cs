using CORE;
using MySqlConnector;
using practicaLoginRJT.database;
using Syncfusion.Compression;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Eva_RJT.MODEL
{
    public class Planeta
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cod { get; set; }
        public int Satelites { get; set; }
        public float FactorGravitacional { get; set; }
        public bool Vida { get; set; }
        public string VidaText
        {
            get
            {
                return Vida ? "Si" : "No";
            }
        }
        public int Tipo { get; set; }


        //constructor
        public Planeta()
        {
            Id = 0;
            Nombre = "";
            Cod = "";
            Satelites = 0;
            FactorGravitacional = 0;
            Vida = false;
            Tipo = 0;
        }

        public Planeta(int id, string nombre, string cod, int satelites, float factorGravitacional, bool vida, int tipo)
        {
            Id = id;
            Nombre = nombre;
            Cod = cod;
            Satelites = satelites;
            FactorGravitacional = factorGravitacional;
            Vida = vida;
            Tipo = tipo;
        }



        // crud

        
        public int Crear()
        {

            DBConnection db = DBConnection.DBInit();

            try
            {

                String query = "INSERT INTO planetas (CodPlaneta, Nombre, TipoPlaneta_idTipoPlaneta, Existe_vida) VALUES (@cod, @nombre, @tipo, @vida)";
                using (MySqlCommand command = new MySqlCommand(query, DBConnection.OpenConnection(db)))
                {
                    command.Parameters.AddWithValue("@cod", Cod);
                    command.Parameters.AddWithValue("@nombre", Nombre);
                    command.Parameters.AddWithValue("@tipo", Tipo);
                    command.Parameters.AddWithValue("@vida", Vida?1:0);

                    if (command.ExecuteNonQuery() > 0)
                    {
                        return DBConstants.REGISTER_ADDED;
                    }
                    else return DBConstants.REGISTER_NOT_ADDED;
                }
            }

            catch (MySqlException e)
            {
                return (int)e.ErrorCode;
            }
        }

        public int Read()
        {

            DBConnection db = DBConnection.DBInit();

            try
            {

                String query = "SELECT * FROM planetas WHERE CodPlaneta = @cod";
                using (MySqlCommand command = new MySqlCommand(query, DBConnection.OpenConnection(db)))
                {
                    command.Parameters.AddWithValue("@cod", Cod);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {

                        return reader.HasRows ? DBConstants.REGISTER_FOUNDED : DBConstants.REGISTER_NOT_FOUND;

                    }
                }
            }

            catch (MySqlException e)
            {
                return (int)e.ErrorCode;
            }
        }

        public int Update()
        {

            DBConnection db = DBConnection.DBInit();

            int i = Read();

            if (i == DBConstants.REGISTER_FOUNDED)
            {

                try
                {

                    String query = "UPDATE planetas SET CodPlaneta = @cod, Nombre=@nombre, TipoPlaneta_idTipoPlaneta = @tipo, Existe_vida = @vida WHERE idPlanetas = @id";



                    using (MySqlCommand command = new MySqlCommand(query, DBConnection.OpenConnection(db)))
                    {
                        command.Parameters.AddWithValue("@cod", Cod);


                        command.Parameters.AddWithValue("@id", Id);
                        command.Parameters.AddWithValue("@nombre", Nombre);
                        command.Parameters.AddWithValue("@tipo", Tipo);
                        command.Parameters.AddWithValue("@vida", Vida?1:0);


                        if (command.ExecuteNonQuery() > 0)
                        {
                            return DBConstants.REGISTER_UPDATED;
                        }
                        else return DBConstants.REGISTER_NOT_UPDATED;
                    }
                }

                catch (MySqlException e)
                {
                    return (int)e.ErrorCode;
                }
            }

            else return i;

        }


        public Planeta? ReadObject()
        {


            DBConnection db = DBConnection.DBInit();

            try
            {

                String query = "SELECT * FROM planeta WHERE CodPlaneta = @cod";
                using (MySqlCommand command = new MySqlCommand(query, DBConnection.OpenConnection(db)))
                {
                    command.Parameters.AddWithValue("@cod", Cod);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {


                            Cod = reader.GetString(PlanetaStatics.COD);
                            Nombre = reader.GetString(PlanetaStatics.NOMBRE);
                            Satelites = reader.GetInt32(PlanetaStatics.SATELITES);
                            FactorGravitacional = reader.GetFloat(PlanetaStatics.FACTOR_GRAVITACIONAL);
                            Vida = reader.GetBoolean(PlanetaStatics.VIDA);
                            Tipo = reader.GetInt32(PlanetaStatics.TIPO_PLANETA);
                            Id = reader.GetInt32(PlanetaStatics.ID);

                            return this;
                        }
                        else return null;
                    }
                }
            }

            catch (MySqlException)
            {
                return null;
            }

        }




    }

    public class PlanetaCollection : ObservableCollection<Planeta>
    {
        public void ReadAll()
        {

            DBConnection db = DBConnection.DBInit();

            try
            {

                String query = "SELECT * FROM planetas";
                using (MySqlCommand command = new MySqlCommand(query, DBConnection.OpenConnection(db)))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Add(new Planeta(reader.GetInt32(PlanetaStatics.ID), reader.GetString(PlanetaStatics.COD), reader.GetString(PlanetaStatics.NOMBRE), reader.GetInt32(PlanetaStatics.SATELITES), reader.GetFloat(PlanetaStatics.FACTOR_GRAVITACIONAL), reader.GetBoolean(PlanetaStatics.VIDA), reader.GetInt32(PlanetaStatics.TIPO_PLANETA)));
                        }
                    }
                }
            }

            catch (MySqlException)
            {

            }

        }

        public void AddPlaneta(Planeta planeta)
        {
            if (planeta != null)
            {
                Add(planeta);
            }
        }

        public void RemovePlaneta(Planeta planeta)
        {
            if (planeta != null)
            {
                Remove(planeta);
            }
        }


    }
}
