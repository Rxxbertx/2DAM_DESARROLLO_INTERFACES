using MySqlConnector;
using practicaLoginRJT.database;
using PROYECTO_EV2_RJT.CORE.CONSTANTS;
using System.Collections.ObjectModel;
using System.Windows;

namespace PROYECTO_EV2_RJT.MODEL


{



    public class M_Processor
    {


        public int Id { get; set; }

        public string Name { get; set; }

        public string Manufacturer { get; set; }

        public string Gpu { get; set; }

        public int Cores { get; set; }

        public int Nanometers { get; set; }


        public M_Processor()
        {

        }


        public M_Processor(int id, string name, int nanometers, string gpu, string manufacturer, int cores)
        {

            this.Id = id;
            this.Name = name;
            this.Manufacturer = manufacturer;
            this.Gpu = gpu;
            this.Cores = cores;
            this.Nanometers = nanometers;

        }


        #region CRUD

        public M_Processor? findCpu(int id)
        {

            DBConnection db = DBConnection.DBInit();

            try
            {

                DBConnection.OpenConnection(db);

                string query = "SELECT * FROM cpu WHERE id_cpu = @id";

                using (MySqlCommand command = new(query, DBConnection.OpenConnection(db)))
                {

                    command.Parameters.AddWithValue("@id", id);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {

                        if (reader.HasRows)
                        {
                            

                            while (reader.Read())
                            {

                                Id = reader.GetInt32(0);
                                Name = reader.GetString(1);
                                Nanometers = reader.GetInt32(5);
                                Gpu = reader.GetString(3);
                                Manufacturer = reader.GetString(2);
                                Cores = reader.GetInt32(4);


                            }

                            return this;

                        }
                        else return null;

                    }
                }
            }
            catch (MySqlException s)
            {

                MessageBox.Show(s.Message);

                return null;

            }
            finally
            {

                DBConnection.CloseConnection(db);

            }


        }

        public int CheckIfProcessorExists()
        {
            DBConnection db = DBConnection.DBInit();

            try
            {
                DBConnection.OpenConnection(db);

                string query = "SELECT COUNT(*) FROM cpu WHERE name_cpu = @name AND nanometers_cpu = @nanometers AND graphicsrender_cpu = @gpu AND manufacturer_cpu = @manufacturer";

                using (MySqlCommand command = new(query, DBConnection.OpenConnection(db)))
                {
                    command.Parameters.AddWithValue("@name", Name);
                    command.Parameters.AddWithValue("@nanometers", Nanometers);
                    command.Parameters.AddWithValue("@gpu", Gpu);
                    command.Parameters.AddWithValue("@manufacturer", Manufacturer);

                    int count = Convert.ToInt32(command.ExecuteScalar());

                    return count > 0 ? DBConstants.REGISTER_FOUNDED : DBConstants.REGISTER_NOT_FOUND;
                }
            }
            catch (MySqlException s)
            {

                return (int)s.ErrorCode;
            }
            finally
            {
                DBConnection.CloseConnection(db);
            }
        }


        public int AddProcessor()
        {
            DBConnection db = DBConnection.DBInit();

            int i = CheckIfProcessorExists();

            if (i == DBConstants.REGISTER_NOT_FOUND)
            {

                try
                {
                    DBConnection.OpenConnection(db);

                    string query = "INSERT INTO cpu (name_cpu, nanometers_cpu, graphicsrender_cpu, manufacturer_cpu, cores_cpu) VALUES (@name, @nanometers, @gpu, @manufacturer, @cores)";

                    using (MySqlCommand command = new(query, DBConnection.OpenConnection(db)))
                    {
                        command.Parameters.AddWithValue("@name", Name);
                        command.Parameters.AddWithValue("@nanometers", Nanometers);
                        command.Parameters.AddWithValue("@gpu", Gpu);
                        command.Parameters.AddWithValue("@manufacturer", Manufacturer);
                        command.Parameters.AddWithValue("@cores", Cores);

                        if (command.ExecuteNonQuery() > 0)
                        {
                           return DBConstants.REGISTER_ADDED;
                        }
                        return DBConstants.SQL_EXCEPTION;

                    }
                }
                catch (MySqlException s)
                {
                    return (int)s.ErrorCode;
                }
                finally
                {
                    DBConnection.CloseConnection(db);
                }


            }else
                return i;
        }

        #endregion CRUD


    }

    public class M_ProcessorsCollection : ObservableCollection<M_Processor>
    {




        public void AddProcessor(M_Processor processor)
        {


            this.Add(processor);

        }

        public void RemoveProcessor(M_Processor processor)
        {

            this.Remove(processor);

        }

        public void LoadProcessors()
        {

            DBConnection db = DBConnection.DBInit();


            try
            {

                DBConnection.OpenConnection(db);

                string query = "SELECT * FROM cpu";

                using (MySqlCommand command = new(query, DBConnection.OpenConnection(db)))
                {

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {

                        if (reader.HasRows)
                        {

                            while (reader.Read())
                            {

                                M_Processor processor = new M_Processor();

                                processor.Id = reader.GetInt32(M_ProcessorsStatics.ID);
                                processor.Name = reader.GetString(M_ProcessorsStatics.NAME);
                                processor.Nanometers = reader.GetInt32(M_ProcessorsStatics.NANOMETERS);
                                processor.Gpu = reader.GetString(M_ProcessorsStatics.GPU);
                                processor.Manufacturer = reader.GetString(M_ProcessorsStatics.MANUFACTURER);
                                processor.Cores = reader.GetInt32(M_ProcessorsStatics.CORES);


                                this.Add(processor);

                            }

                        }

                    }


                }

            }
            catch (MySqlException s)
            {

                MessageBox.Show(s.Message);


            }
            finally
            {

                DBConnection.CloseConnection(db);

            }


        }






    }
}
