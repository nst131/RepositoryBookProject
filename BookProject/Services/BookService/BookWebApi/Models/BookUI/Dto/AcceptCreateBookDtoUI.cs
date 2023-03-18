using BookWebApi.Attributes;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BookWebApi.Models.BookUI.Dto
{
    public class AcceptCreateBookDtoUI
    {
        [UniqueIsbnAtCreate]
        [JsonProperty(PropertyName = "isbn", Order = 0, Required = Required.Always)]
        [RegularExpression(@"[0-9]{1}-[0-9]{3}-[0-9]{5}-[0-9]{1}", ErrorMessage = "ISBN указан некоректно, пример правильного ISBN = 5-237-01064-4")]
        public string ISBN { get; set; }

        [JsonProperty(PropertyName = "iban", Order = 1, Required = Required.Always)]
        [RegularExpression(@"[A-Z]{2} [A-Z]{4} [0-9]{6,20}", ErrorMessage = "IBAN указан неверно, пример правильного IBAN = BY 13 NBRB 123456")]
        public string IBAN { get; set; }

        [JsonProperty(PropertyName = "name", Order = 2, Required = Required.Always)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description", Order = 3, Required = Required.Always)]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 500 символов")]
        public string Description { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        [JsonProperty(PropertyName = "genreId", Order = 4, Required = Required.Always)]
        public int GenreId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        [JsonProperty(PropertyName = "authorId", Order = 5, Required = Required.Always)]
        public int AuthorId { get; set; }
    }
}
