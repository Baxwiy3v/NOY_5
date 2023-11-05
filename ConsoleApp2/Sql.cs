using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{

    internal class Sql
    {
        private const string connection = "server=DESKTOP-L4MGE54;database=Tasks;trusted_connection=true;";
       
        
        
        private static SqlConnection sqlconnection = new SqlConnection(connection);



        public DataTable ExecuteQuery(string ADO)
        {
            DataTable table = new DataTable();

            try
            {
                sqlconnection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(ADO, sqlconnection);

                adapter.Fill(table);

            }
            catch (Exception e)
            {

                throw e;
            }
            
            return table;
            sqlconnection.Close();
        }
        public int ExecuteCommand(string cmd)
        {
            int result = 0;
            sqlconnection.Open();
            try
            { 
                SqlCommand command = new SqlCommand(cmd, sqlconnection);
                result = command.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw e;
            }
           
            return result;
            sqlconnection.Close();
        }


       
    }
}












