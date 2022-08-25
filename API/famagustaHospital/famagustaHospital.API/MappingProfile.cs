﻿using AutoMapper;
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
        CreateMap<DoctorUser, DoctorUserDto>();
        CreateMap<ChronicCreationDto, Chronic>();
        CreateMap<Chronic, ChronicDto>();
        CreateMap<PatientUser, PatientUserDto>();
        CreateMap<QualificationCreationDto, Qualification>();
        CreateMap<Qualification, QualificationDto>();
        CreateMap<ExperienceCreationDto, Experience>();
        CreateMap<Experience,ExperienceDto>();
        CreateMap<DoctorAvailabilityCreationDto, DoctorAvailability>();
        CreateMap<DoctorAvailability, DoctorAvailabilityDto>();
        CreateMap<DoctorAvailabilityUpdateDto, DoctorAvailability>();
        CreateMap<SessionCreationDto, Session>();
        CreateMap<Session, SessionDto>();
        CreateMap<MedicineCreationDto, Medicine>();
        CreateMap<Medicine, MedicineDto>();
    }
}

