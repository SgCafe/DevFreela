using DevFreela.Application.Models;
using DevFreela.Application.UtilMessage;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Services.Project
{
    public class ProjectService : IProjectService
    {
        private readonly DevFreelaDbContext _context;

        public ProjectService(DevFreelaDbContext context)
        {
            _context = context;
        }

        public ResultViewModel<List<ProjectItemViewModel>> GetAll(string search = "")
        {
            var projects = _context.Projects
           .Include(p => p.Client)
           .Include(p => p.Freelancer)
           .Where(p => !p.IsDeleted && (search == "" || p.Title.Contains(search) || p.Description.Contains(search)))
           .ToList();

            var model = projects.Select(ProjectItemViewModel.FromEntity).ToList();

            return ResultViewModel<List<ProjectItemViewModel>>.Success(model);
        }

        public ResultViewModel<ProjectViewModel> GetById(int id)
        {
            var result = _context.Projects
               .Include(p => p.Client)
               .Include(p => p.Freelancer)
               .Include(p => p.Comments)
               .SingleOrDefault(p => p.Id == id);

            if (result is null)
            {
                return ResultViewModel<ProjectViewModel>.Erro(DialogMessage.ProjectNotFound);
            }

            var model = ProjectViewModel.FromEntity(result);

            return ResultViewModel<ProjectViewModel>.Success(model);
        }

        public ResultViewModel<int> Post(CreateProjectInputModel model)
        {
            var project = model.ToEntity();

            _context.Projects.Add(project);
            _context.SaveChanges();

            return ResultViewModel<int>.Success(project.Id);
        }

        public ResultViewModel Put(int id, UpdateProjectInputModel model)
        {
            var project = _context.Projects
            .SingleOrDefault(p => p.Id == id);

            if (project is null)
            {
                return ResultViewModel.Erro(DialogMessage.ProjectNotFound);
            }

            project.Update(model.Title, model.Description, model.TotalCost);

            _context.Projects.Update(project);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }

        public ResultViewModel Delete(int id)
        {
            var project = _context.Projects
                .SingleOrDefault(p => p.Id == id);

            if (project is null)
            {
                return ResultViewModel.Erro(DialogMessage.ProjectNotFound);
            }

            project.SetAsDeleted();
            _context.Projects.Update(project);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }

        public ResultViewModel Start(int id)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);

            if (project is null)
            {
                return ResultViewModel.Erro(DialogMessage.ProjectNotFound);
            }

            project.Start();

            _context.Projects.Update(project);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }
        public ResultViewModel Complete(int id)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);

            if (project is null)
            {
                return ResultViewModel.Erro(DialogMessage.ProjectNotFound);
            }

            project.Complete();
            _context.Projects.Update(project);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }

        public ResultViewModel PostComments(int id, CreateProjectCommentInputModel model)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);

            if (project is null)
            {
                return ResultViewModel.Erro(DialogMessage.ProjectNotFound);
            }

            var comment = new ProjectComment(model.Content, model.IdProject, model.IdUser);
            _context.ProjectComments.Add(comment);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }
    }
}
