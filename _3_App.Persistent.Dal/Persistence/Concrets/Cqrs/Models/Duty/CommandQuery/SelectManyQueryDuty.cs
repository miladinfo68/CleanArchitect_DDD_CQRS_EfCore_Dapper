using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using _3_1_App.Core.AppBusiness.Dtos.Duty;
using _2_App.Core.AppBusiness.Interfaces.Repositories;

namespace _3_1_App.Persistent.Dal.Persistence.Concrets.Cqrs.Models.Duty.CommandQuery
{
    public class SelectManyQueryDuty : IRequest<List<DutyDto>>
    {
    }
    public class SelectAllDutyQueryHandler :
        IRequestHandler<SelectManyQueryDuty, List<DutyDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public SelectAllDutyQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _uow = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<DutyDto>> Handle(SelectManyQueryDuty request, CancellationToken cancellationToken)
        {
            var fetchedAllDuties = await _uow.Duties.GetListByAsync();
            var allDutiesDto = _mapper.Map<List<DutyDto>>(fetchedAllDuties);
            return allDutiesDto;
        }
    }

}
