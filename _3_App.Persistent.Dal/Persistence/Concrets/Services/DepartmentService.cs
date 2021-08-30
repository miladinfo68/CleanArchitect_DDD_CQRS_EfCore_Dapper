using _1_App.Core.Domain.Abstracts.Context;
using _1_App.Core.Domain.Abstracts.Interfaces.IRepositories.Dapper;
using _1_App.Core.Domain.Entities;
using _2_App.Core.Apllication.Interfaces;
using _2_App.Core.AppBusiness.Interfaces.Repositories;
using _2_App.Dtos.Department;
using _3_1_App.Persistent.Dal.DataAccess;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_1_App.Persistent.Dal.Persistence.Concrets.Services
{
    public class DepartmentService : IDepartmentService
    {
        private MyDbContext _dbContext { get; }
        private IDepartmentRepository _departmentRepository{ get; }
        private readonly IMapper _mapper;
        public DepartmentService(
              IMapper mapper
            , MyDbContext dbContext
            , IDepartmentRepository departmentRepository
            )
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _departmentRepository = departmentRepository;
        }
        public async Task<List<DepartmentDto>> GetAllDepartmentsAsync()
        {
            var fechedDepartments1 = await _departmentRepository.QueryAsync<Department>(TSql.GET_ALL_DEPARTMENTS);
            var fechedDepartments2 = await _departmentRepository.GetListByAsync();

            var fechedDepartments = await _dbContext.Departments.ToListAsync();
            var employeesDto = _mapper.Map<List<DepartmentDto>>(fechedDepartments);
            return employeesDto;
        }
        public async Task<DepartmentDto> GetDepartmentByIdAsync(GetByIdDepartmentDto getByIdDepartmentDto)
        {
            //eager loading related data
            var fetchedDepartmentDto = await _dbContext.Departments
                .Where(a => a.Id == getByIdDepartmentDto.Id)
                .FirstOrDefaultAsync();
            var departmentDto = _mapper.Map<DepartmentDto>(fetchedDepartmentDto);
            return departmentDto;

            //var fetchedDepartment = await _departmentRepository.QueryFirstOrDefaultAsync<Employee>(TSql.GET_DEPARTMENT_BY_ID, getByIdDepartmentDto);            
            //var department = _mapper.Map<DepartmentDto>(fetchedDepartment);
            //return department;
        }
        public async Task<DepartmentDto> AddDepartmentAsync(AddDepartmentDto addDepartmentDto)
        {
            var department = _mapper.Map<Department>(addDepartmentDto);
            var addedDepartment = await _dbContext.Departments.AddAsync(department);
            await _dbContext.SaveChangesAsync();
            var departmentDto = _mapper.Map<DepartmentDto>(department);
            return departmentDto;

            //var department = _mapper.Map<Department>(addDepartmentDto);
            //var addedDepartment = await _departmentRepository.ExecuteAddCommandAsync<Department>(TSql.ADD_NEW_DEPARTMENT, department);
            //var departmentDto = _mapper.Map<DepartmentDto>(addedDepartment);
            //return departmentDto;
        }
        public async Task<DepartmentDto> UpdateDepartmentAsync(UpdateDepartmentDto updateDepartmentDto)
        {
            //var department = _mapper.Map<Department>(updateDepartmentDto);
            //var updatedEmployee = await Task.Run(() => _dbContext.Departments.Update(department));
            //_dbContext.SaveChangesAsync();
            //var departmentDto = _mapper.Map<DepartmentDto>(updatedEmployee);
            //return departmentDto;

            var department = _mapper.Map<Department>(updateDepartmentDto);
            var updatedDepartment = await _departmentRepository.ExecuteUpdateCommandAsync<Department>(TSql.UPDATE_DEPARTMENT, department);
            var departmentDto = _mapper.Map<DepartmentDto>(updatedDepartment);
            return departmentDto;
        }
        public async ValueTask<bool> DeleteDepartmentAsync(DeleteDepartmentDto deleteDepartmentDto)
        {
            var deletedDepartment = await _dbContext.Departments.FirstOrDefaultAsync(e => e.Id == deleteDepartmentDto.Id);
            if (deletedDepartment is null) return false;
            _dbContext.Departments.Remove(deletedDepartment);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0 ? true : false;

            //var result = await _departmentRepository.ExecuteDeleteCommandAsync<Department>(TSql.DELETE_DEPARTMENT, deleteDepartmentDto);            
            //return result;
        }

    }
}
