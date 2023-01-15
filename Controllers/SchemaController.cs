using AutoMapper;
using KbstAPI.Core.DTO;
using KbstAPI.Data;
using KbstAPI.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace KbstAPI.Controllers
{
    [ApiController]
    [Route("schemas")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class SchemaController : ControllerBase
    {
        private KbstContext _context;
        private readonly IMapper _mapper;

        public SchemaController(KbstContext context, IMapper mapper) { 
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Create Schema.
        /// </summary>
        /// <param name="schema"></param>
        /// <returns>Created schema</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /Schema
        ///     {
        ///         "type": "1",
        ///         "properties": {
        ///             "additionalProp1": {
        ///                 "name": "Prop1",
        ///                 "visible": true,
        ///                 "editable": true,
        ///                 "propertyType": 0
        ///             },
        ///             "additionalProp2": {
        ///                 "name": "Prop2",
        ///                 "visible": true,
        ///                 "editable": true,
        ///                 "propertyType": 1
        ///             }
        ///        }
        ///     }
        ///     
        /// </remarks>
        /// <response code="200">Returns the newly created schema</response>
        [HttpPost]
        public async Task<ActionResult> CreateSchema([FromBody] Schema schema)
        {
            _context.Add(schema);
            await _context.SaveChangesAsync();
            return Ok();
        }

        /// <summary>
        /// Get all schemas.
        /// </summary>
        /// <returns>List of schemas</returns>
        [HttpGet]
        public async Task<ActionResult> GetSchema()
        {
            var res = _mapper.Map<List<PropertiesDTO>>(_context.Schemas.ToList());
            await _context.SaveChangesAsync();
            return Ok(res);
        }
    }
}
