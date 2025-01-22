using System.ComponentModel.DataAnnotations;

namespace Simulasiya4.ViewModels.Agent;

public class AgentCreateVM
{
    [Required(ErrorMessage= "this field is required!"), MaxLength(32, ErrorMessage = "Length must be less than 32")]
    public string Name { get; set; }
    public IFormFile? Image { get; set; }
    public int? DesignationId { get; set; }
}
