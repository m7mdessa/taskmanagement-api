using Domain.SharedKernel;
using Microsoft.VisualBasic;


namespace Domain.Aggregates.ProjectAggregate
{
    public class Sprint:BaseEntity, IFullAuditedObject
    {
        public string? SprintName { get; private set; }
        public string? SprintDescription { get; private set; }

        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public int ProjectId { get; private set; }
        public bool IsDeleted { get; private set; }

        public List<SprintTask> SprintTasks { get; private set; } = new List<SprintTask>();


        public Project Project { get; private set; }


        private Sprint() {}
      

        public Sprint(string? sprintName, DateTime startDate, DateTime endDate, int projectId,string ? sprintDescription)
        {
            SprintName = sprintName;
            StartDate = startDate;
            EndDate = endDate;
            ProjectId = projectId;
            SprintDescription = sprintDescription;

        }

        public void Update(int projectId, string? sprintName, string? sprintDescription)
        {
            SprintName = sprintName;
            ProjectId = projectId;
            SprintDescription = sprintDescription;

        }

        public void AddSprintTask(SprintTask sprintTask)
        {
            SprintTasks?.Add(sprintTask);
        }
        public void RemoveSprintTask(SprintTask sprintTask)
        {
            SprintTasks?.Remove(sprintTask);
        }
     
        public void UpdateSprintTask(int id, int sprintId, string? taskName, string? taskDescription, int developerId, string? taskStatus)
        {

            var sprintTask = SprintTasks?.FirstOrDefault(t => t.Id == id);
            if (sprintTask != null)
            {
                sprintTask.Update(id, sprintId, taskName, taskDescription, developerId,taskStatus);
            }
        }


       


    }
}
