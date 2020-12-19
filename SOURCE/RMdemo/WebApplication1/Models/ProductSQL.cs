using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebApplication1.Data;

namespace WebApplication1.Models
{
    public class ProductSQL : IRepositorySQL
    {
        public void DeleteByID(int id)
        {
            try
            {
                DataTable dt = new DataTable();
                string constring = System.Configuration.ConfigurationManager.ConnectionStrings["mysqldb"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(constring))
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand("DeleteProduct", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@del_ID", id);
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Product FindByID(int id)
        {
            var product = new Product();
            try
            {
                DataTable dt = new DataTable();
                string constring = System.Configuration.ConfigurationManager.ConnectionStrings["mysqldb"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(constring))
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand("FindProductByID", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@new_ID", id);
                        cmd.ExecuteNonQuery();
                        using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                        product.ProductID = id;
                        product.Description = Convert.ToString(dt.Rows[0]["ProductDescription"]);
                        product.Code = Convert.ToString(dt.Rows[0]["ProductCode"]);
                        product.Type = Convert.ToInt32(dt.Rows[0]["TypeID"]);
                        product.Amount = Convert.ToInt32(dt.Rows[0]["Amount"]);
                        product.Price = Convert.ToDouble(dt.Rows[0]["Price"]);
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return product;
        }

        public List<Product> GetAllData()
        {
            DataTable dt = new DataTable();
            try
            {
                string constring = System.Configuration.ConfigurationManager.ConnectionStrings["mysqldb"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(constring))
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand("ProductsGetAll", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                        using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            var ProductList = new List<Product>();
            if (dt != null)
            {
                foreach (DataRow item in dt.Rows)
                {
                    ProductList.Add(new Product {
                    ProductID = Convert.ToInt32(item["ProductID"]),
                    Description = Convert.ToString(item["ProductDescription"]),
                    Code = Convert.ToString(item["ProductCode"]),
                    Type = Convert.ToInt32(item["TypeID"]),
                    Amount = Convert.ToInt32(item["Amount"]),
                    Price = Convert.ToDouble(item["Price"])
                    });
                }
            }

            return ProductList;
        }

        public void Edit(Product product)
        {
            try
            {
                string constring = System.Configuration.ConfigurationManager.ConnectionStrings["mysqldb"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(constring))
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand("EditProduct", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@new_ID", product.ProductID);
                        cmd.Parameters.AddWithValue("@new_desc", product.Description);
                        cmd.Parameters.AddWithValue("@new_code", product.Code);
                        cmd.Parameters.AddWithValue("@new_product_type_ID", product.Type);
                        cmd.Parameters.AddWithValue("@new_amount", product.Amount);
                        cmd.Parameters.AddWithValue("@new_price", product.Price);
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void GetAllTypeData()
        {
            DataTable dt = new DataTable();
            try
            {
                string constring = System.Configuration.ConfigurationManager.ConnectionStrings["mysqldb"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(constring))
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SelectAllTypes", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                        using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void AddNew(Product product)
        {
            try
            {
                string constring = System.Configuration.ConfigurationManager.ConnectionStrings["mysqldb"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(constring))
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand("AddProduct", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@new_desc", product.Description);
                        cmd.Parameters.AddWithValue("@new_code", product.Code);
                        cmd.Parameters.AddWithValue("@new_product_type_ID", product.Type);
                        cmd.Parameters.AddWithValue("@new_amount", product.Amount);
                        cmd.Parameters.AddWithValue("@new_price", product.Price);
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}