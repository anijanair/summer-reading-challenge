
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Summer_Reading_Challenge.Models

{   // Model for Book, with th efields to be viewed - Date, Book Title and Author

    public class Book
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]// To change the date format
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime Date{ get; set; }
        public string BookTitle { get; set; }
        public string Author { get; set; }
    }
}
