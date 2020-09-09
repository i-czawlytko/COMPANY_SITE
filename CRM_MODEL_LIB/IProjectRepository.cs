using System;
using System.Collections.Generic;
using System.Text;

namespace CRM_MODEL_LIB
{
    public interface IProjectRepository
    {
        IEnumerable<Project> Projects { get; }
        void SaveProject(Project project);
    }
}
