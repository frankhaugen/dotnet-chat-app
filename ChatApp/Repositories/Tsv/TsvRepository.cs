using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Repositories.Tsv
{
    public class TsvRepository : ITsvRepository
    {
        private readonly ITsvStringGenerator _tsvStringGenerator;

        public TsvRepository(ITsvStringGenerator csvConstructor)
        {
            _tsvStringGenerator = csvConstructor;
        }

        public async Task WriteTsvToFile(IEnumerable<object> enumerable, string outputPath)
        {
            var csv = await _tsvStringGenerator.Generate(enumerable);

            File.WriteAllText(outputPath, csv, Encoding.UTF8);
        }

        public async Task<List<string>> GetTsvLines(string path)
        {
            return File.ReadAllLines(path).ToList();
        }
    }
}
