namespace Simulasiya4.Models;

public class Agent : BaseEntity
{
    public string ImageUrl { get; set; } = "Default.png";
    public int? DesignationId { get; set; }
    public Designation? Designation { get; set; }
}
