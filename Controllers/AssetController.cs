using KbstAPI.Core.DTO;
using KbstAPI.Data;
using KbstAPI.Data.Models;
using KbstAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace KbstAPI.Controllers
{
    [ApiController]
    [Route("assets")]
    public class AssetController : ControllerBase
    {
        private readonly IAssetService _assetService;
        private readonly ILogger<AssetController> _logger;


        public AssetController(ILogger<AssetController> logger, IAssetService assetService)
        {
            _logger = logger;
            _assetService = assetService;

        }

        /// <summary>  
        /// Get all assets.
        /// </summary>
        /// <returns>List of assets</returns>
        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    var result = await _assetService.GetAssets();
        //    return Ok(result);
        //}

        /// <summary>
        /// Create asset.
        /// </summary>
        /// <param name="asset"></param>
        /// <returns>Created asset</returns>
        /// <remarks>
        /// Sample request: 
        /// 
        ///     Post /Asset
        ///     {
        ///         "parentId": -1,
        ///         "name": "asset1",
        ///         "type": "type1",
        ///         "subType": "subType1",
        ///         "icon": "icon1",
        ///         "description": "Asset description"
        ///     }
        /// 
        /// </remarks>
        [HttpPost]
        [ProducesResponseType(typeof(ChangesResponse<Asset>), StatusCodes.Status200OK)]
        public async Task<ActionResult> CreateAsset([FromBody] Asset asset)
        {
            var result = await _assetService.CreateAsset(asset);
            return Ok(result);
        }

        /// <summary>
        /// Update asset.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="asset"></param>
        /// <returns>Updated asset</returns>
        /// <remarks>
        /// Sample request: 
        /// 
        ///     Post /Asset
        ///     {
        ///         "id": 1,
        ///         "parentId": -1,
        ///         "name": "asset1",
        ///         "type": "type1",
        ///         "subType": "subType1",
        ///         "icon": "icon1",
        ///         "description": "Asset description"
        ///     }
        /// 
        /// </remarks>
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(ChangesResponse<Asset>), StatusCodes.Status200OK)]
        public async Task<ActionResult> UpdateAsset(int id, [FromBody] Asset asset)
        {           
            var result = await _assetService.UpdateAsset(id, asset);
            return Ok(result);
        }

        /// <summary>
        /// Get asset and its children with schema.
        /// </summary>
        /// <param name="parentId">Parent ID</param>
        /// <param name="include" example="config"> 
        /// Include resources related to the asset
        /// \nconfig - List configuration
        /// </param>
        /// <param name="recursive" example="true">true - include asset and its subtree</param> 
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(GETResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult> Get([FromQuery]int parentId, string? include, string? recursive)
        {
            if (!this.HttpContext.Request.QueryString.HasValue)
            {
                var assets = await _assetService.GetAssets();
                return Ok(assets);
            }
            else
            {
                var includeConfig = (include == null) ? false : include.Contains("config");
                var result = await _assetService.GetAssetsResponse(parentId, includeConfig, includeChildren: true, recursive);
                return Ok(result);
            }
        }

        /// <summary>
        /// Get specific asset with schema.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/assets/{id}")]
        [ProducesResponseType(typeof(GETResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult> Getbyid (int id)
        {
            var result = await _assetService.GetAssetsResponse(id, includeConfig:false, includeChildren: false, recursive: "");
            return Ok(result);
        }

        /// <summary>
        /// Delete specific assets.
        /// </summary>
        /// <param name="Ids" example="1,2">Asset ids</param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(ChangesResponse<Asset>), StatusCodes.Status200OK)]
        public async Task<ActionResult> Delete([FromQuery] string Ids)
        {
            var assetIds = Ids.Split(',')?.Select(Int32.Parse)?.ToList();
            if (assetIds == null)
                return BadRequest();
            var result = await _assetService.DeleteMany(assetIds);
            return Ok(result);
        }

        #region AssetNodes

        /// <summary>
        /// Get asset nodes.
        /// </summary>
        /// <returns>List of asset nodes</returns>
        [HttpGet]
        [Route("nodes")]
        [ProducesResponseType(typeof(GETResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAssetNodes()
        {
            var result = await _assetService.GetAssetNodes();
            return Ok(result);
        }

        /// <summary>
        /// Delete specific ids.
        /// </summary>
        /// <param name="Ids" example="1,2">Asset node ids</param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ChangesResponse<AssetNode>), StatusCodes.Status200OK)]
        [HttpDelete]
        [Route("nodes")]
        public async Task<ActionResult> DeleteNodes(string Ids)
        {
            var assetIds = Ids.Split(',')?.Select(Int32.Parse)?.ToList();
            if (assetIds == null)
                return BadRequest();
            var result = await _assetService.DeleteMany(assetIds);
            return Ok(result);
        }

        /// <summary>
        /// Create asset node
        /// </summary>
        /// <param name="assetNode"></param>
        /// <returns>Created asset node</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /AssetNode
        ///     {   
        ///         "parentId": 2,       
        ///         "name": "string",
        ///         "type": "1",
        ///         "subType": "string",
        ///         "icon": "string",
        ///         "children": [
        ///         ]
        ///     }
        /// 
        /// </remarks>
        [HttpPost]
        [Route("nodes")]
        [ProducesResponseType(typeof(ChangesResponse<AssetNode>), StatusCodes.Status200OK)]
        public async Task<ActionResult> CreateAssetNode(AssetNode assetNode)
        {
            var result = await _assetService.CreateAssetNode(assetNode);
            return Ok(result);
        }

        /// <summary>
        /// Update asset 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="assetNode"></param>
        /// <returns>Updated asset</returns>
        /// <remarks>
        /// 
        /// Sample request:
        /// 
        ///     POST /AssetNode
        ///     {   
        ///         "id": 1,
        ///         "parentId": 2,       
        ///         "name": "string",
        ///         "type": "1",
        ///         "subType": "string",
        ///         "icon": "string",
        ///         "children": [
        ///         ]
        ///     }
        /// 
        ///</remarks>

        [HttpPut]
        [Route("nodes/{id}")]
        [ProducesResponseType(typeof(ChangesResponse<AssetNode>), StatusCodes.Status200OK)]
        public async Task<ActionResult> UpdateAssetNode(int id, AssetNode assetNode)
        {
            var result = await _assetService.UpdateAssetNode(assetNode);
            return Ok(result);
        }

        #endregion

    }
}
