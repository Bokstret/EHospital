using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace eHospital
{
    public static class DBConnector
    {
        public static Dictionary<int, object> queryExecuteSingleResult(string query, Dictionary<string, object> parameters = null)
        {
            string DBName = "Durka.db";
            Dictionary<int, object> pairs = new Dictionary<int, object>();
            using (SQLiteConnection Connect = new SQLiteConnection(@"Data Source=" + DBName + "; Version=3;"))
            {
                Connect.Open();
                SQLiteCommand Command = new SQLiteCommand(query, Connect);
                if (parameters != null)
                {
                    foreach (KeyValuePair<string, object> keyValue in parameters)
                    {
                        Command.Parameters.AddWithValue($"@{keyValue.Key}", keyValue.Value);
                    }
                }
                SQLiteDataReader reader = Command.ExecuteReader();
                
                if (reader.HasRows)
                {
                    reader.Read();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        pairs.Add(i, reader.GetValue(i));
                    }
                }
                reader.Close();
                Connect.Dispose();
            }
            return pairs;
        }


        public static List<Dictionary <int, object>> queryExecuteMultiResult(string query, Dictionary<string, object> parameters = null)
        {
            string DBName = "Durka.db";
            List<Dictionary<int, object>> result = new List<Dictionary<int, object>>();
            using (SQLiteConnection Connect = new SQLiteConnection(@"Data Source=" + DBName + "; Version=3;"))
            {
                Connect.Open();
                SQLiteCommand Command = new SQLiteCommand(query, Connect);
                if (parameters != null)
                {
                    foreach (KeyValuePair<string, object> keyValue in parameters)
                    {
                        Command.Parameters.AddWithValue($"@{keyValue.Key}", keyValue.Value);
                    }
                }
                SQLiteDataReader reader = Command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Dictionary<int, object> pairs = new Dictionary<int, object>();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            pairs.Add(i, reader.GetValue(i));
                        }
                        result.Add(pairs);
                    }
                }
                reader.Close();
                Connect.Dispose();
            }
            return result;
        }
    }
}
