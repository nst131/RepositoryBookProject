using BookWebApi.Attributes;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BookWebApi.Models.BookUI.Dto
{
    public class AcceptGetByISBNBookDtoUI
    {
        [JsonProperty(PropertyName = "isbn", Order = 0, Required = Required.Always)]
        [RegularExpression(@"[0-9]{1}-[0-9]{3}-[0-9]{5}-[0-9]{1}", ErrorMessage = "ISBN указан некоректно, пример правильного isbn:5-237-01064-4")]
        public string ISBN { get; set; }
    }
}
