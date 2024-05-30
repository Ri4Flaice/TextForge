using System.Reflection;

namespace TextForge.Core;

/// <summary>
/// Write errors in file logs.
/// </summary>
public class Logs : Exception
{
    private readonly Exception? _exception;
    private readonly string _errorNumber;
    private readonly string _message;

    /// <summary>
    /// Initializes a new instance of the class <see cref="Logs"/>.
    /// </summary>
    /// <param name="exception">Exception.</param>
    /// <param name="errorNumber">Error number.</param>
    /// <param name="message">Error message.</param>
    public Logs(Exception exception, string errorNumber, string message)
    {
        _exception = exception;
        _errorNumber = errorNumber;
        _message = message;
    }

    /// <summary>
    /// Initializes a new instance of the class <see cref="Logs"/>.
    /// </summary>
    /// <param name="errorNumber">Error number.</param>
    /// <param name="message">Error message.</param>
    public Logs(string errorNumber, string message)
    {
        _errorNumber = errorNumber;
        _message = message;
    }

    /// <summary>
    /// Write error in file logs.
    /// </summary>
    public void WriteErrorInLogs()
    {
        var assembly = Assembly.GetExecutingAssembly();
        var outputPath = Path.GetDirectoryName(assembly.Location);

        if (outputPath == null) return;

        var logsPath = Path.Combine(outputPath, "logs.txt");

        using var writer = new StreamWriter(logsPath, true);
        writer.WriteLine($"{DateTime.Now}: Error {_errorNumber}: {_message}");
        writer.WriteLine($"Stack Trace: {_exception?.StackTrace}");
        writer.WriteLine();
    }
}