using System;
using System.Transactions;

//this code is not OCP compliant, modify it to be compliant.
public class LoggingService
{
    private ILog _log;
    
    public LoggingService(ILog log) 
    {
        _log = log;
    }

    public void Log(string masseage)
    {
        _log.Log(masseage);
    }

}


public interface ILog
{
    public void Log(string message);
}

public class FileLoggingService: ILog
{
    // Method to log to file
    public void Log(string message)
    {
        Console.WriteLine($"\nLog to file: {message}");
    }
}

public class EventLogService : ILog
{
    // Method to log to EventLog
    public void Log(string message)
    {
        Console.WriteLine($"\nLog to Event Log: {message}");
    }
}

public class DatabaseLoggingService : ILog
{

    // Method to log to file
    public void Log(string message)
    {
        Console.WriteLine($"\nLog to Database: {message}");
    }
}

public class PcLoggingService : ILog
{
    // Method to log to Pc
    public void Log(string message)
    {
        Console.WriteLine($"\nLog to Pc: {message}");
    }
}


public class Program
{
    public static void Main()
    {
        // Create an instance of the LoggingService
        LoggingService LoggingService = new LoggingService( new FileLoggingService());

        // Log to File
        LoggingService.Log("Error Occured line xxx.");

        LoggingService = new LoggingService( new EventLogService());

        // Log to Event Log
        LoggingService.Log("Error Occured line xxx.");

        LoggingService = new LoggingService(new DatabaseLoggingService());

        // Log to Database
        LoggingService.Log("Error Occured line xxx.");

        LoggingService = new LoggingService(new PcLoggingService());

        // Log to Pc
        LoggingService.Log("Error Occured line xxx.");


        Console.ReadKey();

    }
}
