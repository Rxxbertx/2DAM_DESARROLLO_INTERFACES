using MySqlConnector;
using practicaLoginRJT.database;
using PROYECTO_EV2_RJT.CORE.CONSTANTS;
using PROYECTO_EV2_RJT.CORE.INTERFACES;
using PROYECTO_EV2_RJT.CORE.UTILS;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media.Imaging;

namespace PROYECTO_EV2_RJT.MODEL
{
    public class M_Processor : ICrud<M_Processor>, INotifyPropertyChanged
    {


        public int Id { get; set; }

        public string Name { get; set; }

        public string Manufacturer { get; set; }

        public string Gpu { get; set; }

        public int Cores { get; set; }

        public int Nanometers { get; set; }

        private BitmapImage _image;
        public event PropertyChangedEventHandler? PropertyChanged;


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

        public BitmapImage Image
        {
            get { return _image; }
            set
            {
                _image = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Image)));
            }
        }


        #region CRUD

        public M_Processor? ReadObject()
        {

            DBConnection db = DBConnection.DBInit();



            try
            {

                DBConnection.OpenConnection(db);

                string query = "SELECT * FROM cpu WHERE id_cpu = @id";

                using MySqlCommand command = new(query, DBConnection.OpenConnection(db));

                command.Parameters.AddWithValue("@id", Id);

                using MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {


                    while (reader.Read())
                    {

                        Id = reader.GetInt32(ProcessorStatics.ID);
                        Name = reader.GetString(ProcessorStatics.NAME);
                        Nanometers = reader.GetInt32(ProcessorStatics.NANOMETERS);
                        Gpu = reader.GetString(ProcessorStatics.GPU);
                        Manufacturer = reader.GetString(ProcessorStatics.MANUFACTURER);
                        Cores = reader.GetInt32(ProcessorStatics.CORES);

                        try
                        {
                            byte[] image = reader.GetFieldValue<byte[]>(ProcessorStatics.IMAGE);
                            if (image != null) Image = Utils.BytesToImage(image);
                        }
                        catch (Exception)
                        {

                        }

                    }

                    return this;

                }
                else return null;
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

        public int Update()
        {

            DBConnection db = DBConnection.DBInit();

            int i = Read();

            if (i == DBConstants.REGISTER_NOT_FOUND || i == DBConstants.REGISTER_FOUNDED)
            {


                try
                {

                    DBConnection.OpenConnection(db);


                    string query = "UPDATE cpu SET name_cpu = @name, nanometers_cpu = @nanometers, graphicsrender_cpu = @gpu, manufacturer_cpu = @manufacturer, cores_cpu = @cores, image_cpu = @img WHERE id_cpu = @id";

                    if (Image == null)
                    {
                        query = "UPDATE cpu SET name_cpu = @name, nanometers_cpu = @nanometers, graphicsrender_cpu = @gpu, manufacturer_cpu = @manufacturer, cores_cpu = @cores WHERE id_cpu = @id";
                    }

                    using MySqlCommand command = new(query, DBConnection.OpenConnection(db));

                    command.Parameters.AddWithValue("@name", Name);
                    command.Parameters.AddWithValue("@nanometers", Nanometers);
                    command.Parameters.AddWithValue("@gpu", Gpu);
                    command.Parameters.AddWithValue("@manufacturer", Manufacturer);
                    command.Parameters.AddWithValue("@cores", Cores);
                    command.Parameters.AddWithValue("@id", Id);
                    
                    if (Image != null) { 
                        command.Parameters.AddWithValue("@img", Utils.ImageToBytes(Image));
                    }


                    return command.ExecuteNonQuery() > 0 ? DBConstants.REGISTER_UPDATED : DBConstants.REGISTER_NOT_UPDATED;

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
            else
            {
                return i;
            }

        }

        public int Delete()
        {

            DBConnection db = DBConnection.DBInit();

            int i = Read();

            if (i == DBConstants.REGISTER_FOUNDED)
            {

                try
                {

                    DBConnection.OpenConnection(db);

                    string query = "DELETE FROM cpu WHERE id_cpu = @id";

                    using MySqlCommand command = new(query, DBConnection.OpenConnection(db));

                    command.Parameters.AddWithValue("@id", Id);

                    return command.ExecuteNonQuery() > 0 ? DBConstants.REGISTER_DELETED : DBConstants.REGISTER_NOT_DELETED;

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
            else
            {
                return i;
            }

        }

        public int Read()
        {
            DBConnection db = DBConnection.DBInit();

            try
            {
                DBConnection.OpenConnection(db);

                string query = "SELECT COUNT(*) FROM cpu WHERE name_cpu = @name AND nanometers_cpu = @nanometers AND graphicsrender_cpu = @gpu AND manufacturer_cpu = @manufacturer AND cores_cpu = @cores";


                using MySqlCommand command = new(query, DBConnection.OpenConnection(db));
                command.Parameters.AddWithValue("@name", Name);
                command.Parameters.AddWithValue("@nanometers", Nanometers);
                command.Parameters.AddWithValue("@gpu", Gpu);
                command.Parameters.AddWithValue("@manufacturer", Manufacturer);
                command.Parameters.AddWithValue("@cores", Cores);

                int count = Convert.ToInt32(command.ExecuteScalar());

                return count > 0 ? DBConstants.REGISTER_FOUNDED : DBConstants.REGISTER_NOT_FOUND;
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

        public int Create()
        {
            DBConnection db = DBConnection.DBInit();

            int i = Read();

            if (i == DBConstants.REGISTER_NOT_FOUND)
            {

                try
                {
                    DBConnection.OpenConnection(db);

                    string query = "INSERT INTO cpu (name_cpu, nanometers_cpu, graphicsrender_cpu, manufacturer_cpu, cores_cpu, image_cpu) VALUES (@name, @nanometers, @gpu, @manufacturer, @cores, @img)";

                    if (Image == null)
                    {
                        query = "INSERT INTO cpu (name_cpu, nanometers_cpu, graphicsrender_cpu, manufacturer_cpu, cores_cpu) VALUES (@name, @nanometers, @gpu, @manufacturer, @cores)";
                    }

                    using MySqlCommand command = new(query, DBConnection.OpenConnection(db));
                    command.Parameters.AddWithValue("@name", Name);
                    command.Parameters.AddWithValue("@nanometers", Nanometers);
                    command.Parameters.AddWithValue("@gpu", Gpu);
                    command.Parameters.AddWithValue("@manufacturer", Manufacturer);
                    command.Parameters.AddWithValue("@cores", Cores);

                    if (Image != null)
                    {
                        command.Parameters.AddWithValue("@img", Utils.ImageToBytes(Image));
                    }

                    if (command.ExecuteNonQuery() > 0)
                    {

                        Id = (int)command.LastInsertedId;





                        return DBConstants.REGISTER_ADDED;
                    }
                    else
                    {
                        return DBConstants.REGISTER_NOT_ADDED;

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
            else
                return i;
        }

        #endregion CRUD

        public override string ToString()
        {
            return this.Name + " Gpu: " + this.Gpu + " Nanometros: " + this.Nanometers + "nm Nucleos: " + this.Cores;
           
        }
    }
    public class M_ProcessorsCollection : ObservableCollection<M_Processor>, ICollectionCrud<M_Processor>
    {


        public int Read(M_Processor processor)
        {

            foreach (M_Processor item in this)
            {

                if (item.Id == processor.Id)
                {

                    return IndexOf(item);

                }

            }

            return -1;

        }
        public void Update(int index, M_Processor processor)
        {

            if (index != -1)
            {

                
                RemoveAt(index);
                Insert(index, processor);


            }


        }
        public void Create(M_Processor processor)
        {

            this.Add(processor);
        }
        public void Delete(int index)
        {


            if (index != -1)
            {

                this.RemoveAt(index);

            }

        }

        public void ReadAll()
        {


            DBConnection db = DBConnection.DBInit();
            try
            {
                DBConnection.OpenConnection(db);
                string query = "SELECT * FROM cpu";

                using MySqlCommand command = new(query, DBConnection.OpenConnection(db));

                using MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {

                        M_Processor processor = new()
                        {
                            Id = reader.GetInt32(ProcessorStatics.ID),
                            Name = reader.GetString(ProcessorStatics.NAME),
                            Nanometers = reader.GetInt32(ProcessorStatics.NANOMETERS),
                            Gpu = reader.GetString(ProcessorStatics.GPU),
                            Manufacturer = reader.GetString(ProcessorStatics.MANUFACTURER),
                            Cores = reader.GetInt32(ProcessorStatics.CORES),
                        };

                        try
                        {
                            byte[] image = reader.GetFieldValue<byte[]>(ProcessorStatics.IMAGE);
                            if (image != null) processor.Image = Utils.BytesToImage(image);
                        }
                        catch (Exception)
                        {

                        }



                        this.Add(processor);

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
