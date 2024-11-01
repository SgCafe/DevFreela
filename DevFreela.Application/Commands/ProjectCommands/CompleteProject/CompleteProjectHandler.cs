﻿using DevFreela.Application.Models;
using DevFreela.Application.UtilMessage;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Commands.ProjectCommands.CompleteProject
{
    public class CompleteProjectHandler : IRequestHandler<CompleteProjectCommand, ResultViewModel>
    {
        private readonly DevFreelaDbContext _context;

        public CompleteProjectHandler(DevFreelaDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel> Handle(CompleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _context.Projects.SingleOrDefaultAsync(p => p.Id == request.Id);

            if (project is null)
            {
                return ResultViewModel.Erro(DialogMessage.ProjectNotFound);
            }

            project.Complete();
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}
