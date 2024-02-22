using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Ado.net_homework1
{
    internal class BrandService
    {
        public void InsertBrands(string name, DateTime dateTime)
        {
            string connectionStr = "Server=DESKTOP-U6B6T1F\\SQLEXPRESS;Database=Shop;Trusted_Connection=true";
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string query = "insert into Brands (Name,Date) values (@name,@date)";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@date", dateTime);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Brands> GetAllBrands()
        {
            List<Brands> brands = new List<Brands>();
            string connectionStr = "Server=DESKTOP-U6B6T1F\\SQLEXPRESS;Database=Shop;Trusted_Connection=true";
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string query = "select Id, Name, Date from Brands";
                SqlCommand cmd = new SqlCommand(query, connection);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Brands brand = new Brands()
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Date = reader.GetDateTime(2),
                        };
                        brands.Add(brand);
                    }
                }
            }
            return brands;
        }

        public Brands GetBrandById(int id)
        {
            Brands brand = null;
            string connectionStr = "Server=DESKTOP-U6B6T1F\\SQLEXPRESS;Database=Shop;Trusted_Connection=true";
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string query = "select TOP(1) * from Brands where Id=@id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows) return null;
                    while (reader.Read())
                    {
                        brand = new Brands();
                        brand.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        brand.Name = reader.GetString(reader.GetOrdinal("Name"));
                        brand.Date = reader.GetDateTime(reader.GetOrdinal("Date"));
                    }
                }
            }
            return brand;
        }

        public Brands DeleteBrandById(int id)
        {
            Brands brand = null;
            string connectionStr = "Server=DESKTOP-U6B6T1F\\SQLEXPRESS;Database=Shop;Trusted_Connection=true";
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string query = "Delete From Brands where Id=@id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            return brand;
        }

        public void UpdateBrandById(int id, string name, DateTime dateTime)
        {
            string connectionStr = "Server=DESKTOP-U6B6T1F\\SQLEXPRESS;Database=Shop;Trusted_Connection=true";
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string query = "UPDATE Brands SET Name = @name, Date =@date WHERE Id = @id";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@date", dateTime);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        //public Brands UpdateBrandById2(int id, string name, DateTime dateTime)
        //{
        //    Brands brand = null;
        //    string connectionStr = "Server=DESKTOP-U6B6T1F\\SQLEXPRESS;Database=Shop;Trusted_Connection=true";
        //    using (SqlConnection connection = new SqlConnection(connectionStr))
        //    {
        //        connection.Open();
        //        string query = "UPDATE Brands SET Name = @name, Date =@date WHERE Id = @id";
        //        SqlCommand cmd = new SqlCommand(query, connection);
        //        cmd.Parameters.AddWithValue("@id", id);
        //        cmd.Parameters.AddWithValue("@name", name);
        //        cmd.Parameters.AddWithValue("@date", dateTime);
        //        cmd.ExecuteNonQuery();
        //    }
        //    return brand;
        //}


    }
}
