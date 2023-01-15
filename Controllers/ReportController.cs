using KbstAPI.Core.DTO;
using KbstAPI.Data.Models;
using KbstAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace KbstAPI.Controllers
{
    [ApiController]
    [Route("reports")]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;
        public ReportController(IReportService reportService)
        {
            _reportService = reportService; 
        }

        /// <summary>
        /// Get all reports.
        /// </summary>
        /// <returns>List of reports.</returns>
        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<ActionResult> Get()
        {
            var result = await _reportService.GetReports();
            return Ok(result);
        }

        /// <summary>
        /// Heartbeat. 
        /// </summary>
        /// <param name="id">Connection ID</param>
        /// <returns>Specific report</returns>
        /// <response code="200">Returns specific report</response>
        /// <response code="400">If the report doesn't exist</response>
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _reportService.GetReportByID(id);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }

        /// <summary>
        /// Open connection
        /// </summary>
        /// <param name="assetId">Asset ID</param>
        /// <returns>Connection ID</returns>
        /// <response code="200">Returns connection ID</response>
        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        public async Task<ActionResult> Create([FromBody] int assetId)
        {
            var result = await _reportService.Create(assetId);
            return Ok(result);
        }

        /// <summary>
        /// Create report
        /// </summary>
        /// <param name="report"></param>
        /// <returns>Created report</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /Report
        ///     {
        ///         "name": "report1",
        ///         "numberOfColumns": 6
        ///     } 
        ///     
        /// </remarks>
        /// <response code="200">Returns the newly created report</response>
        //[HttpPost]
        //public async Task<ActionResult> Create([FromBody]Report report)
        //{
        //    var result = await _reportService.Create(report);
        //    return Ok(result);
        //}

        /// <summary>
        /// Close connection.
        /// </summary>
        /// <param name="id">Connection ID</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _reportService.DeleteReport(id);
            return Ok();
        }


    }
}
