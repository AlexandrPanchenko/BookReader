using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReader.Models
{
  public class ViewModel
    {
        public ICollection<Book> books { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
