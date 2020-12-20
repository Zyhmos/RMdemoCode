//RMA 20/12/20 TFS-[Practice Task] File Creation

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using WebApplication1.Data;

namespace WebApplication1.Models
{
    public class ProductManager : IProductManager
    {
        /// <summary>
        /// Delete product with this ID
        /// </summary>
        /// <param name="id">Products ID</param>
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

        /// <summary>
        /// Find a product by its ID
        /// </summary>
        /// <param name="id">Product ID</param>
        /// <returns>Product with this ID</returns>
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
                        product.TypeID = Convert.ToInt32(dt.Rows[0]["TypeID"]);
                        product.TypeCode = Convert.ToString(dt.Rows[0]["TypeCode"]);
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
        
        /// <summary>
        /// Get full product list
        /// </summary>
        /// <returns>List of products</returns>
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

            //NOTE: Could've put this into db reader.
            var ProductList = new List<Product>();
            if (dt != null)
            {
                foreach (DataRow item in dt.Rows)
                {
                    ProductList.Add(new Product {
                    ProductID = Convert.ToInt32(item["ProductID"]),
                    Description = Convert.ToString(item["ProductDescription"]),
                    Code = Convert.ToString(item["ProductCode"]),
                    TypeCode = Convert.ToString(item["TypeCode"]),
                    Amount = Convert.ToInt32(item["Amount"]),
                    Price = Convert.ToDouble(item["Price"])
                    });
                }
            }

            return ProductList;
        }

        /// <summary>
        /// Change products values in DB of a product with corresponding ID.
        /// </summary>
        /// <param name="product"> New product values with old ID </param>
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
                        cmd.Parameters.AddWithValue("@new_Type_ID", product.TypeID);
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

        /// <summary>
        /// Get all product TYPE list.
        /// </summary>
        /// <returns>List of all product types.</returns>
        public List<Type> GetAllTypeData()
        {
            DataTable dt = new DataTable();
            try
            {
                string constring = System.Configuration.ConfigurationManager.ConnectionStrings["mysqldb"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(constring))
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand("TypesGetAll", con))
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

            var typeList = new List<Type>();
            if (dt != null)
            {
                foreach (DataRow item in dt.Rows)
                {
                    typeList.Add(new Type
                    {
                        TypeID = Convert.ToInt32(item["ID_Type"]),
                        Description = Convert.ToString(item["Description"]),
                        Code = Convert.ToString(item["Code"])
                    });
                }
            }

            return typeList;
        }

        /// <summary>
        /// Adds a new product to the database.
        /// </summary>
        /// <param name="product">Product that needs to be added.</param>
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
                        cmd.Parameters.AddWithValue("@new_Type_ID", product.TypeID);
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