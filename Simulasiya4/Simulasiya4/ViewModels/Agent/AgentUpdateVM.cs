using System.ComponentModel.DataAnnotations;

namespace Simulasiya4.ViewModels.Agent;

public class AgentUpdateVM
{
    [Required(ErrorMessage = "this field is required!"), MaxLength(32, ErrorMessage = "Length must be less than 32")]
    public string Name { get; set; }
    public string ImageUrl { get; set; } = "Default.png";
    public IFormFile? Image { get; set; }
    public int? DesignationId { get; set; }
}
