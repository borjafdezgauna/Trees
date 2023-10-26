using Common;
using System;

class MainClass
{
    public static void Main(string[] args)
    {
        StatsUpdater statsUpdater = new StatsUpdater();
        statsUpdater.CheckGitUsername();

        if (statsUpdater.GitUsername == null)
        {
            Console.WriteLine("Error getting Git info. You need to add this project to Git (fork from my repo and then clone your fork)");
            return;
        }

        bool success = Tests.TestBinaryTree();
        if (!success)
            return;

        SpeedMeasure speedMeasure = Tests.MeasureSpeed();
        if (!speedMeasure.Success)
        {
            Console.WriteLine("An error was detected during the speed measurement. Probably something wrong with Add/Get");
            return;
        }

        success = statsUpdater.AddResult(speedMeasure);
        if (success)
            Console.WriteLine("Your time was saved on the server");
        else
            Console.WriteLine("Something failed saving your time on the server");
    }
}