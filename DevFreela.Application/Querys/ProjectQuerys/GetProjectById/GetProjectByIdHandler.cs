using DevFreela.Application.Models;
using DevFreela.Application.UtilMessage;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Querys.ProjectQuerys.GetProjectById
{
    public class GetProjectByIdHandler : IRequestHandler<GetProjectByIdQuery, ResultViewModel<ProjectViewModel>>
    {
        private readonly DevFreelaDbContext _context;

        public GetProjectByIdHandler(DevFreelaDbContext context)
        {
            _context = context;
        }


        public async Task<ResultViewModel<ProjectViewModel>> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Projects
               .Include(p => p.Client)
               .Include(p => p.Freelancer)
               .Include(p => p.Comments)
               .SingleOrDefaultAsync(p => p.Id == request.Id);

            if (result is null)
            {
                return ResultViewModel<ProjectViewModel>.Erro(DialogMessage.ProjectNotFound);
            }

            var model = ProjectViewModel.FromEntity(result);

            return ResultViewModel<ProjectViewModel>.Success(model);
        }
    }
}

