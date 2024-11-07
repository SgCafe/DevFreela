using DevFreela.Application.Models;
using DevFreela.Application.UtilMessage;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Querys.ProjectQuerys.GetProjectById
{
    public class GetProjectByIdHandler : IRequestHandler<GetProjectByIdQuery, ResultViewModel<ProjectViewModel>>
    {
        private readonly IProjectRepository _repository;

        public GetProjectByIdHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<ProjectViewModel>> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetDetailsById(request.Id);

            if (result is null)
            {
                return ResultViewModel<ProjectViewModel>.Erro(DialogMessage.ProjectNotFound);
            }

            var model = ProjectViewModel.FromEntity(result);

            return ResultViewModel<ProjectViewModel>.Success(model);
        }
    }
}

