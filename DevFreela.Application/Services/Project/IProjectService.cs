using DevFreela.Application.Models;

namespace DevFreela.Application.Services.Project
{
    public interface IProjectService
    {
        ResultViewModel<List<ProjectItemViewModel>> GetAll(string search = "");
        ResultViewModel<ProjectViewModel> GetById(int id);
        ResultViewModel<int> Post(CreateProjectInputModel model);
        ResultViewModel Put(int id, UpdateProjectInputModel model);
        ResultViewModel Delete(int id);
        ResultViewModel Start(int id);
        ResultViewModel Complete(int id);
        ResultViewModel PostComments(int id, CreateProjectCommentInputModel model);

    }
}
