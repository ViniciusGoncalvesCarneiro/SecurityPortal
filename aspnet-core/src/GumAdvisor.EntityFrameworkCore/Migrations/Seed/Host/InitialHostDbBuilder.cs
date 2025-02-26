using GumAdvisor.EntityFrameworkCore;

namespace GumAdvisor.Migrations.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly GumAdvisorDbContext _context;

        public InitialHostDbBuilder(GumAdvisorDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultEditionCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}
