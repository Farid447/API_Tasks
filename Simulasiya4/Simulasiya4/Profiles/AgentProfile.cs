using AutoMapper;
using Simulasiya4.Extentions;
using Simulasiya4.Models;
using Simulasiya4.ViewModels.Agent;

namespace Simulasiya4.Profiles;

public class AgentProfile : Profile
{
    public AgentProfile()
    {
        CreateMap<AgentCreateVM, Agent>();

        CreateMap<Agent, AgentUpdateVM>();
    }
}
