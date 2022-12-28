/*
 * MoonlightPGR
 * PGR Private Server
 * Copyright (c) 2022
 */

using MoonlightPGR.Server;
using MoonlightPGR.Util;
namespace MoonlightPGR;

public static class CrepeBH
{
    public static void Main()
    {
        Logger.c.Log("Starting MoonlightPGR...");

        var server = new TcpServer("127.0.0.1", 7000);
    }
}