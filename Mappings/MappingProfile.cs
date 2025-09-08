using AutoMapper;
using Crud_Blog.Dtos;
using Crud_Blog.Dtos.Comments;
using Crud_Blog.Dtos.Posts;
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
        CreateMap<User, UpdateUserDto>().ReverseMap();
        CreateMap<User, RegisterUserDto>().ReverseMap();
        #endregion
        
        #region PostsMappings
        CreateMap<Post, PostsDto>().ReverseMap();
        CreateMap<Post, PostsBasicDto>();
        #endregion

        #region CommentsMappings
        CreateMap<Comment, CommentsDto>().ReverseMap();
        CreateMap<Comment, CommentsBasicDto>().ReverseMap();
        #endregion

    }
}
}