using System.ComponentModel.DataAnnotations;

namespace Simulasiya4.ViewModels.Designation;

public class DesignationUpdateVM
{
    [Required(ErrorMessage = "this field is required!"), MaxLength(32, ErrorMessage = "Length must be less than 32")]
    public string Name { get; set; }
}
