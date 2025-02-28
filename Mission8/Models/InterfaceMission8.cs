using System.Collections;

namespace Mission8.Models
{
    public interface InterfaceMission8
    {
        List<Task> Tasks { get; }

        void AddTask(Task task);
        IEnumerable<Categories> GetCategories();
        Task GetTaskById(int id);
        void UpdateTask(Task task);
        void DeleteTask(int id);
        void SaveChanges();
        void DeleteTask(Task app);
    }
}
