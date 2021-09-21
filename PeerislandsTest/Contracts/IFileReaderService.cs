using PeerislandsTest.Modules;

namespace PeerislandsTest.Contracts
{
    public interface IFileReaderService
    {
        /// <summary>
        /// This method read json file from inputdata directory and return jsondata object
        /// </summary>
        /// <returns></returns>
        JsonData ReadFile();
    }
}
