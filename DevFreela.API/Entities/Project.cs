﻿using DevFreela.API.Enums;

namespace DevFreela.API.Entities;

public class Project : BaseEntity
{
    //Deixa um construtor vazio para quando gerar as migrations, n dar problema com o EF
    protected Project(){ }
    
    public Project(string title, string description, int idCliente, int idFreelancer, User freelancer, decimal totalCost, ProjectStatusEnum status, List<ProjectComment> comments)
        :base()
    {
        Title = title;
        Description = description;
        IdCliente = idCliente;
        IdFreelancer = idFreelancer;
        Freelancer = freelancer;
        TotalCost = totalCost;
        Status = ProjectStatusEnum.Created;
        Comments = new List<ProjectComment>();
    }

    public string Title { get; private set; }
    public string Description { get; private set; }
    public int IdCliente { get; private set; }
    public User Client { get; private set; }
    public int IdFreelancer { get; private set; }
    public User Freelancer { get; private set; }
    public decimal TotalCost { get; private set; }
    public DateTime? StartedAt { get; private set; }
    public DateTime? CompletedAt { get; private set; }
    public ProjectStatusEnum Status { get; private set; }
    public List<ProjectComment> Comments { get; private set; }

    public void Cancel()
    {
        if (Status == ProjectStatusEnum.InProgress || Status == ProjectStatusEnum.Suspended)
        {
            Status = ProjectStatusEnum.Cancelled;
        }
    }

    public void Start()
    {
        if (Status == ProjectStatusEnum.Created)
        {
            Status = ProjectStatusEnum.InProgress;
            StartedAt = DateTime.Now;
        }
    }
    
    public void Complete()
    {
        if (Status == ProjectStatusEnum.PaymentPending || Status == ProjectStatusEnum.InProgress)
        {
            Status = ProjectStatusEnum.Completed;
            CompletedAt = DateTime.Now;
        }
    }
    
    public void SetPaymentPending()
    {
        if (Status == ProjectStatusEnum.InProgress)
        {
            Status = ProjectStatusEnum.PaymentPending;
        }
    }
    
    public void Update(string title, string description, decimal totalCost)
    {
        Title = title;
        Description = description;
        TotalCost = totalCost;
    }
}