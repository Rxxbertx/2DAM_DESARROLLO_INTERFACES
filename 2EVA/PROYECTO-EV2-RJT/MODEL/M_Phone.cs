using MySqlConnector;
using practicaLoginRJT.database;
using System.Collections.ObjectModel;
using PROYECTO_EV2_RJT.CORE.CONSTANTS;
using System.Windows;
using PROYECTO_EV2_RJT.CORE.INTERFACES;
using System.Windows.Controls;

namespace PROYECTO_EV2_RJT.MODEL
{
    public class M_Phone : ICrud<M_Phone>
    {

        #region Propiertes
        public int Id { get; set; }
        public string Model { get; set; }
        public M_Brand Brand { get; set; } = new M_Brand();
        public M_Processor Processor { get; set; } = new M_Processor();
        public int Ram { get; set; }
        public int Battery { get; set; }
        public float Screen { get; set; }
        public Image Image { get; set; }



        #endregion Propiertes

        #region Builders
        public M_Phone() { }
        public M_Phone(int id, string name)
        {
            Id = id;
            Model = name;
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

                    String query = "INSERT INTO brands (brand_brand) VALUES (@name)";
                    using (MySqlCommand command = new MySqlCommand(query, DBConnection.OpenConnection(db)))
                    {
                        command.Parameters.AddWithValue("@name", Model);

                        if (command.ExecuteNonQuery() > 0)
                        {

                            Id = (int)command.LastInsertedId;


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

                String query = "SELECT * FROM brands WHERE brand_brand = @name";
                using (MySqlCommand command = new MySqlCommand(query, DBConnection.OpenConnection(db)))
                {
                    command.Parameters.AddWithValue("@name", Model);
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

                    String query = "UPDATE brands SET brand_brand = @name WHERE id_brand = @id";
                    using (MySqlCommand command = new MySqlCommand(query, DBConnection.OpenConnection(db)))
                    {
                        command.Parameters.AddWithValue("@name", Model);
                        command.Parameters.AddWithValue("@id", Id);
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

                    String query = "DELETE FROM brands WHERE brand_brand = @name";
                    using (MySqlCommand command = new MySqlCommand(query, DBConnection.OpenConnection(db)))
                    {
                        command.Parameters.AddWithValue("@name", Model);
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


            DBConnection db = DBConnection.DBInit();

            try
            {

                String query = "SELECT * FROM brands WHERE id_brand = @id";
                using (MySqlCommand command = new MySqlCommand(query, DBConnection.OpenConnection(db)))
                {
                    command.Parameters.AddWithValue("@id", Id);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Id = reader.GetInt32(BrandStatics.ID);
                            Model = reader.GetString(BrandStatics.NAME);
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
            return $"Marca: {Model}";
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

                String query = "SELECT * FROM brands";
                using (MySqlCommand command = new MySqlCommand(query, DBConnection.OpenConnection(db)))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            M_Phone brand = new M_Phone();
                            brand.Id = reader.GetInt32(BrandStatics.ID);
                            brand.Model = reader.GetString(BrandStatics.NAME);
                            Add(brand);
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


        public void Create(M_Phone brand)
        {
            Add(brand);
        }
        public void Update(int index, M_Phone brand)
        {

            this[index] = brand;

        }
        public void Delete(int index)
        {

            RemoveAt(index);

        }
        public int Read(M_Phone brand)
        {

            foreach (M_Phone item in this)
            {
                if (item.Id == brand.Id) return IndexOf(item);
            }
            return -1;

        }

        #endregion Methods
    }
}
