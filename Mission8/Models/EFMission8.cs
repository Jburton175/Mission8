﻿using Microsoft.EntityFrameworkCore;
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
        var existingTask = _context.Tasks.FirstOrDefault(t => t.TaskId == task.TaskId);
    
        if (existingTask != null)
        {
            existingTask.name = task.name;
            existingTask.due_date = task.due_date;
            existingTask.quadrant = task.quadrant;
            existingTask.completed = task.completed;
            existingTask.CategoryId = task.CategoryId;

            _context.Update(existingTask); // Mark for update
            _context.SaveChanges(); // Save changes
        }
    }


    public IEnumerable<Categories> GetCategories()
    {
        return _context.Category.ToList();
    }

    public void DeleteTask(Mission8.Models.Task task)
    {
        var delete = _context.Tasks.SingleOrDefault(t => t.TaskId == task.TaskId);
        if (delete != null)
        {
            _context.Tasks.Remove(delete);
            _context.SaveChanges();
        }

    }

    public void SaveChanges()
    {
        throw new NotImplementedException();
    }

    public void DeleteTask(int id)
    {
        throw new NotImplementedException();
    }
}


