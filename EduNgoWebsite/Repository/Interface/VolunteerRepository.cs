namespace EduNgoWebsite.Repository.Service;

using EduNgoWebsite.LogHelper;
using EduNgoWebsite.Models;
using EduNgoWebsite.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class VolunteerRepository : IVolunteerRepository
{
    private readonly IVolunteerRepository _volunteerRepository;
    private readonly EduNgoWebsiteContext _DbContext;
    private readonly ILoggerManager _logger;

    public VolunteerRepository(EduNgoWebsiteContext Db, ILoggerManager logger)
    {
        _DbContext = Db;
        _logger = logger;
    }

    //public VolunteerRepository(IVolunteerRepository volunteerRepository)
    //{
    //    _volunteerRepository = volunteerRepository;
    //}


    public IEnumerable<Volunteer> GetAllVolunteersAsync()
{
        try
        {
            var volunteerList = from a in _DbContext.tbl_Volunteer.ToList() select a;
            return volunteerList;
        }
        catch (Exception ex)
        {

            _logger.LogErrorDB(ex);
            throw(ex);
        }
}
    public Volunteer GetVolunteerByIdAsync(int id)
    {
        return  _volunteerRepository.GetVolunteerByIdAsync(id);
    }

    public void AddVolunteerAsync(Volunteer volunteer)
    {
        //_volunteerRepository.AddVolunteerAsync(volunteer);
        try {
            if (volunteer.Id == 0 || volunteer.Id == null)
            {
                volunteer.CreatedDate = DateTime.Now;
                _DbContext.tbl_Volunteer.Add(volunteer);
                _DbContext.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            _logger.LogErrorDB(ex);
        }
    }

    public IEnumerable<State> GetAllStates()
    {
        List<State> stateList = new List<State>();
        stateList = _DbContext.tbl_State.ToList();
        return stateList;


    }

    public State GetStatesById(int id)
    {
        //return _volunteerRepository.GetStatesById(id);
        return _DbContext.tbl_State.Find(id);
    }
}

