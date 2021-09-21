using Newtonsoft.Json;
using PeerislandsTest.Contracts;
using PeerislandsTest.Modules;
using System.IO;

namespace PeerislandsTest
{
    public class JsonFileReadService: IFileReaderService
    {
        /// <summary>
        /// This method read json file from inputdata directory and return jsondata object
        /// </summary>
        /// <returns></returns>
        public JsonData ReadFile()
        {
            var folderDetails = Path.Combine(Directory.GetCurrentDirectory(), $"{"InputData\\inputfile.json"}");
            var json = System.IO.File.ReadAllText(folderDetails);
            var jsondata = JsonConvert.DeserializeObject<JsonData>(json);
            return jsondata;
        }
    }
}
