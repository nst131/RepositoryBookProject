using BookDAL.Interfaces;
using System.Collections.Generic;

namespace BookDAL.Models
{
    public class Genre : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
