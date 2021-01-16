using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.IO;

namespace ORM
{
    public class DataBaseMaker
    {
        public static void MakeDB()
        {
            SqlConnection connection = new SqlConnection("Server=.\\SQLEXPRESS;Integrated security=True;database=master");
            string script = File.ReadAllText(@"..\..\..\scriptSql.sql");
            Console.WriteLine(script);
            Console.ReadLine();
            var commandStrings = Regex.Split(script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);
            connection.Open();
            foreach (string commandString in commandStrings)
            {
                if (!string.IsNullOrWhiteSpace(commandString.Trim()))
                {
                        SqlCommand command = new SqlCommand(commandString, connection);
                        command.ExecuteNonQuery();
                }
            }
            connection.Close();
        }
    }
}
