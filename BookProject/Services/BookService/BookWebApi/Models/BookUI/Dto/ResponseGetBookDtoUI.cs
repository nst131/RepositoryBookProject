using Newtonsoft.Json;

namespace BookWebApi.Models.BookUI.Dto
{
    public class ResponseGetBookDtoUI
    {
        [JsonProperty(PropertyName = "id", Order = 0, Required = Required.Always)]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name", Order = 1, Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description", Order = 2, Required = Required.Always)]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "genreName", Order = 3, Required = Required.AllowNull)]
        public string GenreName { get; set; }

        [JsonProperty(PropertyName = "authorName", Order = 4, Required = Required.AllowNull)]
        public string AuthorName { get; set; }
    }
}
