using AutoMapper;
using famagustaHospital.Entities.Models;
using famagustaHospital.Shared.DataTransferObject;
using famagustaHospital.Shared.DataTransferObject.DoctorUser;
using famagustaHospital.Shared.DataTransferObject.DoctorUser.Qualification;
using famagustaHospital.Shared.DataTransferObject.PatientUser;
using famagustaHospital.Shared.DataTransferObject.PatientUser.Chronic;
using famagustaHospital.Shared.DataTransferObject.User;

namespace famagustaHospital.API;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<PatientUserCreationDto, SystemUser>();
        CreateMap<PatientUserCreationDto, PatientUser>();
        CreateMap<DoctorUserCreationDto, SystemUser>();
        CreateMap<DoctorUserCreationDto, DoctorUser>();
        CreateMap<DoctorUser, DoctorUserDto>();
        CreateMap<ChronicCreationDto, Chronic>();
        CreateMap<Chronic, ChronicDto>();
        CreateMap<PatientUser, PatientUserDto>();
        CreateMap<QualificationCreationDto, Qualification>();
        CreateMap<Qualification, QualificationDto>();
    }
}

