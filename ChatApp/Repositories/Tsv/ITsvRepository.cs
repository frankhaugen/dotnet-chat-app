using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatApp.Repositories.Tsv
{
    public interface ITsvRepository
    {
        Task WriteTsvToFile(IEnumerable<object> enumerable, string outputPath);
        Task<List<string>> GetTsvLines(string path);
    }
}