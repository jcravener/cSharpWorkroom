using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using YamlDotNet.Serialization;
using Newtonsoft.Json;
using System.Dynamic;

namespace ParseYaml
{
    class Convert
    {
        public static String ToJson(StringReader Reader)
        {
            var deserializer = new DeserializerBuilder().Build();
            var yamlObject = deserializer.Deserialize(Reader);

            var serializer = new SerializerBuilder()
                .JsonCompatible()
                .Build();

            String json = serializer.Serialize(yamlObject);

            return json;
        }

        public static String toYaml(String Txt)
        {
            dynamic obj = JsonConvert.DeserializeObject<ExpandoObject>(Txt);

            var serializer = new SerializerBuilder().Build();
            var yaml = serializer.Serialize(obj);

            return yaml;
        }
    }
}
