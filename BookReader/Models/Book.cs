using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookReader.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [Display(Name ="Название книги" )]
        public string Name { get; set; }

        [Display(Name = "Год издания")]
        public int Year { get; set; }

        [Display(Name = "Обложка книги")]
        public string ImagePath { get; set; }

        [Display(Name = "Добавление файла")]
        public string ContentPath { get; set; }

        [Display(Name = "Описание книги")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public double Rating { get; set; }
        [Display(Name = "Язык книги")]
        public string language { get; set; }
        public DateTime CreateTime { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
        public virtual ICollection<Category> Categories { get; set; }

        public Book()
        {
            Authors = new List<Author>();
            Categories = new List<Category>();
        }

    }
}