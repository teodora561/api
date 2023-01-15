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
            //context.SchemaRepository.Schemas.Remove("PropertiesDTO");

            if (context.Type == typeof(Asset))
            {

                schema.Example = new OpenApiObject()
                {
                    ["id"] = new OpenApiString("1"),
                    ["parentId"] = new OpenApiString("1"),
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
                    ["id"] = new OpenApiString("2"),
                    ["parentId"] = new OpenApiString("1"),
                    ["name"] = new OpenApiString("assetName"),
                    ["type"] = new OpenApiString("type1"),
                    ["subtype"] = new OpenApiString("subtype1"),
                    ["icon"] = new OpenApiString("icon2"),
                    ["description"] = new OpenApiString("asset description"),
                    ["children"] = new OpenApiArray()

                };
            }
            else if (context.Type == typeof(AssetChangesResponse))
            {
                schema.Example = new OpenApiObject()
                {
                    ["actions"] = new OpenApiArray() { new OpenApiString("action1"), new OpenApiString("action2") },
                    ["entities"] = new OpenApiArray()
                        {
                            new OpenApiObject()
                            {
                                ["id"] = new OpenApiString ("1"),
                                ["parentId"] = new OpenApiString ("3"),
                                ["name"] = new OpenApiString("assetName1"),
                                ["type"] = new OpenApiString("type1"),
                                ["subtype"] = new OpenApiString("subtype1"),
                                ["icon"] = new OpenApiString("icon2"),
                                ["description"] = new OpenApiString("asset description")

                            },
                            new OpenApiObject()
                            {
                                ["id"] = new OpenApiString ("1"),
                                ["parentId"] = new OpenApiString ("2"),
                                ["name"] = new OpenApiString("assetName2"),
                                ["type"] = new OpenApiString("type1"),
                                ["subtype"] = new OpenApiString("subtype1"),
                                ["icon"] = new OpenApiString("icon2"),
                                ["description"] = new OpenApiString("asset description")

                            },

                        }
                };
            }
            else if (context.Type == typeof(AssetNodesChangesResponse))
            {
                schema.Example = new OpenApiObject()
                {
                    ["actions"] = new OpenApiArray() { new OpenApiString("action1"), new OpenApiString("action2") },
                    ["entities"] = new OpenApiArray()
                        {
                            new OpenApiObject()
                            {
                                ["id"] = new OpenApiString ("2"),
                                ["parentId"] = new OpenApiString ("1"),
                                ["name"] = new OpenApiString("assetName1"),
                                ["type"] = new OpenApiString("type1"),
                                ["subtype"] = new OpenApiString("subtype1"),
                                ["icon"] = new OpenApiString("icon2"),
                                ["description"] = new OpenApiString("asset description")
                            },
                            new OpenApiObject()
                            {
                                ["id"] = new OpenApiString ("2"),
                                ["parentId"] = new OpenApiString ("1"),
                                ["name"] = new OpenApiString("assetName2"),
                                ["type"] = new OpenApiString("type1"),
                                ["subtype"] = new OpenApiString("subtype1"),
                                ["icon"] = new OpenApiString("icon2"),
                                ["description"] = new OpenApiString("asset description")
                            },

                        }
                };
            }
            else if (context.Type == typeof(PropertiesDTO))
            {
                schema.Example = new OpenApiObject()
                {
                    ["prop1"] = new OpenApiObject() { ["visible"] = new OpenApiBoolean(true), ["editable"] = new OpenApiBoolean(true) },
                    ["prop2"] = new OpenApiObject() { ["visible"] = new OpenApiBoolean(true), ["editable"] = new OpenApiBoolean(true) }
                };

            }

            else if (context.Type == typeof(AssetType))
            {
                schema.Example = new OpenApiObject()
                {
                    ["icon"] = new OpenApiString("icon1"),
                    ["displayName"] = new OpenApiString("Log"),
                    ["parentId"] = new OpenApiString("1"),
                    ["subTypes"] = new OpenApiArray()
                    {
                        new OpenApiObject() {
                            ["icon"] = new OpenApiString("icon2"),
                            ["displayName"] = new OpenApiString("CLC"),
                            ["parentId"] = new OpenApiString("2"),
                            ["subTypes"] = new OpenApiArray()
                        }
                    }
                };
            }

            else if (context.Type == typeof(Schema))
            {
                schema.Example = new OpenApiObject()
                {
                    ["type"] = new OpenApiString("1"),
                    ["persistencyState"] = new OpenApiString("New"),
                    ["template"] = new OpenApiObject()
                    {
                        ["sections"] = new OpenApiArray()
                        {
                            new OpenApiObject()
                            {
                                ["type"] = new OpenApiString("Columns"),
                                ["name"] = new OpenApiString("Name"),
                                ["columnRatio"] = new OpenApiArray()
                                {
                                    new OpenApiInteger(1),
                                    new OpenApiInteger(2),
                                    new OpenApiInteger(3),
                                },
                                ["content"] = new OpenApiArray()
                                {
                                    new OpenApiObject()
                                    {
                                        ["type"] = new OpenApiString("Group"),
                                        ["gap"] = new OpenApiInteger(1),
                                        ["name"] = new OpenApiString("Group1"),
                                        ["label"] = new OpenApiObject()
                                        {
                                            ["text"] = new OpenApiString("Example Group 1"),

                                        }
                                        ["direction"] = new OpenApiString("column"),
                                        ["content"] = new OpenApiArray()
                                        {
                                            new OpenApiObject()
                                            {
                                                ["type"] = new OpenApiString("Property"),
                                                ["ref"] = new OpenApiString("name")
                                            },
                                            new OpenApiObject()
                                            {
                                                ["type"] = new OpenApiString("Property"),
                                                ["ref"] = new OpenApiString("description")
                                            }
                                        }
                                    },
                                    new OpenApiObject()
                                    {
                                        ["type"] = new OpenApiString("Group"),
                                        ["gap"] = new OpenApiInteger(1),
                                        ["name"] = new OpenApiString("Group2"),
                                        ["label"] = new OpenApiObject()
                                        {
                                            ["text"] = new OpenApiString("Example Group 2"),

                                        }
                                        ["direction"] = new OpenApiString("column"),
                                        ["content"] = new OpenApiArray()
                                        {
                                            new OpenApiObject()
                                            {
                                                ["type"] = new OpenApiString("Property"),
                                                ["ref"] = new OpenApiString("signalSource")
                                            },
                                            new OpenApiObject()
                                            {
                                                ["type"] = new OpenApiString("Property"),
                                                ["ref"] = new OpenApiString("dataType")
                                            },
                                            new OpenApiObject()
                                            {
                                                ["type"] = new OpenApiString("Group"),
                                                ["gap"] = new OpenApiInteger(1),
                                                ["name"] = new OpenApiString("subgroup1"),
                                                ["direction"] = new OpenApiString("row"),
                                                ["label"] = new OpenApiObject()
                                                {
                                                    ["text"] = new OpenApiString("Subgroup")
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            }
                    },
                    ["properties"] = new OpenApiObject()
                    {
                        ["id"] = new OpenApiObject()
                        {
                            ["type"] = new OpenApiString("Text"),
                            ["hasCallback"] = new OpenApiBoolean(false)
                        },
                        ["name"] = new OpenApiObject()
                        {
                            ["type"] = new OpenApiString("Text"),
                            ["hasCallback"] = new OpenApiBoolean(false)
                        }
                    }
                };

            }
        }
    }
}

