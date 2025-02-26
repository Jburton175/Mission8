namespace Mission8.Models
{
    public interface InterfaceMission8
    {
        List<Task> Tasks { get; }

        void AddTask(Task task);
        Task GetTaskById(int id);
        void UpdateTask(Task task);
    }
}
