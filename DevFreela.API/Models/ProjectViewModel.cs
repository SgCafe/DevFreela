using DevFreela.API.Entities;

namespace DevFreela.API.Models;

public class ProjectViewModel
{
    public ProjectViewModel(
        string title, string description, 
        int idClient, int idFreelancer, decimal totalCost)
    {
        Title = title;
        Description = description;
        IdClient = idClient;
        IdFreelancer = idFreelancer;
        TotalCost = totalCost;
    }
    //Para detalhes de um projeto
    //é algo bem mais detalhado

    public string Title { get; private set; }
    public string Description { get; private set; }
    public int IdClient { get; private set; }
    public int IdFreelancer { get; private set; }
    public decimal TotalCost { get; private set; }

    public static ProjectViewModel FromEntity(Project entity)
        => new (entity.Title, entity.Description,
                entity.IdClient, entity.IdFreelancer, entity.TotalCost);
}