using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using MediatR;

namespace DevFreela.Application.Commands.UserCommands.InsertSkills
{
    public class InsertSkillsCommand : IRequest<ResultViewModel<int>>
    {


        public int Id { get; set; }
        public int SkillsId { get; set; }
        public int[] SkillIds { get; set; }
    }
}
