namespace EduNgoWebsite.Repository.Interface;
using EduNgoWebsite.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IVolunteerRepository
{
    IEnumerable<Volunteer> GetAllVolunteersAsync();
    Volunteer GetVolunteerByIdAsync(int id);
    void AddVolunteerAsync(Volunteer volunteer);
    IEnumerable<State> GetAllStates();
    State GetStatesById(int id);

}
