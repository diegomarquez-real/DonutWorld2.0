using AutoMapper;

namespace DonutWorld.Api.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            //Get
            CreateMap<Data.Models.User, Models.UserModel>();

            //Create
            CreateMap<Models.Create.CreateUserModel, Data.Models.User>();

            //Update
            CreateMap<Models.Update.UpdateUserModel, Data.Models.User>();
        }
    }
}
