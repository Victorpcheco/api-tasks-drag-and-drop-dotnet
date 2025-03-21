using System.ComponentModel.DataAnnotations;

namespace Api.Models; 

public class TaskModel {

    public int Id { get; set; }
    
    [Required]
    public string titulo { get; set; } = string.Empty;
    public string status { get; set; } = string.Empty;
    public string descricao { get; set; } = string.Empty;
    public string dataCriacao { get; set; } = DateTime.UtcNow.ToString("");

}