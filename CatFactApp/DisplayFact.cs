using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatFactApp
{

    using SQLite;

    public class DisplayFact
    {
        [PrimaryKey, AutoIncrement]
        public int Id {  get; set; }

        public string fact { get; set; }

        public DateTime time { get; set; }

        public int FontSize { get; set; }

    }


}
