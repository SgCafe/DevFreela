﻿using DevFreela.Application.Models;
using DevFreela.Application.UtilMessage;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.ProjectCommands.UpdateProject
{
    public class UpdateProjectHandler : IRequestHandler<UpdateProjectCommand, ResultViewModel>
    {

        private readonly IProjectRepository _repository;

        public UpdateProjectHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _repository.GetById(request.IdProject);

            if (project is null)
            {
                return ResultViewModel.Erro(DialogMessage.ProjectNotFound);
            }

            project.Update(request.Title, request.Description, request.TotalCost);
            await _repository.Update(project);

            return ResultViewModel.Success();
        }
    }
}