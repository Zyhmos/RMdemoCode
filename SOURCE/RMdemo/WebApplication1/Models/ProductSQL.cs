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

        public void FindByID(int id)
        {
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
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void GetAllData()
        {
            DataTable dt = new DataTable();
            try
            {
                string constring = System.Configuration.ConfigurationManager.ConnectionStrings["mysqldb"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(constring))
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand("Call SelectAll()", con))
                    {
                        cmd.CommandType = CommandType.Text;
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

        public void GetAllTypeDate()
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
    }
}