using Microsoft.Extensions.Logging;

namespace Net6ConsoleDemo
{
    public class ConsoleApplication
    {
        private readonly ILogger<ConsoleApplication> logger;

        public ConsoleApplication(ILogger<ConsoleApplication> logger)
        {
            this.logger = logger;
        }
        public Task RunAsync()
        {
            logger.LogInformation("Hello World!");
            return Task.CompletedTask;
        }
    }
}