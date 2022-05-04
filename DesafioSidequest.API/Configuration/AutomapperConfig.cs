using AutoMapper;
using DesafioSidequest.API.ViewModels;
using DesafioSidequest.Business.Models;

namespace DesafioSidequest.API.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
        }
    }
}