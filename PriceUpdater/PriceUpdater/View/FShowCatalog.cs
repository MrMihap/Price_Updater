using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace PriceUpdater
{
  public partial class FShowCatalog : Form
  {
    public FShowCatalog()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      MySqlConnectionStringBuilder mysqlCSB;
      mysqlCSB = new MySqlConnectionStringBuilder();

      mysqlCSB.Server = "printermoscow.ru";
      mysqlCSB.Database = "u5444659_db2";
      mysqlCSB.Port = 3306;
      mysqlCSB.UserID = "u5444659_default";
      mysqlCSB.Password = "9cpXANGA";
      string queryString = @"SELECT p.name, b.id             
                        FROM   products p
                        LEFT JOIN brands b on p.brands_id = b.id";

      DataTable dt = new DataTable();
      using (MySqlConnection con = new MySqlConnection())
      {
        con.ConnectionString = mysqlCSB.ConnectionString;
        con.Open();
        MySqlCommand com = new MySqlCommand(queryString, con);
        using (MySqlDataReader dr = com.ExecuteReader())
        {
          //есть записи?
          if (dr.HasRows)
          {
            //заполняем объект DataTable
            dt.Load(dr);
          }
          dataGridView1.DataSource = dt;
        }
      }
    }
  }
}
