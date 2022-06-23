using System.ComponentModel.DataAnnotations;

namespace lab7_8.Models
{
    public class Books
    {
        public int ID { get; set; }
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime RelaseDate { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
    }

    

}
