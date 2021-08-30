using MediatR;
using _1_App.Core.Domain.Entities;
using _3_1_App.Core.AppBusiness.Dtos.Duty;
using System.Threading.Tasks;
using System.Threading;
using _2_App.Core.AppBusiness.Interfaces.Repositories;
using AutoMapper;

namespace _3_1_App.Persistent.Dal.Persistence.Concrets.Cqrs.Models.Duty.CommandQuery
{
    public class CreateCommandDuty : IRequest<DutyDto>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        //public DutyStatus Status { get; set; }
        //public string CreatedAt { get; set; }
        public decimal EmployeeId { get; set; }
    }

    public class CreateDutyCommandHandler :
        IRequestHandler<CreateCommandDuty, DutyDto>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CreateDutyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _uow = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DutyDto> Handle(CreateCommandDuty request, CancellationToken cancellationToken)
        {
            var duty = _mapper.Map<_1_App.Core.Domain.Entities.Duty>(request);
            var addedDuty = await _uow.Duties.AddAsync(duty);
            var dutyDto = _mapper.Map<DutyDto>(addedDuty);
            return dutyDto;
        }
    }

}
