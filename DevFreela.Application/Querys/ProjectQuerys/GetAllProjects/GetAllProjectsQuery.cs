using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Querys.ProjectQuerys.GetAllProjects
{
    public class GetAllProjectsQuery : IRequest<ResultViewModel<List<ProjectItemViewModel>>>
    {

    }
}
