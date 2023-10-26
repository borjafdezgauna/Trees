using Common;
using System;

class MainClass
{
    public static void Main (string[] args)
    {
        StatsUpdater statsUpdater = new StatsUpdater();
        statsUpdater.CheckGitUsername();

        if (statsUpdater.GitUsername == null)
        {
            Console.WriteLine("Error getting Git info. You need to add this project to Git (fork from my repo and then clone your fork)");
            return;
        }

        bool success = Tests.TestGenericTree();

        if (!success)
            return;

        success = statsUpdater.AddResult(null);
    }
}