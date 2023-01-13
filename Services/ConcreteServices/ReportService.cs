using KbstAPI.Core.IRepositories;
using KbstAPI.Core.Repositories;
using KbstAPI.Core.UnitOfWork;
using KbstAPI.Data.Models;

namespace KbstAPI.Services.ConcreteServices
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public async Task<Report> Create(Report report)
        {
            report.Time = DateTime.Now;
            await _reportRepository.Add(report);
            await _reportRepository.Save();

            return report;
        }

        public async Task DeleteReport(int connectionID)
        {
            _reportRepository.Delete(connectionID);
            await _reportRepository.Save();
        }

        public async Task<IEnumerable<Report>> GetReports()
        {
           var reports = await _reportRepository.GetAll();
           return reports;
        }

        public async Task<Report?> GetReportByID(int connectionID)
        {
            var report = await _reportRepository.GetById(connectionID);
            if (report == null) return report;
            if (DateTime.Now - report.Time > TimeSpan.FromSeconds(30))
            {
                _reportRepository.Delete(connectionID);
                await _reportRepository.Save();
                return null;
            }
            else
            {
                report.Time = DateTime.Now;
                _reportRepository.Update(report);
                await _reportRepository.Save();
            }
            return report;
        }

        public async Task<Report> Create(int assetID)
        {
            //TODO: 
            var report = new Report();
            await _reportRepository.Add(report);
            await _reportRepository.Save();
            return report;
            
        }        
    }
}
