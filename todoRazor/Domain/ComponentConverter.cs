using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace todoRazor;

public class ComponentConverter : JsonConverter
{
    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        JObject jsonObject = JObject.Load(reader);
        var componentType = jsonObject["component"].Value<string>();
        BaseComponent component = null;

        switch (componentType)
        {
            case "null":
                component = null;
                break;
            default:
                return null;
        }

        if (component != null)
        {
            serializer.Populate(jsonObject.CreateReader(), component);
        }

        return component;
    }
    public override bool CanConvert(Type objectType)
    {
        throw new NotImplementedException();
    }
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}

