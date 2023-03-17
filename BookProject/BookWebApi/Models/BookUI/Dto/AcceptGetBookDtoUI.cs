using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BookWebApi.Models.BookUI.Dto
{
    public class AcceptGetBookDtoUI
    {
        [Range(1, int.MaxValue, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        [JsonProperty(PropertyName = "id", Order = 0, Required = Required.Always)]
        public int Id { get; set; }
    }
}
