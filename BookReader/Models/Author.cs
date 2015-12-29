using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReader.Models
{
    public class Author
    {
        public int AuthorId { get; set; }

        [Display(Name = "Имя автора")]
        public string Name { get; set; }
        [Display(Name = "Фамилия автора")]
        public string Surname { get; set; }
        [Display(Name = "Описание")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Display(Name = "Фотография")]
        public string ImagePath { get; set; }
        public virtual ICollection<Book>Books { get; set; }

        public Author()
        {
            Books = new List<Book>();
            ImagePath = "/Content/AuthorsImage/define.png";

        }
    }
}
