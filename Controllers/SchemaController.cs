using AutoMapper;
using KbstAPI.Core.DTO;
using KbstAPI.Core.IRepositories;
using KbstAPI.Data;
using KbstAPI.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace KbstAPI.Controllers
{
    [ApiController]
    [Route("schemas")]
    //[ApiExplorerSettings(IgnoreApi = true)]
    public class SchemaController : ControllerBase
    {
        private KbstContext _context;
        private readonly IMapper _mapper;
        private IAssetRepository _assetRepository;

        public SchemaController(KbstContext context, IMapper mapper, IAssetRepository assetRepository) { 
            _context = context;
            _mapper = mapper;
            _assetRepository = assetRepository;
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
        public async Task<ActionResult> Get([FromQuery] string? type, string? subtype)
        {
            //var res = _mapper.Map<List<PropertiesDTO>>(_context.Schemas.ToList());
            //await _context.SaveChangesAsync();
            //return Ok(res);

            if(!this.HttpContext.Request.QueryString.HasValue)
            {
                var schemas = _context.Schemas.ToList();
                await _context.SaveChangesAsync();
                return Ok(schemas);
            }
            else if(!subtype.IsNullOrEmpty())
            {
                var schema = await _assetRepository.GetAssetSchema(subtype);
                if(schema != null)
                    return Ok(schema);

            }   

            var s = await _assetRepository.GetAssetSchemaByType(type);
            return Ok(s);
             
        }

    }
}
