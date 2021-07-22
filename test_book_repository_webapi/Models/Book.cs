using System;
using System.Collections.Generic;

#nullable disable

namespace test_book_repository_webapi.Models
{
    public partial class Book
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public int IdGanre { get; set; }
        public string Url { get; set; }
        public string ShortDiscription { get; set; }
        public DateTime CreateDate { get; set; }
        public string BookPublisher { get; set; }
        public string SampleFile { get; set; }
        public byte[] IsShown { get; set; }
        public int? IdAudioBook { get; set; }

        public virtual AudioBook IdAudioBookNavigation { get; set; }
    }
}
