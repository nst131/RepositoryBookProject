using Application.Registration;
using AutoMapper;
using EFData.Models;

namespace AuthWebApi
{
    public class MapperConfigurationAuth : Profile
    {
        public MapperConfigurationAuth() 
        {
            CreateMap<RegistrationUserQuery, RegistrationQuery>().ForMember(x => x.Role, x => x.MapFrom(z => Roles.User));
        }
    }
}
