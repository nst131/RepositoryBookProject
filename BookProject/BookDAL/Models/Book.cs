using System;
using System.ComponentModel.DataAnnotations;
using BookDAL.Interfaces;

namespace BookDAL.Models
{
    public class Book : IEntity
    {
        public int Id { get; set; }
        [RegularExpression(@"[0-9]{1}-[0-9]{3}-[0-9]{5}-[0-9]{1}")]
        public string ISBN { get; set; }
        [RegularExpression(@"[A-Z]{2} [A-Z]{4} [0-9]{6,20}")]
        public string IBAN { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? GenreId { get; set; }
        public Genre Genre { get; set; }
        public int? AuthorId { get; set; }
        public Author Author { get; set; }
        public DateTime? TimeAccepted { get; set; }
        public DateTime? TimeGiveAway { get; set; }

    }
}
