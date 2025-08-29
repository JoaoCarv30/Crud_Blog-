using AutoMapper;
using Crud_Blog.Dtos;
using Crud_Blog.Entities;

namespace Crud_Blog.Mappings
{
public class MappingProfile : Profile
{
    public MappingProfile()
    {

        #region UsersMappings
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<User, UserBasicDto>();
        #endregion
        
        #region PostsMappings
        
        #endregion

    }
}
}