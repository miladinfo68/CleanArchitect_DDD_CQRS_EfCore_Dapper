using MediatR;
using _1_App.Core.Domain.Entities;
using _3_1_App.Core.AppBusiness.Dtos.Duty;
using System.Threading.Tasks;
using System.Threading;
using _2_App.Core.AppBusiness.Interfaces.Repositories;
using AutoMapper;

namespace _3_1_App.Persistent.Dal.Persistence.Concrets.Cqrs.Models.Duty.CommandQuery
{
    public class DeleteCommandDuty : IRequest<bool>
    {
        public decimal Id { get; set; }
    }
    public class DeleteDutyCommandHandler :
        IRequestHandler<DeleteCommandDuty, bool>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public DeleteDutyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _uow = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteCommandDuty request, CancellationToken cancellationToken)
        {            
            var result = await _uow.Duties.DeleteAsync(request.Id);            
            return result;
        }
    }

}
