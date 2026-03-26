using MDD4All.EMOF.DataModels;
using MDD4All.EMOF.DotNetToEmofConverter;
using Newtonsoft.Json;
using System;
using System.IO;

namespace MDD4All.QVT.Transformations.Apps.EmofConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DotNetToEmofConverter dotNetToEmofConverter = new DotNetToEmofConverter();

            Type? rootElementType = null;

            // initialize the root element type e.g. with rootElementType = typeof(PersonRepository);
            // PUT YOUR CODE HERE resp. set your type here
            rootElementType = typeof(EmofRepository);

            if (rootElementType != null)
            {

                EmofRepository emofRepository = dotNetToEmofConverter.ConvertToEMOF(rootElementType);

                JsonSerializerSettings serializerSettings = new JsonSerializerSettings();

                string json = JsonConvert.SerializeObject(emofRepository,
                                                          Formatting.Indented,
                                                          new JsonSerializerSettings()
                                                          {
                                                              NullValueHandling = NullValueHandling.Ignore,
                                                              TypeNameHandling = TypeNameHandling.Auto
                                                          });

                string? filename = rootElementType.FullName;

                File.WriteAllText("..\\..\\..\\" + filename + ".emof.json", json);
            }
            else
            {
                Console.WriteLine("Unable to create EMOF. No type given. Please specify your type to convert in the code!");
            }
        }
    }
}
