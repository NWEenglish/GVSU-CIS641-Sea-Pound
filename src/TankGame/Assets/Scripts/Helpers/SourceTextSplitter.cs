using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Helpers
{
    public static class SourceTextSplitter
    {
        public static IEnumerable<string> Split(string input)
        {
            var text = input.Replace("\r", string.Empty);
            return text.Split('\n').ToList();
        }
    }
}
