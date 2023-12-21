using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using Daedalus_Orbis.GameConcepts;
using System.Globalization;

namespace Daedalus_Orbis.GameConcepts
{
   public class BuildingTypeConverter : JsonConverter<BuildingType>
   {
        public override BuildingType? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            BuildingType building = new BuildingType();
            while(reader.Read())
            {
                switch (reader.TokenType)
                {
                    case JsonTokenType.PropertyName:
                        switch (reader.GetString())
                        {
                            case "Name":
                                reader.Read();
                                building.Name = reader.GetString();
                                break;
                            case "Description":
                                reader.Read();
                                building.Description = reader.GetString();
                                break;
                            case "HoldingType":
                                reader.Read();
                                building.HoldingType = reader.GetString();
                                break;
                            case "Coastal":
                                reader.Read();
                                building.Coastal = reader.GetBoolean();
                                break;
                            case "RiverSide":
                                reader.Read();
                                building.RiverSide = reader.GetBoolean();
                                break;
                            case "MaaRegiments":
                                reader.Read();
                                building.MaaRegiments = reader.GetInt32();
                                break;
                            default:
                                string key = reader.GetString();
                                reader.Read();
                                double value = reader.GetDouble();
                                Modifier modifier = new Modifier(key, value);
                                break;
                        }
                        break;
                }
            }
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, BuildingType value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
