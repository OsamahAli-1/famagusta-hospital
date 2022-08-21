using AutoMapper;
using famagustaHospital.Entities.Models;
using famagustaHospital.Shared.DataTransferObject;


namespace famagustaHospital.API;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<PatientUserCreationDto, SystemUser>();
        CreateMap<PatientUserCreationDto, PatientUser>();
    }
}

