namespace Mission8.Models
{
    public class EFMission8 : InterfaceMission8
    {
        private Mission8DBContext _context;
        public EFMission8 (Mission8DBContext temp) 
        { 
            _context = temp;
        }

        public List<Task> Task => _context.Task.ToList();


        public void AddTask(Task task)
        {
            _context.Add(task);
            _context.SaveChanges();
        }

    }
}
