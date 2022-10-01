using AutoMapper;
using famagustaHospital.Entities.Models;
using famagustaHospital.Shared.DataTransferObject;
using famagustaHospital.Shared.DataTransferObject.DoctorUser;
using famagustaHospital.Shared.DataTransferObject.DoctorUser.DoctorAvailability;
using famagustaHospital.Shared.DataTransferObject.DoctorUser.Experience;
using famagustaHospital.Shared.DataTransferObject.DoctorUser.Qualification;
using famagustaHospital.Shared.DataTransferObject.PatientUser;
using famagustaHospital.Shared.DataTransferObject.PatientUser.Chronic;
using famagustaHospital.Shared.DataTransferObject.Session;
using famagustaHospital.Shared.DataTransferObject.Session.Medicine;
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
        CreateMap<DoctorUser, DoctorUserDto>()
            .ForMember(dest=>dest.UserViewDto,act=>act.MapFrom(src=>src.systemUser))
            .ForMember(dest => dest.ExperienceDtos, act => act.MapFrom(src => src.experiences))
            .ForMember(dest => dest.QualificationDtos, act => act.MapFrom(src => src.qualifications));
        CreateMap<ChronicCreationDto, Chronic>();
        CreateMap<Chronic, ChronicDto>();
        CreateMap<PatientUser, PatientUserDto>()
            .ForMember(dest => dest.UserViewDto, act => act.MapFrom(src => src.systemUser))
            .ForMember(dest => dest.ChronicDtos, act => act.MapFrom(src => src.Chronics));
        CreateMap<QualificationCreationDto, Qualification>();
        CreateMap<Qualification, QualificationDto>();
        CreateMap<ExperienceCreationDto, Experience>();
        CreateMap<Experience,ExperienceDto>();
        CreateMap<DoctorAvailabilityCreationDto, DoctorAvailability>();
        CreateMap<DoctorAvailability, DoctorAvailabilityDto>();
        CreateMap<DoctorAvailabilityUpdateDto, DoctorAvailability>();
        CreateMap<SessionCreationDto, Session>();
        CreateMap<Session, SessionDto>();
        CreateMap<SessionUpdateDto, Session>();
        CreateMap<SessionCancelDto, Session>();
        CreateMap<MedicineCreationDto, Medicine>();
        CreateMap<Medicine, MedicineDto>();
        CreateMap<SystemUser, UserViewDto>();
    }
}

