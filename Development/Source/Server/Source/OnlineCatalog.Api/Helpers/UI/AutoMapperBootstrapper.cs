using AutoMapper;
using OnlineCatalog.Api.Models;
using OnlineCatalog.Data.Model;

namespace OnlineCatalog.Api.Helpers.UI
{
    public static class AutoMapperBootstrapper
    {
        public static void Initialize()
        {
            Mapper.Initialize(config =>
            {
                config.AddProfile<EditModelProfile>();
            });
        }
    }

    public class EditModelProfile: Profile
    {
        protected override void Configure()
        {
            CreateMap<SignupModel, User>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                .AfterMap((model, dest) => dest.UserInfo = new UserInfo
                {
                    Firstname = model.Firstname,
                    Lastname = model.Lastname,
                    AddressLine1 = model.Address,
                    City = model.City,
                    Pincode = model.Pincode,
                    ProvinceId = model.ProvinceId
                });
        }
    }
}