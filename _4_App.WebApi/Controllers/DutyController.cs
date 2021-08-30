using System.Collections.Generic;
using System.Threading.Tasks;
using _1_App.Core.Domain.Common.Response;
using _2_App.Dtos.Employee;
using _3_1_App.Core.AppBusiness.Dtos.Duty;
using _3_1_App.Persistent.Dal.Persistence.Concrets.Cqrs.Models.Duty.CommandQuery;
using Microsoft.AspNetCore.Mvc;

namespace _4_App.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DutyController : ApiController
    {
        [HttpGet("get-all")]
        public async Task<ApiResponse<List<DutyDto>>> GetAll()
        {
            var dutiesDto = await Mediator.Send(new SelectManyQueryDuty());
            return ApiResponse<List<DutyDto>>.Success(dutiesDto);
        }

        [HttpGet("get-one")]
        public async Task<ApiResponse<DutyDto>> Get( decimal id)
        {
            var dutyDto = await Mediator.Send(new SelectOneQueryDuty { Id=id});
            return ApiResponse<DutyDto>.Success(dutyDto);
        }


        [HttpPost("add")]
        public async Task<ApiResponse<DutyDto>> Add(CreateCommandDuty createCommandDuty)
        {
            var dutyDto = await Mediator.Send(createCommandDuty);
            return ApiResponse<DutyDto>.Success(dutyDto);
        }

        [HttpPut("update")]
        public async Task<ApiResponse<DutyDto>> Update(UpdateCommandDuty updateCommandDuty)
        {
            var dutyDto = await Mediator.Send(updateCommandDuty);
            return ApiResponse<DutyDto>.Success(dutyDto);
        }

        [HttpDelete("delete")]
        public async Task<ApiResponse<bool>> Delete( decimal id)
        {
            var result = await Mediator.Send(new DeleteCommandDuty { Id=id});
            return ApiResponse<bool>.Success(result);
        }
    }
}
