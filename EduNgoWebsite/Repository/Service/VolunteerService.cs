namespace EduNgoWebsite.Repository.Service;
using EduNgoWebsite.Models;
using EduNgoWebsite.Repository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

public class VolunteerService : IVolunteerService
{
    private readonly IVolunteerRepository _volunteerRepository;

    public VolunteerService(IVolunteerRepository volunteerRepository)
    {
        _volunteerRepository = volunteerRepository;
    }

    public IEnumerable<Volunteer> GetAllVolunteersAsync()
    {
        return _volunteerRepository.GetAllVolunteersAsync();
    }

    public Volunteer GetVolunteerByIdAsync(int id)
    {
        return _volunteerRepository.GetVolunteerByIdAsync(id);
    }

    public void AddVolunteerAsync(Volunteer volunteer)
    {
         _volunteerRepository.AddVolunteerAsync(volunteer);
    }

    public IEnumerable<State> GetAllStates()
    {
        return _volunteerRepository.GetAllStates();
    }

    public State GetStatesById(int Id)
    {
        return _volunteerRepository.GetStatesById(Id);
    }
}
