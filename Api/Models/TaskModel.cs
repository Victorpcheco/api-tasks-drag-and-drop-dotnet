
using System.ComponentModel.DataAnnotations;

namespace Api.Models; 

public class TaskModel {
    [Required] 
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

}