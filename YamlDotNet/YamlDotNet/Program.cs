using System.IO;
using System;
using YamlDotNet.Serialization;

namespace YamlDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length.Equals(0))
            {
                Console.Error.WriteLine($"usage: {System.AppDomain.CurrentDomain.FriendlyName} /path/to/yaml/file");
                Environment.Exit(1);
            }
            
            
            String txt  = File.ReadAllText(@$"{args[0]}");
            var r = new StringReader(txt);

//            var r = new StringReader(@"
//scalar: a scalar
//sequence:
//    - one
//    - two
//");
            var deserializer = new Deserializer();
            var yamlObject = deserializer.Deserialize(r);

            //var serializer = new Serializer(SerializationOptions.JsonCompatible);
            var serializer = new SerializerBuilder().JsonCompatible().Build();
            //serializer.Serialize(Console.Out, yamlObject);
            serializer.Serialize(Console.Out, yamlObject);
        }
    }
}
