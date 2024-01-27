using MySqlConnector;
using practicaLoginRJT.database;
using System.Collections.ObjectModel;
using PROYECTO_EV2_RJT.CORE.CONSTANTS;
using System.Windows;
using PROYECTO_EV2_RJT.CORE.INTERFACES;
using PROYECTO_EV2_RJT.CORE.UTILS;

namespace PROYECTO_EV2_RJT.MODEL
{
    public class M_PhoneStorage : ICrud<M_PhoneStorage>
    {

        #region Propiertes
        public int Id_Phone { get; set; }
        public int Id_Storage { get; set; }
        public M_Storage Storage { get; set; } = new M_Storage();
        public M_Phone Phone { get; set; } = new M_Phone();

        #endregion Propiertes

        #region Builders
        public M_PhoneStorage() { }


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

                    String query = "INSERT INTO phones_storage VALUES (@Id_Phone,@storage)";
                    using (MySqlCommand command = new MySqlCommand(query, DBConnection.OpenConnection(db)))
                    {
                        command.Parameters.AddWithValue("@storage", Id_Storage);
                        command.Parameters.AddWithValue("@Id_Phone", Id_Phone);

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
            else return i;

        }
        //no se si esto esta bien
        public int Read()
        {

            DBConnection db = DBConnection.DBInit();

            try
            {

                String query = "SELECT * FROM view_phones_brands_storage WHERE storage = @storage AND idPhone = @Id_Phone";
                using (MySqlCommand command = new MySqlCommand(query, DBConnection.OpenConnection(db)))
                {
                    command.Parameters.AddWithValue("@storage", Id_Storage);
                    command.Parameters.AddWithValue("@Id_Phone", Id_Phone);



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

            if (i == DBConstants.REGISTER_NOT_FOUND)
            {

                try
                {

                    String query = "UPDATE phones_storage SET storage_storage = @storage, id_phone = @Id_Phone WHERE id_phone = @Id_Phone1 and storage_storage = @storage1";
                    using (MySqlCommand command = new MySqlCommand(query, DBConnection.OpenConnection(db)))
                    {
                        command.Parameters.AddWithValue("@Id_Phone", Id_Phone);
                        command.Parameters.AddWithValue("@storage", Id_Storage);
                        command.Parameters.AddWithValue("@Id_Phone1", Phone.Id);
                        command.Parameters.AddWithValue("@storage1", Storage.Storage);


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
        public int Delete()
        {

            DBConnection db = DBConnection.DBInit();

            int i = Read();

            if (i == DBConstants.REGISTER_FOUNDED)
            {

                try
                {

                    String query = "DELETE FROM phones_storage WHERE storage_storage = @storage AND id_phone = @Id_Phone";
                    using (MySqlCommand command = new MySqlCommand(query, DBConnection.OpenConnection(db)))
                    {
                        command.Parameters.AddWithValue("@storage", Id_Storage);
                        command.Parameters.AddWithValue("@Id_Phone", Id_Phone);
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


        public M_PhoneStorage? ReadObject()
        {


            DBConnection db = DBConnection.DBInit();

            try
            {

                String query = "SELECT * FROM view_phones_brands_storage WHERE storage = @storage and idPhone = @Id_Phone";
                using (MySqlCommand command = new MySqlCommand(query, DBConnection.OpenConnection(db)))
                {
                    command.Parameters.AddWithValue("@storage", Id_Storage);
                    command.Parameters.AddWithValue("@Id_Phone", Id_Phone);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            Id_Phone = reader.GetInt32(StoragePhoneViewStatics.ID);
                            Id_Storage = reader.GetInt32(StoragePhoneViewStatics.STORAGE);
                            Storage.Storage = Id_Storage;
                            Phone.Id = Id_Phone;



                        }
                        else
                        {
                            return null;
                        }

                        reader.Close();
                    }
                    command.Dispose();
                }
            }

            catch (MySqlException)
            {
                return null;
            }



            if (Storage.ReadObject() is M_Storage storage)
            {


                Storage = storage;

            }

            if (Phone.ReadObject() is M_Phone phone)
            {

                Phone = phone;
            }



            return this;

        }



        public override string ToString()
        {
            return $"Capacidad: {Storage.Storage}";
        }

        #endregion Methods

    }

    public class M_PhoneStoragesCollection : ObservableCollection<M_PhoneStorage>, ICollectionCrud<M_PhoneStorage>
    {

        #region Methods

        public void ReadAll()
        {


            DBConnection db = DBConnection.DBInit();

            try
            {

                String query = "SELECT * FROM view_phones_brands_storage";
                using (MySqlCommand command = new MySqlCommand(query, DBConnection.OpenConnection(db)))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            M_PhoneStorage phone_storage = new M_PhoneStorage();
                            phone_storage.Id_Phone = reader.GetInt32(StoragePhoneViewStatics.ID);
                            phone_storage.Id_Storage = reader.GetInt32(StoragePhoneViewStatics.STORAGE);
                            phone_storage.Storage.Storage = phone_storage.Id_Storage;
                            phone_storage.Phone.Id = phone_storage.Id_Phone;
                            phone_storage.Phone.Model = reader.GetString(StoragePhoneViewStatics.MODEL);
                            phone_storage.Phone.Brand.Name = reader.GetString(StoragePhoneViewStatics.BRAND);

                            try
                            {
                                byte[] img = reader.GetFieldValue<byte[]>(StoragePhoneViewStatics.BRAND_IMAGE);
                                if (img != null)
                                {
                                    phone_storage.Phone.Brand.Image = Utils.BytesToImage(img);
                                }
                            }
                            catch (Exception)
                            {

                                throw;
                            }

                            Add(phone_storage);
                        }
                    }
                }


            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
                throw;
            }




        }


        public void Create(M_PhoneStorage storage)
        {
            Add(storage);

        }
        public void Update(int index, M_PhoneStorage storage)
        {

            RemoveAt(index);
            Insert(index, storage);


        }
        public void Delete(int index)
        {

            RemoveAt(index);

        }
        public int Read(M_PhoneStorage storage)
        {

            foreach (M_PhoneStorage item in this)
            {
                if (item.Id_Storage == storage.Id_Storage && item.Id_Phone == storage.Id_Phone) return IndexOf(item);
            }
            return -1;

        }

        #endregion Methods
    }
}
