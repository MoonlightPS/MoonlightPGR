using System.Diagnostics;

namespace MoonlightPGR.Util;

public class Logger
{
    public static Logger c = new("MoonlightPGR", ConsoleColor.Blue);
    private string _name;
    private ConsoleColor _nameColor;

    public Logger(string name, ConsoleColor nameColor = ConsoleColor.Gray)
    {
        _name = name;
        _nameColor = nameColor;
    }

    public void Log(params string[] msg)
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        var time = DateTime.Now.ToString("[HH:mm:ss]");
        Console.Write($"{time} ");
        Console.Write('<');
        Console.ForegroundColor = _nameColor;
        Console.Write(_name);
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write("> ");
        Console.ResetColor();
        Console.Write(string.Join('\t', msg));
        Console.Write('\n');
    }

    public void Warn(params string[] msg)
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        var time = DateTime.Now.ToString("[HH:mm:ss]");
        Console.Write($"{time} ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.Write($"WARN<{_name}>");
        Console.ResetColor();
        Console.Write(' ');
        Console.Write(string.Join('\t', msg));
        Console.Write('\n');
    }

    public void Trail(params string[] msg)
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine($"\t→ {string.Join(' ', msg)}");
        Console.ResetColor();
    }

    public void Error(string msg, bool stack = true)
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        var time = DateTime.Now.ToString("[HH:mm:ss]");
        Console.Write($"{time} ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.DarkRed;
        Console.Write($"ERROR<{_name}>");
        Console.ResetColor();
        Console.WriteLine($" {msg}");
        if (stack)
        {
            StackTrace trace = new(true);
            Trail(trace.ToString());
        }
    }

    public void Debug(params string[] msg)
    {
#if DEBUG
        Console.ForegroundColor = ConsoleColor.Gray;
        var time = DateTime.Now.ToString("[HH:mm:ss]");
        Console.Write($"{time} ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.Write($"DEBUG<{_name}>");
        Console.ResetColor();
        Console.Write(' ');
        Console.Write(string.Join('\t', msg));
        Console.Write('\n');
#endif
    }
}