using AutoMapper;
using KbstAPI.Core.DTO;
using KbstAPI.Data.Models;
using KbstAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace KbstAPI.Controllers
{
    [ApiController]
    [Route("configs")]
    public class ConfigController : ControllerBase
    {
        private KbstContext _context;
        private readonly IMapper _mapper;

        public ConfigController(KbstContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        /// <summary>
        /// Create configuration.
        /// </summary>
        /// <param name="config"></param>
        /// <returns>Created configuration</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     Post /Config
        ///     {
        ///         "type": "type1",
        ///         "properties": {
        ///             "additionalProp1": {
        ///             "visible": true,
        ///             "editable": true
        ///             },
        ///             "additionalProp2": {
        ///             "visible": true,
        ///             "editable": true
        ///             }
        ///         }
        ///     }
        /// </remarks>
        [HttpPost]
        public async Task<ActionResult> CreateConfig([FromBody] Config config)
        {
            _context.Add(config);
            await _context.SaveChangesAsync();
            return Ok();
        }

        /// <summary>
        /// Get all configurations.
        /// </summary>
        /// <returns>List of configurations</returns>
        [HttpGet]
        public async Task<ActionResult> GetConfig()
        {
            var res = _mapper.Map<List<PropertiesDTO>>(_context.Configs.ToList());
            await _context.SaveChangesAsync();
            return Ok(res);
        }
    }
}
