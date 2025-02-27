using Microsoft.EntityFrameworkCore;
using Mission8.Models;
using System.Collections.Generic;
using System.Linq;

public class EFMission8 : InterfaceMission8
{
    private Mission8DBContext _context;

    public EFMission8(Mission8DBContext temp)
    {
        _context = temp;
    }

    public List<Mission8.Models.Task> Tasks => _context.Tasks.ToList();

    public Mission8.Models.Task GetTaskById(int id)
    {
        return _context.Tasks.SingleOrDefault(x => x.TaskId == id);
    }

    public void AddTask(Mission8.Models.Task task)
    {
        _context.Add(task);
        _context.SaveChanges();
    }

    public void UpdateTask(Mission8.Models.Task task)
    {
        _context.Update(task);
        _context.SaveChanges();
    }
}


