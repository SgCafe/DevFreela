using Azure;
using DevFreela.Application.Models;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace DevFreela.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly DevFreelaDbContext _context;

        public ProjectService(DevFreelaDbContext context)
        {
            _context = context;
        }

        public ResultViewModel<List<ProjectItemViewModel>> GetAll(int page, int size, string search = "")
        {
            var projects = _context.Projects
           .Include(p => p.Client)
           .Include(p => p.Freelancer)
           .Where(p => !p.IsDeleted && (search == "" || p.Title.Contains(search) || p.Description.Contains(search)))
           .Skip(page * size)
           .Take(size)
           .ToList();

            var model = projects.Select(ProjectViewModel.FromEntity).ToList();

            ResultViewModel<List<ProjectItemViewModel>>
        }
    }
}
