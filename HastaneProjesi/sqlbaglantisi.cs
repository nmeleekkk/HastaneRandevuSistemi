using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace HastaneProjesi
{
    internal class sqlbaglantisi
    {
        public SQLiteConnection baglanti()
        {
            SQLiteConnection baglan = new SQLiteConnection(@"Data Source=C:\Users\melas\source\repos\HastaneProjesi\HastaneProjesi\bin\Debug\database\HastaneProje.db;Version=3;");
            if (baglan.State == System.Data.ConnectionState.Closed)
                baglan.Open();
            return baglan;
        }
    }
}
