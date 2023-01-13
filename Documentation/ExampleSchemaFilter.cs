using KbstAPI.Core.DTO;
using KbstAPI.Data.Models;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection.PortableExecutable;

namespace KbstAPI.Documentation
{
    public class ExampleSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if(context.Type == typeof(Asset))
            {
                
                schema.Example = new OpenApiObject()
                {
                    ["id"] = new OpenApiInteger(2),
                    ["parentId"] = new OpenApiInteger(1),
                    ["name"] = new OpenApiString("assetName"),
                    ["type"] = new OpenApiString("type1"),
                    ["subtype"] = new OpenApiString("subtype1"),
                    ["icon"] = new OpenApiString("icon2"),
                    ["description"] = new OpenApiString("asset description")

                };
            }
            else if (context.Type == typeof(AssetNode))
            {
                schema.Example = new OpenApiObject()
                {
                    ["id"] = new OpenApiInteger(2),
                    ["parentId"] = new OpenApiInteger(1),
                    ["name"] = new OpenApiString("assetName"),
                    ["type"] = new OpenApiString("type1"),
                    ["subtype"] = new OpenApiString("subtype1"),
                    ["icon"] = new OpenApiString("icon2"),
                    ["description"] = new OpenApiString("asset description"),
                    ["children"] = new OpenApiArray()

                };
            }
            else if (context.Type == typeof(ChangesResponse<Asset>))
            {
                schema.Example = new OpenApiObject()
                {
                    ["actions"] = new OpenApiArray() { new OpenApiString("action1"), new OpenApiString("action2")},
                    ["entities"] = new OpenApiArray() 
                        { 
                            new OpenApiObject()
                            {
                                ["id"] = new OpenApiInteger(2),
                                ["parentId"] = new OpenApiInteger(1),
                                ["name"] = new OpenApiString("assetName1"),
                                ["type"] = new OpenApiString("type1"),
                                ["subtype"] = new OpenApiString("subtype1"),
                                ["icon"] = new OpenApiString("icon2"),
                                ["description"] = new OpenApiString("asset description")
                                
                            },
                            new OpenApiObject()
                            {
                                ["id"] = new OpenApiInteger(3),
                                ["parentId"] = new OpenApiInteger(1),
                                ["name"] = new OpenApiString("assetName2"),
                                ["type"] = new OpenApiString("type1"),
                                ["subtype"] = new OpenApiString("subtype1"),
                                ["icon"] = new OpenApiString("icon2"),
                                ["description"] = new OpenApiString("asset description")
                                
                            },

                        }
                };
            }
            else if (context.Type == typeof(ChangesResponse<AssetNode>))
            {
                schema.Example = new OpenApiObject()
                {
                    ["actions"] = new OpenApiArray() { new OpenApiString("action1"), new OpenApiString("action2") },
                    ["entities"] = new OpenApiArray()
                        {
                            new OpenApiObject()
                            {
                                ["id"] = new OpenApiInteger(2),
                                ["parentId"] = new OpenApiInteger(1),
                                ["name"] = new OpenApiString("assetName1"),
                                ["type"] = new OpenApiString("type1"),
                                ["subtype"] = new OpenApiString("subtype1"),
                                ["icon"] = new OpenApiString("icon2"),
                                ["description"] = new OpenApiString("asset description")
                            },
                            new OpenApiObject()
                            {
                                ["id"] = new OpenApiInteger(3),
                                ["parentId"] = new OpenApiInteger(1),
                                ["name"] = new OpenApiString("assetName2"),
                                ["type"] = new OpenApiString("type1"),
                                ["subtype"] = new OpenApiString("subtype1"),
                                ["icon"] = new OpenApiString("icon2"),
                                ["description"] = new OpenApiString("asset description")
                            },

                        }
                };
            }
        }
    }
}
