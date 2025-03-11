using System.Diagnostics;
using Spectre.Console;

namespace Flashcards
{
    public class LocalDBInstance
    {
        public static void CreateLocalDBInstance(string instanceName)
        {
            // Create a new process to run the sqllocaldb command
            Process process = new Process();
            process.StartInfo.FileName = "sqllocaldb";
            process.StartInfo.Arguments = $"create {instanceName}";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;

            process.Start();
            process.WaitForExit();

            // Check the output and error streams for any issues
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            if (!string.IsNullOrEmpty(error))
            {
                // Handle any errors that occurred during instance creation
                AnsiConsole.WriteLine($"Error creating LocalDB instance: {error}");
            }
            else
            {
                // LocalDB instance created successfully
                AnsiConsole.WriteLine($"LocalDB instance '{instanceName}' created successfully.");
            }
        }

        public static void StopLocalDBInstance(string instanceName)
        {
            // Create a new process to run the sqllocaldb command
            Process process = new Process();
            process.StartInfo.FileName = "sqllocaldb";
            process.StartInfo.Arguments = $"stop {instanceName}";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;

            // Start the process and wait for it to exit
            process.Start();
            process.WaitForExit();

            // Check the output and error streams for any issues
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            if (!string.IsNullOrEmpty(error))
            {
                // Handle any errors that occurred during instance stopping
                Console.WriteLine($"Error stopping LocalDB instance: {error}");
            }
            else
            {
                // LocalDB instance stopped successfully
                Console.WriteLine($"LocalDB instance '{instanceName}' stopped successfully.");
            }
        }
    }
}