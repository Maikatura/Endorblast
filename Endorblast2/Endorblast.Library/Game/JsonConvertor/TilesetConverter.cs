// using System;
// using Endorblast.Lib.TileMap;
// using Microsoft.Xna.Framework;
// using Newtonsoft.Json;
// using Newtonsoft.Json.Linq;
//
// namespace Endorblast.DB.Lib.Game.JsonConvertor
// {
//     public class TilesetConverter : JsonConverter<TileData>
//     {
//         public override void WriteJson(JsonWriter writer, TileData value, JsonSerializer serializer)
//         {
//             writer.WriteValue(
//                 $"{value.rect.X} {value.rect.Y} {value.rect.Width} {value.rect.Height} {value.N} {value.E} {value.S} {value.W}");
//         }
//
//         public override TileData ReadJson(JsonReader reader, Type objectType, TileData existingValue,
//             bool hasExistingValue,
//             JsonSerializer serializer)
//         {
//             if (reader.TokenType == JsonToken.StartObject)
//             {
//                 return ReadOldTileData(reader);
//             }
//             else if (reader.TokenType == JsonToken.String)
//             {
//                 return ReadNewTileData(reader);
//                 ;
//             }
//
//             throw new Exception($"RectangleJsonConverter: Invalid token: {reader.TokenType}");
//         }
//
//         private TileData ReadNewTileData(JsonReader reader)
//         {
//             string[] components = reader.Value.ToString().Split(' ');
//             if (components.Length != 8)
//             {
//                 throw new Exception($"RectangleJsonConverter: Not all rectangle components were found ({reader.Path})");
//             }
//
//             if (!int.TryParse(components[0], out int x) ||
//                 !int.TryParse(components[1], out int y) ||
//                 !int.TryParse(components[2], out int width) ||
//                 !int.TryParse(components[3], out int height) ||
//                 !bool.TryParse(components[4], out bool north) ||
//                 !bool.TryParse(components[5], out bool east) ||
//                 !bool.TryParse(components[6], out bool south) ||
//                 !bool.TryParse(components[7], out bool west))
//             {
//                 throw new Exception(
//                     $"RectangleJsonConverter: Not all rectangle components were numeric ({reader.Path})");
//             }
//
//             var tileData = new TileData();
//
//             tileData.rect = new Rectangle(x, y, width, height);
//             tileData.S = south;
//             tileData.N = north;
//             tileData.E = east;
//             tileData.W = west;
//
//             return tileData;
//         }
//
//         private TileData ReadOldTileData(JsonReader reader)
//         {
//             JObject jsonObject = JObject.Load(reader);
//
//             if (!jsonObject.TryGetValue("X", out JToken xToken) ||
//                 !jsonObject.TryGetValue("Y", out JToken yToken) ||
//                 !jsonObject.TryGetValue("Width", out JToken widthToken) ||
//                 !jsonObject.TryGetValue("Height", out JToken heightToken))
//             {
//                 throw new Exception($"RectangleJsonConverter: Not all rectangle components were found ({reader.Path})");
//             }
//
//             if (!int.TryParse(xToken.ToString(), out int x) ||
//                 !int.TryParse(yToken.ToString(), out int y) ||
//                 !int.TryParse(widthToken.ToString(), out int width) ||
//                 !int.TryParse(heightToken.ToString(), out int height))
//             {
//                 throw new Exception(
//                     $"RectangleJsonConverter: Not all rectangle components were numeric ({reader.Path})");
//             }
//
//             if (!jsonObject.TryGetValue("N", out JToken north) ||
//                 !jsonObject.TryGetValue("E", out JToken east) ||
//                 !jsonObject.TryGetValue("S", out JToken south) ||
//                 !jsonObject.TryGetValue("W", out JToken west))
//             {
//                 throw new Exception($"RectangleJsonConverter: Not all rectangle components were found ({reader.Path})");
//             }
//
//             if (!bool.TryParse(north.ToString(), out bool northBool) ||
//                 !bool.TryParse(east.ToString(), out bool eastBool) ||
//                 !bool.TryParse(south.ToString(), out bool southBool) ||
//                 !bool.TryParse(west.ToString(), out bool westBool))
//             {
//                 throw new Exception(
//                     $"RectangleJsonConverter: Not all rectangle components were numeric ({reader.Path})");
//             }
//
//             var tileData = new TileData();
//
//             tileData.rect = new Rectangle(x, y, width, height);
//
//
//             return tileData;
//         }
//     }
// }