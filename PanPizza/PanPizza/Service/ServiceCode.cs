using PanPizza.Helpers;
using PanPizza.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PanPizza.Service
{
    public class ServiceCode
    {
        public List<PizzaSize> GettAllSize()
        {
            List<PizzaSize> sizeList = new List<PizzaSize>();
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Get_AllSize";
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        foreach (DataRow row in dt.Rows)
                        {
                            PizzaSize r = new PizzaSize
                            {
                                SizeID = int.Parse(row[0].ToString()),
                                Name = row[1].ToString(),
                            };
                            sizeList.Add(r);
                        }
                        return sizeList;
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                    return null;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public List<Ingredients> GettAllIngredients()
        {
            List<Ingredients> ingredientsList = new List<Ingredients>();
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Get_AllIngredients";
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        foreach (DataRow row in dt.Rows)
                        {
                            Ingredients r = new Ingredients
                            {
                                IngredientsId = int.Parse(row[0].ToString()),
                                Name = row[1].ToString(),
                                Price = double.Parse(row[2].ToString())

                            };
                            ingredientsList.Add(r);
                        }
                        return ingredientsList;
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                    return null;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
