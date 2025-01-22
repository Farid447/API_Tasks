namespace Simulasiya4.Models;

public class Designation : BaseEntity
{
    public IEnumerable<Agent>? Agents { get; set; }
}
