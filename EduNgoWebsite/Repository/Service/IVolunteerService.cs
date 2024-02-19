using EduNgoWebsite.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduNgoWebsite.Repository.Service
{
    public interface IVolunteerService
    {
        IEnumerable<Volunteer> GetAllVolunteersAsync();
        Volunteer GetVolunteerByIdAsync(int id);
        void AddVolunteerAsync(Volunteer volunteer);
        IEnumerable<State> GetAllStates();
        State GetStatesById(int id);
    }
}
