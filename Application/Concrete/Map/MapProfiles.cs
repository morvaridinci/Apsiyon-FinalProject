using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Concrete.Dtos;
using Domain.Concrete;
using WebUI.Models.Login;

namespace Application.Concrete.Map
{
    public class MapProfiles : Profile
    {
        public MapProfiles()
        {
            CreateMap<BlockViewDto, Block>().ReverseMap();

            CreateMap<ApartmentViewDto, Apartment>().ReverseMap();
            CreateMap<ApartmentAddViewDto, Apartment>().ReverseMap();

            CreateMap<BillUpdateViewDto, Bill>().ReverseMap();
            CreateMap<BillAddViewDto, Bill>().ReverseMap(); 
            CreateMap<BillGetAllViewDto, Bill>().ReverseMap(); 

            CreateMap<DebtTypeViewDto, DebtType>().ReverseMap();
            CreateMap<MessageViewDto, Message>().ReverseMap(); 

            CreateMap<UserViewDto, User>().ReverseMap();

            CreateMap<UserAddViewDto, User>().ReverseMap();
            CreateMap<UserViewDto, User>().ReverseMap();
            CreateMap<LoginViewModel, User>().ReverseMap();
            CreateMap<RegisterViewDto, User>().ReverseMap();
        }
    }
}
