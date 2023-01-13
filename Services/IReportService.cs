using KbstAPI.Data.Models;

namespace KbstAPI.Services
{
    public interface IReportService
    {
        Task<IEnumerable<Report>> GetReports();
        Task DeleteReport(int connectionID);
        Task<Report> Create(Report report);
        Task<Report?> GetReportByID(int connectionID);
        Task<Report> Create(int assetID);
    }
}
