using System.Threading.Tasks;

namespace Fixie.Tests;

class TestProject : ITestProject
{
    public void Configure(TestConfiguration configuration, TestEnvironment environment)
    {
        configuration.Conventions.Add<DefaultDiscovery, ParallelExecution>();
    }

    class ParallelExecution : IExecution
    {
        public async Task Run(TestSuite testSuite)
        {
            await Parallel.ForEachAsync(testSuite.Tests, async (test, _) => await test.Run());
        }
    }
}