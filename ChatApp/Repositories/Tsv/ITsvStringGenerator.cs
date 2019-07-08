using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatApp.Repositories.Tsv
{
    public interface ITsvStringGenerator
    {
        Task<string> Generate(IEnumerable<object> enumerable);
    }
}