using DevFreela.Application.Models;

namespace DevFreela.Application.Services
{
    public interface IProjectService
    {
        ResultViewModel<List<ProjectItemViewModel>> GetAll(int page, int size, string search = "");

    }
}
