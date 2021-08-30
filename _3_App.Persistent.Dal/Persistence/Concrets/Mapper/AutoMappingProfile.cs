using System;
using AutoMapper;
using _1_App.Core.Domain.Entities;
using _2_App.Dtos.Employee;
using _2_App.Dtos.Department;
using _3_1_App.Core.AppBusiness.Dtos.Duty;
using _3_1_App.Persistent.Dal.Persistence.Concrets.Cqrs.Models.Duty;
using _3_1_App.Persistent.Dal.Persistence.Concrets.Cqrs.Models.Duty.CommandQuery;
using System.Linq;
using _3_1_App.Persistent.Dal.Persistence.ServiceDataModels;
using System.Collections.Generic;

namespace _3_1_App.Persistence.Concrets.Mapper
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            //get employee from db
            //MemberList.Destination ignor rest of exist props in source but not exist in destination

            //CreateMap<Employee, EmployeeDto>(MemberList.Destination);

            //get department from db
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.Department, opt => opt.Ignore())
                 ////for nested objecte use forpath
                 //.ForPath(dest => dest.Department.Id, opt => opt.MapFrom(src => src.Department.Id))
                 .ForPath(dest => dest.Department.Name, opt => opt.MapFrom(src => src.Department.Name))
                 .ForPath(dest => dest.Duties, opt =>
                  opt.MapFrom(src => src.Duties.ToList().Select(s => new DutyDto
                  {
                      Id = s.Id,
                      Name = s.Name
                  })))
                ;



            //add department to db
            CreateMap<AddEmployeeDto, Employee>()
                 //.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                 //.ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                 //.ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId))
                 .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")))
                //.ForMember(dest => dest.Department, opt => opt.Ignore())
                //.ForMember(dest => dest.Duties, opt => opt.Ignore())
                ;


            //update employee from db
            CreateMap<UpdateEmployeeDto, Employee>(MemberList.Source)
                //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                //.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                //.ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                //.ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId))
                //.ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                //.ForMember(dest => dest.Department, opt => opt.Ignore())
                ;


            //get department from db
            CreateMap<Department, DepartmentDto>()
                 //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                 //.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                 //.ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                 //.ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                 ;

            //add department to db
            CreateMap<AddDepartmentDto, Department>()
                //.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                //.ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                //.ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")))
                //.ForMember(dest => dest.Employees, opt => opt.Ignore())
                ;

            //update department from db
            CreateMap<UpdateDepartmentDto, Department>()
                //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                //.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                //.ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                //.ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                ;


            //get duty
            CreateMap<Duty, DutyDto>(MemberList.Destination)
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               //.ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
               //.ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
               //.ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
               //.ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId))
               ;

            //add duty
            CreateMap<CreateCommandDuty, Duty>()
               //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
               .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")))
               .ForMember(dest => dest.Status, opt => opt.MapFrom(src => DutyStatus.Created))
               .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId))
               .ForMember(dest => dest.Employee, opt => opt.Ignore())
               ;

            //update duty
            CreateMap<UpdateCommandDuty, Duty>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
               .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
               .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
               .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId))
               .ForMember(dest => dest.Employee, opt => opt.Ignore())
               ;

        }

    }
       
}
