using System.Collections.Generic;

namespace BookReader.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Book> books { get; set; }
        public Category()
        {
            books = new List<Book>();
        }
    }
}