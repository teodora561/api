
using KbstAPI.Data.Models;
using KbstAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace KbstAPI.Controllers
{
    [ApiController]
    public class AssetTypeController : ControllerBase
    {
        private readonly IAssetTypeService _assetTypeService;
        private readonly ILogger<AssetTypeController> _logger;

        public AssetTypeController(ILogger<AssetTypeController> logger, IAssetTypeService assetTypeService)
        {
            _logger = logger;
            _assetTypeService = assetTypeService;
        }

        /// <summary>
        /// Create asset type.
        /// </summary>
        /// <param name="assetType"></param>
        /// <returns>Created asset type</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     Post /AssetType
        ///     {
        ///         "icon": "icon1",
        ///         "displayName": "Signal",
        ///         "parentId": -1,
        ///         "subTypes": [
        ///             {
        ///                 "icon": "icon2",
        ///                 "displayName": "Signal2",
        ///                 "parentId": 1,
        ///                 "subTypes": [
        ///                 ]
        ///             }
        ///         ]
        ///     }
        /// </remarks>
        [HttpPost]
        [Route("/assets/types")]
        public async Task<ActionResult> CreateAssetType([FromBody] AssetType assetType)
        {
            var res = await _assetTypeService.Create(assetType);
            return Ok(res);
        }

        /// <summary>
        /// Get all asset types.
        /// </summary>
        /// <returns>List of asset types</returns>
        [HttpGet]
        [Route("/assets/types")]
        public async Task<ActionResult> Get()
        {
            var res = await _assetTypeService.GetAssetTypes();
            return Ok(res.ToList());
        }


    }
}
