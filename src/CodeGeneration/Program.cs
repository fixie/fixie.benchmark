using System;

namespace CodeGeneration
{
    using System.IO;
    using System.Text;

    class Program
    {
        const int Folders = 10;
        const int TestClassesPerFolder = 50;
        const int TestsPerClass = 50;
        const string RootFolder = "C:\\dev\\fixie.benchmark\\src\\Shared\\";
        
        static void Main(string[] args)
        {
            for (int folder = 1; folder <= Folders; folder++)
            for (int testClass = 1; testClass <= TestClassesPerFolder; testClass++)
                GeneratedClass(folder, testClass);

            Console.WriteLine("Wrote to " + RootFolder);
            Console.ReadLine();
        }

        static void GeneratedClass(int folder, int testClass)
        {
            var folderName = $"Group_{folder:000}";
            var className = $"Benchmark{testClass:000}Tests";

            var content = new StringBuilder();
            content.AppendLine($"namespace Shared.{folderName}");
            content.AppendLine("{");
            content.AppendLine("    using Xunit;");
            content.AppendLine();
            content.AppendLine($"    public class {className}");
            content.AppendLine("    {");
            for (int test = 1; test <= TestsPerClass; test++)
            {
                content.AppendLine($"        [Fact] public void Test_{test:000}() {{ }}");
            }
            content.AppendLine("    }");
            content.AppendLine("}");

            var folderPath = Path.Combine(RootFolder, folderName);
            Directory.CreateDirectory(folderPath);

            var filePath = Path.Combine(folderPath, $"{className}.cs");
            File.WriteAllText(filePath, content.ToString());
        }
    }
}
