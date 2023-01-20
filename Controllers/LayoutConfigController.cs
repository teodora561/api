using KbstAPI.Data;
using KbstAPI.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KbstAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class LayoutConfigController : ControllerBase
    {
        private KbstContext _context;
        public LayoutConfigController(KbstContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("/labelOptions")]
        public async Task<ActionResult> CreateLabelOptions([FromBody] LabelOptions labelOptions)
        {
            _context.Add(labelOptions);
            await _context.SaveChangesAsync();
            return Ok(labelOptions);
        }

        [HttpPost]
        [Route("/label")]
        public async Task<ActionResult> CreateLabel([FromBody] Label label)
        {
            _context.Add(label);
            await _context.SaveChangesAsync();
            return Ok(label);
        }

        [HttpGet]
        [Route("/label/{id}")]
        public async Task<ActionResult> GetLabel(int id)
        {
            var label = _context.Labels.Where(l => l.ID == id).Include(l => l.Options).FirstOrDefault();
            await _context.SaveChangesAsync();
            return Ok(label);
        }

        [HttpPost]
        [Route("/group")]
        public async Task<ActionResult> CreateGroup([FromBody] Group group)
        {
            group.Type = ContentType.Group;
            _context.Add(group);
            await _context.SaveChangesAsync();
            return Ok(group); 

        }

        [HttpPost]
        [Route("/propertyRef")]
        public async Task<ActionResult> CreatePropertyRef([FromBody] PropertyRef propertyRef)
        {
            propertyRef.Type = ContentType.Property;
            _context.Add(propertyRef);
            await _context.SaveChangesAsync();
            return Ok(propertyRef);
        }

        [HttpGet]
        [Route("/group/{id}")]
        public  async Task<ActionResult> GetGroup(int id)
        {
            var label = _context.Groups.Where(g => g.ID == id).Include(g => g.Content).Include(g => g.Label).FirstOrDefault();
            await _context.SaveChangesAsync();
            return Ok(label);
        }

        [HttpPost]
        [Route("/layoutSection")]
        public async Task<ActionResult> CreateLayoutSection([FromBody] LayoutSection layoutSection)
        {
            _context.Add(layoutSection);
            await _context.SaveChangesAsync();
            return Ok(layoutSection);
        }

        [HttpGet]
        [Route("/layoutSection/{id}")]
        public async Task<ActionResult> GetLayoutSection(int id)
        {
            var ls = _context.LayoutSections.Where(ls => ls.ID == id).Include(ls => ls.Content).FirstOrDefault();
            await _context.SaveChangesAsync();
            return Ok(ls);
        }

        [HttpGet]
        [Route("/layoutConfig/{id}")]
        public async Task<ActionResult> GetLayoutCiongif(int id)
        {
            var ls = _context.LayoutConfigs.Where(lc => lc.ID == id).Include(lc => lc.Sections).FirstOrDefault();
            await _context.SaveChangesAsync();
            return Ok(ls);
        }

        [HttpPost]
        [Route("/layoutConfig")]
        public async Task<ActionResult> CreateLayoutConfig([FromBody] LayoutConfig layoutConfig)
        {
            _context.Add(layoutConfig);
            await _context.SaveChangesAsync();
            return Ok(layoutConfig);
        }
    }
}
