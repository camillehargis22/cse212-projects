/*
 * CSE 212 Lesson 6C 
 * 
 * This code will analyze the NBA basketball data and create a table showing
 * the players with the top 10 career points.
 * 
 * Note about columns:
 * - Player ID is in column 0
 * - Points is in column 8
 * 
 * Each row represents the player's stats for a single season with a single team.
 */

using Microsoft.VisualBasic.FileIO;

public class Basketball
{
    public static void Run()
    {
        var players = new Dictionary<string, int>();

        using var reader = new TextFieldParser("basketball.csv");
        reader.TextFieldType = FieldType.Delimited;
        reader.SetDelimiters(",");
        reader.ReadFields(); // ignore header row
        while (!reader.EndOfData)
        {
            var fields = reader.ReadFields()!;
            var playerId = fields[0];
            var points = int.Parse(fields[8]);

            // if player already exists in players, add their points
            if (players.ContainsKey(playerId))
            {
                players[playerId] += points;
            }
            // otherwise, add player to players
            else
            {
                players.Add(playerId, points);
                // could also add like:
                // players[playerId] = points;
            }
        }

        // this prints the whole players list with total points
        // Console.WriteLine($"Players: {{{string.Join(", ", players)}}}");

        // convert players to an array
        // var topPlayers = new string[10];
        var topPlayers = players.ToArray();

        // sort the array with the highest point values in the front
        Array.Sort(topPlayers, (p1, p2) => p2.Value - p1.Value);

        // display the top 10 players with the highest point total
        Console.WriteLine();

        for (var i = 0; i < 10; i++)
        {
            Console.WriteLine(topPlayers[i]);
        }
    }
}