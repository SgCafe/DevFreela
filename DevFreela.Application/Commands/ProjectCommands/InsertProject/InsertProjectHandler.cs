﻿using DevFreela.Application.Models;
using DevFreela.Application.Notification.ProjectCreated;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.ProjectCommands.InsertProject
{
    public class InsertProjectHandler : IRequestHandler<InsertProjectCommand, ResultViewModel<int>>
    {
        private readonly IMediator _mediatoR;
        private readonly IProjectRepository _repository;

        public InsertProjectHandler(IProjectRepository repository, IMediator mediatoR)
        {
            _repository = repository;
            _mediatoR = mediatoR;
        }


        public async Task<ResultViewModel<int>> Handle(InsertProjectCommand request, CancellationToken cancellationToken)
        {
            var project = request.ToEntity();

            await _repository.Add(project);

            var projectCreated = new ProjectCreatedNotification(project.Id, project.Title, project.TotalCost);
            await _mediatoR.Publish(projectCreated);

            return ResultViewModel<int>.Success(project.Id);
        }
    }
}