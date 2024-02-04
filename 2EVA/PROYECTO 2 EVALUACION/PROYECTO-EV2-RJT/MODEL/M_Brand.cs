using MySqlConnector;
using practicaLoginRJT.database;
using System.Collections.ObjectModel;
using PROYECTO_EV2_RJT.CORE.CONSTANTS;
using System.Windows;
using PROYECTO_EV2_RJT.CORE.INTERFACES;
using System.Windows.Media.Imaging;
using PROYECTO_EV2_RJT.CORE.UTILS;
using System.ComponentModel;
using MessageBox = System.Windows.MessageBox;

namespace PROYECTO_EV2_RJT.MODEL
{
    public class M_Brand : ICrud<M_Brand>, INotifyPropertyChanged
    {

        #region Propiertes
        public int Id { get; set; }
        public string Name { get; set; }
        public BitmapImage _image;
        #endregion Propiertes

        #region Builders
        public M_Brand() { }
        public M_Brand(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public BitmapImage Image
        {
            get { return _image; }
            set
            {
                _image = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Image)));
            }
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
                    String query;

                    if (_image == null)
                    {
                        query = "INSERT INTO brands (brand_brand) VALUES (@name)";
                    }
                    else
                    {
                        query = "INSERT INTO brands (brand_brand, brand_image) VALUES (@name, @image)";
                    }

                    using (MySqlCommand command = new MySqlCommand(query, DBConnection.OpenConnection(db)))
                    {
                        command.Parameters.AddWithValue("@name", Name);
                        if (_image != null) command.Parameters.AddWithValue("@image", Utils.ImageToBytes(_image));

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
                    command.Parameters.AddWithValue("@name", Name);
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

            if (i == DBConstants.REGISTER_NOT_FOUND || i == DBConstants.REGISTER_FOUNDED)
            {

                try
                {

                    String query = "UPDATE brands SET brand_brand = @name, brand_image=@image WHERE id_brand = @id";

                    if (_image == null)
                    {
                        query = "UPDATE brands SET brand_brand = @name WHERE id_brand = @id";
                    }

                    using (MySqlCommand command = new MySqlCommand(query, DBConnection.OpenConnection(db)))
                    {
                        command.Parameters.AddWithValue("@name", Name);

                        if (_image != null) command.Parameters.AddWithValue("@image", Utils.ImageToBytes(_image));

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
                        command.Parameters.AddWithValue("@name", Name);
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

        public M_Brand? ReadObject()
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
                            Name = reader.GetString(BrandStatics.NAME);
                            try
                            {
                                byte[] image = reader.GetFieldValue<byte[]>(BrandStatics.IMAGE);
                                if (image != null) _image = Utils.BytesToImage(image);
                            }
                            catch (Exception)
                            {

                            }

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
            return $"{Name}";
        }

        #endregion Methods

    }

    public class M_BrandsCollection : ObservableCollection<M_Brand>, ICollectionCrud<M_Brand>
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
                            M_Brand brand = new M_Brand();
                            brand.Id = reader.GetInt32(BrandStatics.ID);
                            brand.Name = reader.GetString(BrandStatics.NAME);
                            try
                            {
                                byte[] image = reader.GetFieldValue<byte[]>(BrandStatics.IMAGE);
                                if (image != null) brand._image = Utils.BytesToImage(image);
                            }
                            catch (Exception)
                            {

                            }
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


        public void Create(M_Brand brand)
        {
            Add(brand);
        }
        public void Update(int index, M_Brand brand)
        {
            RemoveAt(index);
            Insert(index, brand);

        }
        public void Delete(int index)
        {

            RemoveAt(index);

        }
        public int Read(M_Brand brand)
        {

            foreach (M_Brand item in this)
            {
                if (item.Id == brand.Id) return IndexOf(item);
            }
            return -1;

        }

        #endregion Methods
    }
}
