using System;
using AutoMapper;
using System.Linq;
using _2_App.Dtos.Employee;
using System.Threading.Tasks;
using System.Collections.Generic;
using _1_App.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using _2_App.Core.Apllication.Interfaces;
using _3_1_App.Persistent.Dal.DataAccess;
using _1_App.Core.Domain.Abstracts.Interfaces.IRepositories.Dapper;
using _1_App.Core.Domain.Abstracts.Context;
using _1_App.Core.Domain.Common.Aspects.Autofac.Transaction;
using _2_App.Core.AppBusiness.Interfaces.Repositories;
using _3_1_App.Persistent.Dal.Persistence.ServiceDataModels;
using _3_1_App.Persistent.Dal.Persistence.Concrets.Mapper;

namespace _3_1_App.Persistent.Dal.Persistence.Concrets.Services
{
    public class EmployeeService : IEmployeeService
    {
        private MyDbContext _dbContext { get; }
        private IEmployeeRepository _employeeRepository { get; }
        private DapperCustomReadRepository _dapperReadRepository { get; }

        private readonly IMapper _mapper;
        public EmployeeService(
              MyDbContext dbContext
            , IMapper mapper
            , IEmployeeRepository employeeRepository
            , DapperCustomReadRepository dapperReadRepository)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _employeeRepository = employeeRepository;
            _dapperReadRepository = dapperReadRepository;
        }

        public async Task<List<EmployeeDto>> GetAllAsync()
        {
            ////read data from dapper with efcore connection
            //var fechedEmployees1 = await _employeeRepository.QueryAsync<Employee>(TSql.GET_ALL_EMPLOYEE);
            //var fechedEmployees2 = await _employeeRepository.GetListByAsync();

            //read by dapper by independent connection
            var fechedEmployees3 = await _dapperReadRepository.QueryAsync<EmployeeAndDependenciesModel>(TSql.GET_ALL_EMPLOYEES_AND_ALL_DEPENDENCIES());
            var employees = fechedEmployees3.ToList().ToEmployees();
            var employeesDto = _mapper.Map<List<EmployeeDto>>(employees);

            //var query = _dbContext.Employees.Include(i => i.Department).Include(i => i.Duties);
            ////var sqlQuery = query.ToQueryString();

            //var fechedEmployees = await query.ToListAsync();
            //var employeesDto = _mapper.Map<List<EmployeeDto>>(fechedEmployees);


            return employeesDto;
        }

        public async Task<EmployeeDto> GetByIdAsync(GetByIdEmployeeDto getByIdEmployeeDto)
        {
            //eager loading related data
            //var fetchedEmployee = await _dbContext.Employees
            //    .Include(i => i.Department)
            //    .Where(w => w.Id == getByIdEmployeeDto.Id)
            //    .FirstOrDefaultAsync();
            //var employeeDto = _mapper.Map<EmployeeDto>(fetchedEmployee);
            //return employeeDto;

            var fetchedEmployee = await _dapperReadRepository
                .QueryAsync<EmployeeAndDependenciesModel>(TSql.GET_ALL_EMPLOYEES_AND_ALL_DEPENDENCIES(getByIdEmployeeDto.Id), getByIdEmployeeDto);
            var employee = fetchedEmployee.ToList().ToEmployees().FirstOrDefault();
            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            return employeeDto;
        }
        public async Task<EmployeeDto> AddAsync(AddEmployeeDto addEmployeeDto)
        {
            var employee = _mapper.Map<Employee>(addEmployeeDto);
            await _dbContext.Employees.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            return employeeDto;


            //var employee = _mapper.Map<Employee>(addEmployeeDto);
            //var addedEmployee = await _dapperBaseRepository.ExecuteAddCommandAsync<Employee>(TSql.ADD_NEW_EMPLOYEE, employee);
            //var employeeDto = _mapper.Map<EmployeeDto>(addedEmployee);
            //return employeeDto;
        }

        [TransactionScopeAspect]
        public async Task<EmployeeDto> UpdateAsync(UpdateEmployeeDto updateEmployeeDto)
        {
            var employee = _mapper.Map<Employee>(updateEmployeeDto);
             _dbContext.Employees.Update(employee);
            await _dbContext.SaveChangesAsync();
            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            return employeeDto;


            //var employee = _mapper.Map<Employee>(updateEmployeeDto);
            //var updatedEmployee = await _employeeRepository.ExecuteUpdateCommandAsync<Employee>(TSql.UPDATE_EMPLOYEE, employee);
            //updatedEmployee.Department = await _dbContext.Departments.FirstOrDefaultAsync(f => f.Id == updatedEmployee.DepartmentId);
            //updatedEmployee.Duties = await _dbContext.Duties.Where(w => w.EmployeeId == updatedEmployee.Id).ToListAsync();

            //var employeeDto = _mapper.Map<EmployeeDto>(updatedEmployee);
            //return employeeDto;

        }

        [TransactionScopeAspect]
        public async Task<bool> DeleteAsync(DeleteEmployeeDto deleteEmployeeDto)
        {
            //var deletedEmployee = await _dbContext.Employees
            //    .Include(i => i.Duties)
            //    .FirstOrDefaultAsync(e => e.Id == deleteEmployeeDto.Id);
            //if (deletedEmployee is null) return false;
            //_dbContext.Employees.Remove(deletedEmployee);

            //var result = await _dbContext.SaveChangesAsync();
            //return result > 0 ? true : false;

            var result = await _employeeRepository.ExecuteDeleteCommandAsync<Employee>(TSql.DELETE_EMPLOYEE_AND_DUTIES, deleteEmployeeDto);
            return result;
        }

    }
}
