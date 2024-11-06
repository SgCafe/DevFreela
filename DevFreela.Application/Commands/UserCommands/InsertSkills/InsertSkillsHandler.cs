using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Commands.UserCommands.InsertSkills
{
    public class InsertSkillsHandler : IRequestHandler<InsertSkillsCommand, ResultViewModel<int>>
    {
        private readonly DevFreelaDbContext _context;

        public InsertSkillsHandler(DevFreelaDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<int>> Handle(InsertSkillsCommand request, CancellationToken cancellationToken)
        {
            var userSkills = request.SkillIds.Select(s => new UserSkill(request.Id, request.SkillsId)).ToList();

            _context.UserSkills.AddRange(userSkills);
            await _context.SaveChangesAsync();

            return ResultViewModel<int>.Success(request.Id);
        }
    }
}
