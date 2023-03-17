using AutoMapper;
using BookBLL.Models.BookBL.Dto;
using BookWebApi.Models.BookUI.Dto;

namespace BookWebApi
{
    public class MapperConfigurationUI : Profile
    {
        public MapperConfigurationUI() 
        {
            CreateMap<ResponseGetBookDtoBL, ResponseGetBookDtoUI>();
            CreateMap<AcceptCreateBookDtoUI, AcceptCreateBookDtoBL>();
            CreateMap<AcceptUpdateBookDtoUI, AcceptUpdateBookDtoBL>();
        }
    }
}
