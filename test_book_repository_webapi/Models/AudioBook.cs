using System;
using System.Collections.Generic;

#nullable disable

namespace test_book_repository_webapi.Models
{
    public partial class AudioBook
    {
        public int Id { get; set; }
        public string Announcer { get; set; }
        public TimeSpan Time { get; set; }

        public virtual Book Book { get; set; }
    }
}
