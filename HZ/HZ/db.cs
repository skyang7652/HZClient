using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace HZ
{
    class db
    {
        string dbHost = "114.33.225.77";
        string dbUser = "root";
        string dbPass = "";
        string dbName = "hz";
        
        public MySqlConnection conn;

        public int MySqlConnection()
        {
            string connStr = "server=" + dbHost + ";uid=" + dbUser + ";pwd=" + dbPass + ";database=" + dbName;
            conn = new MySqlConnection(connStr);
            int ret = 0;
            // 連線到資料庫
            try
            {
                conn.Open();
                ret = 1;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        ret = -1;
                        break;
                    case 1045:
                        ret = -2;
                        break;
                    default:
                        ret = ex.Number * -1;
                        break;
                        
                }
            }
            return ret;
        }


        public int getEmployee(ref MySqlDataReader myData)
        {
            //string SQL = "SELECT * FROM employee;";
         
   
            return 1;
        }

    }
}
