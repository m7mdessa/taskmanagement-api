using Domain.SharedKernel;

namespace Domain.Aggregates.ProjectAggregate
{
    public  class Project :BaseEntity,IAggregateRoot, IFullAuditedObject
    {

        public string? ProjectName { get; private set; }
        public string? ProjectDescription { get; private set; }

        public bool IsDeleted { get; private set; }
        public IReadOnlyList<Sprint> Sprints => _sprints.AsReadOnly();

        

        private readonly List<Sprint> _sprints = new List<Sprint>();



        private Project() {}

        #region default constructor
        public Project(string projectName, string pojectDescription) 
        {
            ProjectName = projectName;
            ProjectDescription = pojectDescription;
        }
        #endregion


        #region UpdateProject
        public void UpdateProject(int id,string projectName, string pojectDescription)
        {
            Id = id;
            ProjectName = projectName;
            ProjectDescription = pojectDescription;

        }
        #endregion

        #region RemoveProject
        public void RemoveProject(int id)
        {
            var removeProject = _sprints?.SingleOrDefault(e => e.ProjectId == id);
            if (removeProject != null)
            {
                _sprints?.Remove(removeProject);

            }
        }
        #endregion

        #region AddSprint
        public void AddSprint(Sprint addSprint)
        {

            _sprints?.Add(addSprint);
        }
        #endregion


        #region UpdateSprint
        public void UpdateSprint(int id, int projectId, string sprintName, string? sprintDescription)
        {
            var update = _sprints?.FirstOrDefault(s => s.Id == id);
            if (update != null)
            {

                update.Update(projectId, sprintName, sprintDescription);
            }

        }

        #endregion


        #region RemoveSprint
        public void RemoveSprint(Sprint sprint)
        {
            _sprints.Remove(sprint);
        }
        #endregion

        #region AddSprintTaskToSprint

        public void AddSprintTaskToSprint(int sprintId, SprintTask sprintTask)
        {
            var sprint = _sprints?.FirstOrDefault(s => s.Id == sprintId);
            if (sprint != null)
            {
                sprint.AddSprintTask(sprintTask);
            }
        }
        #endregion


        #region RemoveSprintTask
        public void RemoveSprintTask(int sprintId, SprintTask sprintTask)
        {
            var sprint = _sprints?.FirstOrDefault(s => s.Id == sprintId);
            if (sprint != null)
            {
                sprint.RemoveSprintTask(sprintTask);


            }
        }

        #endregion

        #region UpdateSprintTask

        public void UpdateSprintTask(int id, int sprintId, string? taskName, string? taskDescription, int developerId, string? taskStatus)
        {

            var sprint = _sprints?.FirstOrDefault(s => s.Id == sprintId);
            if (sprint != null)
            {
                sprint.UpdateSprintTask(id, sprintId, taskName, taskDescription, developerId, taskStatus);
            }
        }
        #endregion




    }
}

