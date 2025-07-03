using System.ComponentModel.DataAnnotations;

public abstract class APIEntity
{
    [Key]
    public int Id { get; set; }
    public abstract string SearchKey { get; }
}