using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace GuitarLA
{
    public class AccordsDirectory
    {
        
        SQLiteConnection database;
        public AccordsDirectory(string filename)
        {
            string databasePath = DependencyService.Get<ISQLite>().GetDatabasePath(filename);
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Accord>();
        }
        public IEnumerable<Accord> GetItems()
        {
            return (from i in database.Table<Accord>() select i).ToList();
        }
        public string GetItem(string key)
        {
            return database.Get<Accord>(key).AccordCode;
        }
        public sbyte[] GetItemOnSByte(string key)
        {
            sbyte[] code = new sbyte[6];
            int j = 0;
            string help = database.Get<Accord>(key).AccordCode;
            for (int i = 0; i < help.Length; i++)
            {
                if (help[i] == '-')
                {
                    code[j] = -1;
                    j++;
                    i++;
                }
                else
                {
                    code[j] = Convert.ToSByte(help[i]);
                    j++;
                }
            }
            return code;
        }
        public int DeleteItem(string key)
        {
            return database.Delete<Accord>(key);
        }

    }
}
