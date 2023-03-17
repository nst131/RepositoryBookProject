using AutoMapper;
using BookBLL.Models.BookBL.Dto;
using BookDAL.Models;

namespace BookBLL
{
    public class MapperConfigurationBL : Profile
    {
        public MapperConfigurationBL() 
        {
            //Get
            CreateMap<Book, ResponseGetBookDtoBL>()
                .ForMember(x => x.AuthorName, y => y.MapFrom(z => z.Author.Name + " " + z.Author.SerName));
            //Create
            CreateMap<AcceptCreateBookDtoBL, Book>()
                .ForMember(x => x.TimeAccepted, z => z.NullSubstitute(null))
                .ForMember(x => x.TimeGiveAway, z => z.NullSubstitute(null));
            //Update
            CreateMap<AcceptUpdateBookDtoBL, Book>()
                .ForMember(x => x.TimeAccepted, z => z.NullSubstitute(null))
                .ForMember(x => x.TimeGiveAway, z => z.NullSubstitute(null));
        }
    }
}
