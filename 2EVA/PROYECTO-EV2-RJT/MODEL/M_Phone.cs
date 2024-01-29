using MySqlConnector;
using practicaLoginRJT.database;
using System.Collections.ObjectModel;
using PROYECTO_EV2_RJT.CORE.CONSTANTS;
using System.Windows;
using PROYECTO_EV2_RJT.CORE.INTERFACES;
using System.Windows.Controls;
using System.Runtime.InteropServices;
using System.Windows.Media.Imaging;
using PROYECTO_EV2_RJT.CORE.UTILS;
using System.ComponentModel;
using MessageBox = System.Windows.MessageBox;

namespace PROYECTO_EV2_RJT.MODEL
{
    public class M_Phone : ICrud<M_Phone>, INotifyPropertyChanged
    {

        #region Propiertes
        public int Id { get; set; }
        public string Model { get; set; }
        public M_Brand Brand { get; set; } = new M_Brand();
        public M_Processor Processor { get; set; } = new M_Processor();
        public List<M_Storage> Storage { get; set; } = new List<M_Storage>();
        public string Os { get; set; }
        public int Ram { get; set; }
        public int Battery { get; set; }
        public float Screen { get; set; }

        private BitmapImage _image;

        public BitmapImage Image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Image)));
            }
        }

public event PropertyChangedEventHandler? PropertyChanged;


        #endregion Propiertes

        #region Builders
        public M_Phone() { }
        public M_Phone(int id, string model, M_Brand brand, M_Processor processor, List<M_Storage> storage, string os, int ram, int battery, float screen, BitmapImage image)
        {
            Id = id;
            Model = model;
            Brand = brand;
            Processor = processor;
            Storage = storage;
            Os = os;
            Ram = ram;
            Battery = battery;
            Screen = screen;
            Image = image;
        }

    
        #endregion Builders

        #region Methods


        public int Create()
        {

            DBConnection db = DBConnection.DBInit();

            int i = Read();
            if (i == DBConstants.REGISTER_NOT_FOUND)
            {


                try
                {



                    String query = "INSERT INTO phones (model_phone, screen_phone, operatingsystem_phone, ram_phone, battery_phone, brand_phone_brand, cpu_phone_cpu) VALUES (@model, @screen, @os, @ram, @battery, @id_brand, @id_processor)";

                    if (Image != null) query = "INSERT INTO phones (model_phone, screen_phone, operatingsystem_phone, ram_phone, battery_phone, brand_phone_brand, cpu_phone_cpu, image_phone) VALUES (@model, @screen, @os, @ram, @battery, @id_brand, @id_processor, @image)";

                    using (MySqlCommand command = new MySqlCommand(query, DBConnection.OpenConnection(db)))
                    {
                        command.Parameters.AddWithValue("@model", Model);
                        command.Parameters.AddWithValue("@screen", Screen);
                        command.Parameters.AddWithValue("@os", Os);
                        command.Parameters.AddWithValue("@ram", Ram);
                        command.Parameters.AddWithValue("@battery", Battery);
                        command.Parameters.AddWithValue("@id_brand", Brand.Id);
                        command.Parameters.AddWithValue("@id_processor", Processor.Id);
                        


                        if (Image != null) command.Parameters.AddWithValue("@image", Utils.ImageToBytes(Image));


                        if (command.ExecuteNonQuery() > 0)
                        {   Id = (int)command.LastInsertedId;
                            command.Dispose();
                            

                            foreach (M_Storage storage in Storage)
                            {
                                String insertStorageQuery = "INSERT INTO phones_storage (id_phone, storage_storage) VALUES (@phoneId, @storageId)";
                                using (MySqlCommand insertStorageCommand = new MySqlCommand(insertStorageQuery, DBConnection.OpenConnection(db)))
                                {
                                    insertStorageCommand.Parameters.AddWithValue("@phoneId", Id);
                                    insertStorageCommand.Parameters.AddWithValue("@storageId", storage.Storage);
                                    insertStorageCommand.ExecuteNonQuery();
                                }
                            }

                            return DBConstants.REGISTER_ADDED;
                        }
                        else return DBConstants.REGISTER_NOT_ADDED;
                    }
                }

                catch (MySqlException e)
                {
                    MessageBox.Show(e.Message);
                    return (int)e.ErrorCode;
                }


            }
            else return i;

        }
        public int Read()
        {
            DBConnection db = DBConnection.DBInit();

            try
            {
                String query = "SELECT * FROM phones WHERE model_phone = @model and screen_phone = @screen and operatingsystem_phone = @os and ram_phone = @ram and battery_phone = @battery and brand_phone_brand = @id_brand and cpu_phone_cpu = @id_processor";
                using (MySqlCommand command = new MySqlCommand(query, DBConnection.OpenConnection(db)))
                {
                    command.Parameters.AddWithValue("@model", Model);
                    command.Parameters.AddWithValue("@screen", Screen);
                    command.Parameters.AddWithValue("@os", Os);
                    command.Parameters.AddWithValue("@ram", Ram);
                    command.Parameters.AddWithValue("@battery", Battery);
                    command.Parameters.AddWithValue("@id_brand", Brand.Id);
                    command.Parameters.AddWithValue("@id_processor", Processor.Id);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            return DBConstants.REGISTER_NOT_FOUND;
                        }
                        return DBConstants.REGISTER_FOUNDED;
                    }
                }


            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
                return (int)e.ErrorCode;
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
                    String query = "UPDATE phones SET model_phone = @model, screen_phone = @screen, operatingsystem_phone = @os, ram_phone = @ram, battery_phone = @battery, brand_phone_brand = @id_brand, cpu_phone_cpu = @id_processor WHERE id_phone = @id";


                    if (Image != null) query = "UPDATE phones SET model_phone = @model, screen_phone = @screen, operatingsystem_phone = @os, ram_phone = @ram, battery_phone = @battery, brand_phone_brand = @id_brand, cpu_phone_cpu = @id_processor, image_phone = @image WHERE id_phone = @id";

                    using (MySqlCommand command = new MySqlCommand(query, DBConnection.OpenConnection(db)))
                    {
                        command.Parameters.AddWithValue("@model", Model);
                        command.Parameters.AddWithValue("@screen", Screen);
                        command.Parameters.AddWithValue("@os", Os);
                        command.Parameters.AddWithValue("@ram", Ram);
                        command.Parameters.AddWithValue("@battery", Battery);
                        command.Parameters.AddWithValue("@id_brand", Brand.Id);
                        command.Parameters.AddWithValue("@id_processor", Processor.Id);
                        command.Parameters.AddWithValue("@id", Id);

                        if (Image != null) command.Parameters.AddWithValue("@image", Utils.ImageToBytes(Image));

                        if (command.ExecuteNonQuery() > 0)
                        {
                            command.Dispose();
                            // Actualizar los datos de almacenamiento
                            String deleteStorageQuery = "DELETE FROM phones_storage WHERE id_phone = @phoneId";
                            using (MySqlCommand deleteStorageCommand = new MySqlCommand(deleteStorageQuery, DBConnection.OpenConnection(db)))
                            {
                                deleteStorageCommand.Parameters.AddWithValue("@phoneId", Id);
                                deleteStorageCommand.ExecuteNonQuery();
                            }

                            foreach (M_Storage storage in Storage)
                            {
                                String insertStorageQuery = "INSERT INTO phones_storage (id_phone, storage_storage) VALUES (@phoneId, @storageId)";
                                using (MySqlCommand insertStorageCommand = new MySqlCommand(insertStorageQuery, DBConnection.OpenConnection(db)))
                                {
                                    insertStorageCommand.Parameters.AddWithValue("@phoneId", Id);
                                    insertStorageCommand.Parameters.AddWithValue("@storageId", storage.Storage);
                                    insertStorageCommand.ExecuteNonQuery();
                                }
                            }

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

        public int Delete()
        {

            DBConnection db = DBConnection.DBInit();

            int i = Read();

            if (i == DBConstants.REGISTER_FOUNDED)
            {

                try
                {

                    String query = "DELETE FROM phones WHERE id_phone = @id";
                    using (MySqlCommand command = new MySqlCommand(query, DBConnection.OpenConnection(db)))
                    {
                        command.Parameters.AddWithValue("@id", Id);
                        if (command.ExecuteNonQuery() > 0)
                        {
                            return DBConstants.REGISTER_DELETED;
                        }
                        else return DBConstants.REGISTER_NOT_DELETED;
                    }
                }

                catch (MySqlException e)
                {
                    return (int)e.ErrorCode;
                }
            }

            else return i;

        }

        public M_Phone? ReadObject()
        {
            int id_cpu;
            int id_brand;

            DBConnection db = DBConnection.DBInit();

            try
            {

                String query = "SELECT * FROM phones WHERE id_phone = @id";
                using (MySqlCommand command = new MySqlCommand(query, DBConnection.OpenConnection(db)))
                {
                    command.Parameters.AddWithValue("@id", Id);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Id = reader.GetInt32(PhoneStatics.ID);
                            Model = reader.GetString(PhoneStatics.MODEL);
                            id_brand = reader.GetInt32(PhoneStatics.BRAND);
                            id_cpu = reader.GetInt32(PhoneStatics.PROCESSOR);
                            Os = reader.GetString(PhoneStatics.OS);
                            Ram = reader.GetInt32(PhoneStatics.RAM);
                            Battery = reader.GetInt32(PhoneStatics.BATTERY);
                            Screen = reader.GetFloat(PhoneStatics.SCREEN);


                            try
                            {

                                byte[] temp = reader.GetFieldValue<byte[]>(PhoneStatics.IMAGE);
                                if (temp != null)
                                {

                                    Image = Utils.BytesToImage(temp);

                                }

                            }
                            catch (Exception)
                            {


                            }




                        }
                        else return null;
                    }
                }
            }

            catch (MySqlException)
            {
                return null;
            }

            Brand.Id = id_brand;
            Processor.Id = id_cpu;

            Brand = Brand.ReadObject();
            Processor = Processor.ReadObject();

            if (Brand == null || Processor == null) return null;


            try
            {


                String query = "SELECT * FROM phones_storage WHERE id_phone = @id";
                using (MySqlCommand command = new MySqlCommand(query, DBConnection.OpenConnection(db)))
                {
                    command.Parameters.AddWithValue("@id", Id);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            M_Storage storage = new M_Storage();
                            storage.Storage = reader.GetInt32(PhoneStorageStatics.STORAGE);
                            if (storage == null || storage.Storage < 1) return null;
                            Storage.Add(storage);
                        }
                    }
                }

            }
            catch (MySqlException)
            {

                return null;
            }

            return this;


        }



        public override string ToString()
        {
            return $"{Brand.Name} {Model}, {Processor.Name}, {Screen}\", {Battery}mah, {Ram}GB Ram";
        }

        #endregion Methods

    }

    public class M_PhonesCollection : ObservableCollection<M_Phone>, ICollectionCrud<M_Phone>
    {

        #region Methods

        public void ReadAll()
        {

            DBConnection db = DBConnection.DBInit();


            try
            {


                // Leer todos los datos de almacenamiento en un diccionario
                Dictionary<int, List<M_Storage>> storageData = new Dictionary<int, List<M_Storage>>();
                String storageQuery = "SELECT * FROM phones_storage";
                using (MySqlCommand storageCommand = new MySqlCommand(storageQuery, DBConnection.OpenConnection(db)))
                {
                    using (MySqlDataReader storageReader = storageCommand.ExecuteReader())
                    {
                        while (storageReader.Read())
                        {
                            int phoneId = storageReader.GetInt32("id_phone");
                            int storageId = storageReader.GetInt32("storage_storage");

                            if (!storageData.ContainsKey(phoneId))
                            {
                                storageData[phoneId] = new List<M_Storage>();
                            }

                            M_Storage storage = new M_Storage();
                            storage.Storage = storageId;
                            storageData[phoneId].Add(storage);
                        }
                    }
                }



                String query = "SELECT phones.*, brands.*, cpu.* FROM phones " +
                               "INNER JOIN brands ON phones.brand_phone_brand = brands.id_brand " +
                               "INNER JOIN cpu ON phones.cpu_phone_cpu = cpu.id_cpu";
                using (MySqlCommand command = new MySqlCommand(query, DBConnection.OpenConnection(db)))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            M_Phone phone = new M_Phone();
                            phone.Id = reader.GetInt32("id_phone");
                            phone.Model = reader.GetString("model_phone");
                            phone.Brand.Id = reader.GetInt32("id_brand");
                            phone.Brand.Name = reader.GetString("brand_brand");
                            phone.Processor.Id = reader.GetInt32("id_cpu");
                            phone.Processor.Name = reader.GetString("name_cpu");
                            phone.Processor.Manufacturer = reader.GetString("manufacturer_cpu");
                            phone.Processor.Gpu = reader.GetString("graphicsrender_cpu");
                            phone.Processor.Cores = reader.GetInt32("cores_cpu");
                            phone.Processor.Nanometers = reader.GetInt32("nanometers_cpu");
                            phone.Os = reader.GetString("operatingsystem_phone");
                            phone.Ram = reader.GetInt32("ram_phone");
                            phone.Battery = reader.GetInt32("battery_phone");
                            phone.Screen = reader.GetFloat("screen_phone");


                            try
                            {
                                //como leeo la imagen de brand

                                int i = reader.GetOrdinal("image_cpu");

                                byte[] temp = reader.GetFieldValue<byte[]>(i);
                                if (temp != null)
                                {

                                    phone.Processor.Image = Utils.BytesToImage(temp);

                                }




                            }
                            catch (Exception)
                            {


                            }



                            try
                            {
                                //como leeo la imagen de brand

                                int i = reader.GetOrdinal("brand_image");

                                byte[] temp = reader.GetFieldValue<byte[]>(i);
                                if (temp != null)
                                {

                                    phone.Brand.Image = Utils.BytesToImage(temp);

                                }




                            }
                            catch (Exception)
                            {

                                
                            }

                            try
                            {

                                byte[] temp = reader.GetFieldValue<byte[]>(PhoneStatics.IMAGE);
                                if (temp != null)
                                {

                                    phone.Image = Utils.BytesToImage(temp);

                                }

                            }
                            catch (Exception)
                            {


                            }


                            if (storageData.ContainsKey(phone.Id))
                            {
                                phone.Storage = storageData[phone.Id];
                            }

                            Add(phone);
                        }
                    }
                }
            }
            catch (MySqlException)
            {
                // Manejar la excepción
            }


        }


        public void Create(M_Phone phone)
        {
            Add(phone);
        }
        public void Update(int index, M_Phone phone)
        {

            RemoveAt(index);
            Insert(index, phone);
            

        }
        public void Delete(int index)
        {

            RemoveAt(index);

        }
        public int Read(M_Phone phone)
        {

            foreach (M_Phone item in this)
            {
                if (item.Id == phone.Id) return IndexOf(item);
            }
            return -1;

        }

        #endregion Methods
    }
}
