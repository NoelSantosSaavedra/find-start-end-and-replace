namespace find_start_end_and_replace
{
    using System;
    using System.Configuration;
    using System.IO;
    class Program
    {
        private static string path = ConfigurationManager.AppSettings["file-path"];
        private static string start = ConfigurationManager.AppSettings["start"];
        private static string end = ConfigurationManager.AppSettings["end"];
        private static string newValue = ConfigurationManager.AppSettings["new-value"];

        static void Main(string[] args)
        {
            var readText = File.ReadAllText(path);
            string newText = GetNewText(readText);
            File.WriteAllText(path, newText);
        }

        private static string GetNewText(string readText)
        {
            var startIndex = readText.IndexOf(start);
            var endLength = end == null ? 0 : end.Length;
            var endIndex = readText.IndexOf(end) + endLength - 1;
            var elementsUntilLastIndex = endIndex - startIndex + 1;
            var unnecesarySubstring = readText.Substring(startIndex, elementsUntilLastIndex);
            return readText.Replace(unnecesarySubstring, newValue);
        }
    }
}
