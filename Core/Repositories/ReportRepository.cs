using KbstAPI.Core.IRepositories;
using KbstAPI.Data;
using KbstAPI.Data.Models;
using KbstAPI.Repository.Repositories;

namespace KbstAPI.Core.Repositories
{
    public class ReportRepository : BaseRepository<Report>, IReportRepository
    {
        public ReportRepository(KbstContext context) : base(context)
        {
        }
    }
}
