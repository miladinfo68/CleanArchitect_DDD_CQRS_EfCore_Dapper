using MediatR;
using _1_App.Core.Domain.Entities;
using _3_1_App.Core.AppBusiness.Dtos.Duty;
using System.Threading.Tasks;
using System.Threading;
using _2_App.Core.AppBusiness.Interfaces.Repositories;
using AutoMapper;
using System.Collections.Generic;

namespace _3_1_App.Persistent.Dal.Persistence.Concrets.Cqrs.Models.Duty.CommandQuery
{
    public class SelectOneQueryDuty : IRequest< DutyDto>
    {
        public decimal Id { get; set; }
    }
    public class SelectOneDutyQueryHandler :
        IRequestHandler<SelectOneQueryDuty, DutyDto>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public SelectOneDutyQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _uow = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DutyDto> Handle(SelectOneQueryDuty request, CancellationToken cancellationToken)
        {
            var fetchedDuty = await _uow.Duties.GetByIdAsync(request.Id);
            var dutyDto = _mapper.Map< DutyDto>(fetchedDuty);
            return dutyDto;
        }
    }

}
