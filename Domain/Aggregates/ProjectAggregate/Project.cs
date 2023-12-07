using Domain.SharedKernel;

namespace Domain.Aggregates.ProjectAggregate
{
    public  class Project :BaseEntity,IAggregateRoot, IFullAuditedObject
    {

        public string? ProjectName { get; private set; }

        public bool IsDeleted { get; private set; }
        public IReadOnlyList<Sprint> Sprints => _sprints.AsReadOnly();

        

        private readonly List<Sprint> _sprints = new List<Sprint>();



        private Project() {}
           
        public Project(string projectName) 
        {
            ProjectName = projectName;
        }
        public void UpdateProject(int id,string projectName)
        {
            Id = id;
            ProjectName = projectName;
        }
        public void RemoveProject(int id)
        {
            var removeProject = _sprints?.SingleOrDefault(e => e.ProjectId == id);
            if (removeProject != null)
            {
                _sprints?.Remove(removeProject);

            }
        }
     
        public void AddSprint(Sprint addSprint)
        {

            _sprints?.Add(addSprint);
        }


        public void UpdateSprint(int id, int projectId, string sprintName)
        {
            var update = _sprints?.FirstOrDefault(s => s.Id == id);
            if (update != null)
            {

                update.Update(projectId, sprintName);
            }

        }

        public void RemoveSprint(Sprint sprint)
        {
            _sprints.Remove(sprint);
        }


        public void AddSprintTaskToSprint(int sprintId, SprintTask sprintTask)
        {
            var sprint = _sprints?.FirstOrDefault(s => s.Id == sprintId);
            if (sprint != null)
            {
                sprint.AddSprintTask(sprintTask);
            }
        }


        public void RemoveSprintTask(int sprintId, SprintTask sprintTask)
        {
            var sprint = _sprints?.FirstOrDefault(s => s.Id == sprintId);
            if (sprint != null)
            {
                sprint.RemoveSprintTask(sprintTask);


            }
        }



        public void UpdateSprintTask(int id, int sprintId, string? taskName, string? taskDescription, int developerId, string? taskStatus)
        {

            var sprint = _sprints?.FirstOrDefault(s => s.Id == sprintId);
            if (sprint != null)
            {
                sprint.UpdateSprintTask(id, sprintId, taskName, taskDescription, developerId, taskStatus);
            }
        }




    }
}

