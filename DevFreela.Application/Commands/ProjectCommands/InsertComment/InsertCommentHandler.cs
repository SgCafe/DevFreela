﻿using DevFreela.Application.Models;
using DevFreela.Application.UtilMessage;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.ProjectCommands.InsertComment
{
    public class InsertCommentHandler : IRequestHandler<InsertCommentCommand, ResultViewModel>
    {
        private readonly IProjectRepository _repository;

        public InsertCommentHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(InsertCommentCommand request, CancellationToken cancellationToken)
        {
            var exists = await _repository.Exists(request.IdProject);

            if (!exists)
            {
                return ResultViewModel.Erro(DialogMessage.ProjectNotFound);
            }

            var comment = new ProjectComment(request.Content, request.IdProject, request.IdUser);
            await _repository.AddComment(comment);

            return ResultViewModel.Success();
        }
    }
}
