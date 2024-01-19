using System;
using System.Collections.Generic;

class TestTask
{
    static void Main()
    {
        List<string> results = new List<string> { "3:1", "2:2", "0:1", "4:2", "3:a", "3- 12" };
        Dictionary<int, int> teamPoints = CalculatePoints(results);

        foreach (var abc in teamPoints)
        {
            Console.WriteLine($"Команда №{abc.Key}: {abc.Value} очков");
        }
    }

    static Dictionary<int, int> CalculatePoints(List<string> results)
    {
        Dictionary<int, int> teamPoints = new Dictionary<int, int>();

        foreach (var result in results)
        {
            string[] parts = result.Split(':');

            if (parts.Length == 2 && int.TryParse(parts[0], out int homeGoals) && int.TryParse(parts[1], out int awayGoals)) 
            {
                if (homeGoals > awayGoals)
                {
                    UpdatePoints(teamPoints, 1, 3);
                }
                else if (homeGoals < awayGoals)
                {
                    UpdatePoints(teamPoints, 2, 3);
                }
                else
                {
                    UpdatePoints(teamPoints, 1, 1);
                    UpdatePoints(teamPoints, 2, 1);

                }
            }
        }
        return teamPoints;
    }

    static void UpdatePoints(Dictionary<int, int> teamPoints, int teamNumber, int points)
    {
        if (teamPoints.ContainsKey(teamNumber))
        {
            teamPoints[teamNumber] += points;
        }
        else
        {
            teamPoints.Add(teamNumber, points);
        }
    }
}