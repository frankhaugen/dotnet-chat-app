using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ChatApp.Repositories.Tsv
{
    public class TsvStringGenerator : ITsvStringGenerator
    {
        private List<string> tsv = new List<string>();

        public async Task<string> Generate(IEnumerable<object> enumerable)
        {
            var type = enumerable.FirstOrDefault().GetType();

            tsv.Add(string.Join("\t", type.GetProperties().Select(pi => pi.Name).ToArray()));
            GetRows(enumerable);
            
            return string.Join("\n", tsv);
        }

        private void GetRows(IEnumerable<object> enumerable)
        {
            foreach (var obj in enumerable)
            {
                var row = new List<string>();

                var properties = obj.GetType().GetProperties().Select(prop => prop.Name).ToList();

                foreach (var property in properties)
                {
                    if (obj.GetType().GetProperty(property).GetValue(obj, null) == null)
                    {
                        row.Add("");
                    }
                    else
                    {
                        var cell = obj.GetType().GetProperty(property).GetValue(obj, null).ToString();

                        cell = HttpUtility.HtmlDecode(cell);

                        row.Add(cell);
                    }
                }

                tsv.Add(string.Join("\t", row.ToArray()));
            }
        }
    }
}
