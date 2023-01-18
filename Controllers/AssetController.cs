using KbstAPI.Core.DTO;
using KbstAPI.Data;
using KbstAPI.Data.Models;
using KbstAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
        /// Create asset.
        /// </summary>
        /// <param name="asset"></param>
        /// <returns>Created asset</returns>
        /// <remarks>
        /// Sample request: 
        /// 
        ///     Post /Asset
        ///     {
        ///         "parentId": "0e952fc2-4d57-42a8-90c9-71f10afba61a",
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
        ///     PUT /Asset
        ///     {
        ///         "id": "0e952fc2-4d57-42a8-90c9-71f10afba61a",
        ///         "parentId": "77126cf6-06ae-457a-a3aa-cc290499b945",
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
        public async Task<ActionResult> UpdateAsset(Guid id, [FromBody] Asset asset)
        {           
            var result = await _assetService.UpdateAsset(id, asset);
            return Ok(result);
        }

        /// <summary>
        /// Property change.
        /// </summary>
        /// <param name="id">Asset Id</param>
        /// <param name="changeRequest">Change Request</param>
        /// <remarks>
        /// Sample request: 
        /// 
        ///     PUT /Asset
        ///     {
        ///         "eventSource": "eventSource1"
        ///         "entity": {
        ///             "id": "0e952fc2-4d57-42a8-90c9-71f10afba61a",
        ///             "parentId": "77126cf6-06ae-457a-a3aa-cc290499b945",
        ///             "name": "asset1",
        ///             "type": "type1",
        ///             "subType": "subType1",
        ///             "icon": "icon1",
        ///             "description": "Asset description"
        ///         }
        ///     }
        /// 
        /// </remarks>
        /// <returns>Asset with updated schema.</returns>
        [HttpPut]
        [Route("{id}/change")]
        [ProducesResponseType(typeof(GetAssetResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult> Change(Guid id, [FromBody]ChangeRequest changeRequest)
        {
            return Ok(new GetAssetResponse());

        }
       

        /// <summary>
        /// Get asset and its children with schema.
        /// </summary>
        /// <param name="parentId">Parent ID</param>
        /// <param name="include" example="config"> 
        /// Include resources related to the asset
        /// config - List configuration
        /// </param>
        /// <param name="recursive" example="true">true - include asset and its subtree</param> 
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(GetAssetsResponse), StatusCodes.Status200OK)]    
        public async Task<ActionResult> Get([FromQuery]Guid parentId, string? include, string? recursive)
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
                if (result == null)
                    return BadRequest();
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
        [ProducesResponseType(typeof(GetAssetResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetById (Guid id)
        {
            var result = await _assetService.GetAssetsResponse(id, includeConfig:false, includeChildren: false, recursive: "");
            if (result == null)
                return BadRequest();
            return Ok(result);
        }

        /// <summary>
        /// Delete specific assets.
        /// </summary>
        /// <param name="Ids" example="0e952fc2-4d57-42a8-90c9-71f10afba61a, fb6681a4-2778-4717-9312-8f4462aa60fd">Asset ids</param>
        /// <param name="force"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(ChangesResponse<Asset>), StatusCodes.Status200OK)]
        public async Task<ActionResult> Delete([FromQuery] string Ids, bool? force)
        {
            var assetIds = Ids.Split(',').ToList();
            var guids = new List<Guid>();
            for(int i = 0; i < assetIds.Count; i++)
            {
                guids.Add(Guid.Parse(assetIds[i]));
            }
            if (assetIds == null)
                return BadRequest();
            var result = await _assetService.DeleteMany(guids, force ?? false);
            return result;
        }

        #region AssetNodes

        /// <summary>
        /// Get asset nodes.
        /// </summary>
        /// <returns>List of asset nodes</returns>
        [HttpGet]
        [Route("nodes")]
        [ProducesResponseType(typeof(List<AssetNode>), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAssetNodes()
        {
            var result = await _assetService.GetAssetNodes();
            return Ok(result);
        }

        /// <summary>
        /// Delete specific ids.
        /// </summary>
        /// <param name="Ids" example="0e952fc2-4d57-42a8-90c9-71f10afba61a, fb6681a4-2778-4717-9312-8f4462aa60fd">Asset node ids</param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ChangesResponse<AssetNode>), StatusCodes.Status200OK)]
        [HttpDelete]
        [Route("nodes")]
        public async Task<ActionResult> DeleteNodes(string Ids)
        {
            var assetIds = Ids.Split(',').ToList();
            var guids = new List<Guid>();
            for (int i = 0; i < assetIds.Count; i++)
            {
                guids.Add(Guid.Parse(assetIds[i]));
            }
            if (assetIds == null)
                return BadRequest();
            var result = await _assetService.DeleteManyNodes(guids);
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
        ///         "parentId": "0e952fc2-4d57-42a8-90c9-71f10afba61a",       
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
        ///     PUT /AssetNode
        ///     {   
        ///         "id": "77126cf6-06ae-457a-a3aa-cc290499b945",
        ///         "parentId": "0e952fc2-4d57-42a8-90c9-71f10afba61a, fb6681a4-2778-4717-9312-8f4462aa60fd",       
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
        public async Task<ActionResult> UpdateAssetNode(Guid id, AssetNode assetNode)
        {
            var result = await _assetService.UpdateAssetNode(assetNode);
            return Ok(result);
        }

        #endregion

    }
}
