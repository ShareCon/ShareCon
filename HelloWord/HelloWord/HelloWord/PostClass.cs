using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace HelloWord
{
    public class PostClass
    {
        [PrimaryKey, AutoIncrement,NotNull]
        public int UnicID { get; set; }

        [MaxLength(250)]
        public string Experience { get; set; }
    }
}
