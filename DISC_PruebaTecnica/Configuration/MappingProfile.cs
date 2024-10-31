using AutoMapper;
using DISC_PruebaTecnica.DTO.Usuarios;
using DISC_PruebaTecnica.Models;

namespace DISC_PruebaTecnica.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Usuario,User1Dto>().ReverseMap();
        }

    }
}
