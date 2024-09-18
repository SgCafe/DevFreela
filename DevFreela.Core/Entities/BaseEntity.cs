namespace DevFreela.Core.Entities;

public abstract class BaseEntity
{
    public BaseEntity()
    {
        CreatedDate = DateTime.Now;
        IsDeleted = false;
    }
    
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool IsDeleted { get; set; }

    public void SetAsDeleted()
    {
        IsDeleted = true;
    }
}