namespace BookBLL.Models.BookBL.Dto
{
    public class AcceptUpdateBookDtoBL
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string IBAN { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? GenreId { get; set; }
        public int? AuthorId { get; set; }
    }
}
