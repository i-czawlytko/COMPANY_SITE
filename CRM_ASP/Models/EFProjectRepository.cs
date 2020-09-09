using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM_MODEL_LIB;

namespace CRM_ASP.Models
{
    public class EFProjectRepository : IProjectRepository
    {
        private AppDbContext context;

        public EFProjectRepository(AppDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Project> Projects => context.Projects;

        public void SaveProject(Project project)
        {
            context.Projects.Add(project);
            context.SaveChanges();
        }
    }
}
