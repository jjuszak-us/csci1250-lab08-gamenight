/*
* Name: Joseph Juszak
* Course: CSCI 1250, Section 001
* Assignment: Lab 08, Game Night
* Date: November 18, 2026
* Description: Keeps a game night leaderboard in three text files. Shows the
* season so far, records tonight's points, saves the new totals,
* and adds tonight's result to a history that grows every week.
*/

// Look for the data files next to the Program.cs, however the program is started.
string projectFolder = Path.GetFullPath(
    Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
Directory.SetCurrentDirectory(projectFolder);

const string PLAYERS_FILE = "players.txt";
const string POINTS_FILE = "points.txt";
const string HISTORY_FILE = "history.txt";
const int MAX_POINTS = 20;

//keeps track of nights for insertion to cw
string[] nightCount = File.ReadAllLines(HISTORY_FILE);
int night = nightCount.Length;

string[] lines = File.ReadAllLines(HISTORY_FILE);
//Start of leaderboard print out
System.Console.WriteLine("=== GAME NIGHT LEADERBOARD ===");
// using an if else loop so it checks the condition first
if(night < 1)
{
    System.Console.WriteLine("No nights played yet.");
}
else
{
    System.Console.WriteLine($"Nights played: {night}");
    //pulls all files from the history.txt file. using foreach so it pulls all and prints all
    foreach(string line in lines)
    {
        System.Console.WriteLine($"{line.PadLeft(line.Length + 2)}");
    }
}    
System.Console.WriteLine($"Tonight is Night {night + 1}\n");

//**** PART 1 ****
string[] players = File.ReadAllLines(PLAYERS_FILE);
string[] points = File.ReadAllLines(POINTS_FILE);
int leader = LeaderIndex(points);
int total = TotalPoints(points);

System.Console.WriteLine("PLAYERS".PadRight(11) + "POINTS");
//using a for loop so it cycles through both files in order and pairs the points with the names
for (int i = 0; i < players.Length; i++)
{
    System.Console.WriteLine($"{players[i].PadRight(11)}{points[i]}");
}
//using a for loop so it cycles through both files in order and pairs the points with the names
for (int i = 0; i < players.Length; i++)
{
    int point = Convert.ToInt32(points[i]);
    string player = players[i];

    if(leader == point)
    {
        System.Console.WriteLine($"Leader: {player} with {leader} ");
    }
}
System.Console.WriteLine($"Season total: {total}");

//**** PART 2 ****
int winningPointstongiht = 0;
string winner = " ";
//using a for loop so the program assigns points to a specific name
for (int i = 0; i < players.Length; i++)
{
    System.Console.WriteLine($"{players[i]}. How many points did you score tonight? ");
    int tonightsPoints = Convert.ToInt32(Console.ReadLine());
    //using if statements to make sure the value entered is within 0 and 20
    if(tonightsPoints > MAX_POINTS || tonightsPoints < 0)
    {
        System.Console.WriteLine("Points must be from 0 to 20");
        System.Console.WriteLine($"{players[i]}. How many points did you score tonight? ");
        tonightsPoints = Convert.ToInt32(Console.ReadLine());
        int season = Convert.ToInt32(points[i]) + tonightsPoints;
        points[i] = season.ToString();
       
    }
    else
    {
        int season = Convert.ToInt32(points[i]) + tonightsPoints;
        points[i] = season.ToString(); 
    }

    if(tonightsPoints > winningPointstongiht)
    {
        winningPointstongiht = tonightsPoints;
        winner = players[i];
    }
}
File.WriteAllLines(POINTS_FILE, points);
System.Console.WriteLine($"Tonight's winner: {winner} with {winningPointstongiht}");

//**** PART 3 *****
string[] entry = {HistoryEntry(night, winner, winningPointstongiht)};

File.AppendAllLines(HISTORY_FILE, entry);

System.Console.WriteLine("Saved points.txt");
System.Console.WriteLine($"Added to history.txt: {entry[0]}");


//Finds the leader for each night
static int LeaderIndex(string[] points)
{
    int a = Convert.ToInt32(points[0]);
    int b = Convert.ToInt32(points[1]);
    int c = Convert.ToInt32(points[2]);
    int d = Convert.ToInt32(points[3]);
    int leader = a;
    
    if(b > leader)
    {
        leader = b;
    }
    if(c > leader)
    {
        leader = c;
    }
    if(d > leader)
    {
        leader = d;
    }
    return leader;
}
//Computes the total points for each night
static int TotalPoints(string[] points)
{
    int a = Convert.ToInt32(points[0]);
    int b = Convert.ToInt32(points[1]);
    int c = Convert.ToInt32(points[2]);
    int d = Convert.ToInt32(points[3]);

    return a + b + c + d; 
}

//The statement entered into the history file. 
static string HistoryEntry(int night, string winner, int points)
{
    return $"Night {night +1}: {winner} won with {points} points.";
}