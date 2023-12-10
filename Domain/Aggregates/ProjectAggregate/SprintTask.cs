using Domain.Aggregates.DeveloperAggregate;
using Domain.SharedKernel;

namespace Domain.Aggregates.ProjectAggregate
{
    public class SprintTask : BaseEntity, IFullAuditedObject
    {
        public string? TaskName { get; private set; }
        public string? TaskDescription { get; private set; }
        public string? TaskStatus { get; private set; }
        public string? TaskDuration { get; private set; }
        public int SprintId { get; private set; }
        public int DeveloperId { get; private set; }
        public bool IsDeleted { get; private set; }
        public Sprint? Sprint { get; private set; }


        private SprintTask() {}
        

        public SprintTask(string taskName, string? taskDescription,int sprintId, int developerId, string taskDuration)
        {
            TaskName = taskName;
            TaskDescription = taskDescription;
            TaskStatus = "Pending";
            TaskDuration = taskDuration;
            SprintId = sprintId;
            DeveloperId = developerId;
        }
       

        public void Update(int id, int sprintId, string? taskName, string? taskDescription, int developerId, string? taskStatus)
        {
            Id = id;
            SprintId = sprintId;
            TaskName = taskName;
            TaskDescription = taskDescription;
            TaskStatus = taskStatus;
            DeveloperId = developerId;



        }
      

    }
}
