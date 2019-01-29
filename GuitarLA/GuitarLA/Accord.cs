using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuitarLA
{
    [Table("Accords")]
    public class Accord
    {
        [PrimaryKey, Column("Key")]
        public string Key { get; set; }

        public string AccordCode { get; set; }
    }
}
