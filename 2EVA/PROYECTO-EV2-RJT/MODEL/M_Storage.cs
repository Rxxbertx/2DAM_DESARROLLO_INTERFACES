using MySqlConnector;
using practicaLoginRJT.database;
using System.Collections.ObjectModel;
using PROYECTO_EV2_RJT.CORE.CONSTANTS;
using System.Windows;
using PROYECTO_EV2_RJT.CORE.INTERFACES;

namespace PROYECTO_EV2_RJT.MODEL
{
    public class M_Storage : ICrud<M_Storage>
    {

        #region Propiertes
        public int Storage { get; set; }
        public int OldStorage { get; set; }
        #endregion Propiertes

        #region Builders
        public M_Storage() { }
        public M_Storage(int storage)
        {
           
            Storage = storage;
            OldStorage = storage;
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

                    String query = "INSERT INTO storages (storage_storage) VALUES (@storage)";
                    using (MySqlCommand command = new MySqlCommand(query, DBConnection.OpenConnection(db)))
                    {
                        command.Parameters.AddWithValue("@storage", Storage);

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
        public int Read()
        {

            DBConnection db = DBConnection.DBInit();

            try
            {

                String query = "SELECT * FROM storages WHERE storage_storage = @storage";
                using (MySqlCommand command = new MySqlCommand(query, DBConnection.OpenConnection(db)))
                {
                    command.Parameters.AddWithValue("@storage", Storage);
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

                    String query = "UPDATE storages SET storage_storage = @new_storage WHERE storage_storage = @old_storage";
                    using (MySqlCommand command = new MySqlCommand(query, DBConnection.OpenConnection(db)))
                    {
                        command.Parameters.AddWithValue("@old_storage", OldStorage);
                        command.Parameters.AddWithValue("@new_storage", Storage);
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

                    String query = "DELETE FROM storages WHERE storage_storage = @storage";
                    using (MySqlCommand command = new MySqlCommand(query, DBConnection.OpenConnection(db)))
                    {
                        command.Parameters.AddWithValue("@storage", Storage);
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

        public M_Storage? ReadObject()
        {


            DBConnection db = DBConnection.DBInit();

            try
            {

                String query = "SELECT * FROM storages WHERE storage_storage = @storage";
                using (MySqlCommand command = new MySqlCommand(query, DBConnection.OpenConnection(db)))
                {
                    command.Parameters.AddWithValue("@storage", Storage);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Storage = reader.GetInt32(StorageStatics.STORAGE);
                            
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



        public override string ToString()
        {
            return $"{Storage}";
        }

        #endregion Methods

    }

    public class M_StoragesCollection : ObservableCollection<M_Storage>, ICollectionCrud<M_Storage>
    {

        #region Methods

        public void ReadAll()
        {
            

            DBConnection db = DBConnection.DBInit();

            try
            {

                String query = "SELECT * FROM storages";
                using (MySqlCommand command = new MySqlCommand(query, DBConnection.OpenConnection(db)))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            M_Storage storage = new M_Storage();
                            storage.Storage = reader.GetInt32(StorageStatics.STORAGE);
                                
                            Add(storage);
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


        public void Create(M_Storage storage)
        {
            Add(storage);
            
        }
        public void Update(int index, M_Storage storage)
        {

            this[index] = storage;

        }
        public void Delete(int index)
        {

            RemoveAt(index);

        }
        public int Read(M_Storage storage)
        {

            foreach (M_Storage item in this)
            {
                if (item.Storage == storage.Storage) return IndexOf(item);
            }
            return -1;

        }

        #endregion Methods
    }
}
