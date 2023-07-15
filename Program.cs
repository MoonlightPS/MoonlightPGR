/*
 * MoonlightPGR
 * PGR Private Server
 * Copyright (c) 2022
 */

using MoonlightPGR.Server;
using MoonlightPGR.Util;
namespace MoonlightPGR;

public static class MoonlightPGR
{
    public static void Main()
    {
        Logger.c.Log("Starting MoonlightPGR...");
        new TcpServer("127.0.0.1", 2333);
        Dispatch.DispatchServer.Start();
    }
}