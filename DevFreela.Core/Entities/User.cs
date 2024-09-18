namespace DevFreela.Core.Entities;

public class User : BaseEntity
{
    //Passa o Base para chamar o construtor base do BaseEntity
    public User(string fullName, string email, DateTime birthDate, bool active) : base()
    {
        FullName = fullName;
        Email = email;
        BirthDate = birthDate;
        Active = true;

        //Inicializa como vazio para evitar referências Nulas
        Skills = [];
        OwnedProjects = [];
        FreelanceProjects = [];
        Comments = [];
    }

    public string FullName { get; private set; }
    public string Email { get; private set; }
    public DateTime BirthDate { get; private set; }
    public bool Active { get; private set; }

    //RELACIONAMENTOS COM OUTRAS TABELAS
    public List<UserSkill> Skills { get; private set; }
    public List<Project> OwnedProjects { get; private set; }
    public List<Project> FreelanceProjects { get; private set; }
    public List<ProjectComment> Comments { get; private set; }
}