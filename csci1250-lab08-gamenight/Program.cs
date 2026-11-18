// Look for the data files next to the Program.cs, however the program is started.
using System.Drawing;
using System.Runtime.CompilerServices;

string projectFolder = Path.GetFullPath(
    Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
Directory.SetCurrentDirectory(projectFolder);

const string PLAYERS_FILE = "players.txt";
const string POINTS_FILE = "points.txt";
const string HISTORY_FILE = "history.txt";
const int MAX_POINTS = 20;

//**** PART 1 ****
string[] players = File.ReadAllLines(PLAYERS_FILE);
string[] points = File.ReadAllLines(POINTS_FILE);
int leader = LeaderIndex(points);
int total = TotalPoints(points);

System.Console.WriteLine("PLAYERS".PadRight(11) + "POINTS");
for (int i = 0; i < players.Length; i++)
{
    System.Console.WriteLine($"{players[i].PadRight(11)}{points[i]}");
}

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

static int TotalPoints(string[] points)
{
    int a = Convert.ToInt32(points[0]);
    int b = Convert.ToInt32(points[1]);
    int c = Convert.ToInt32(points[2]);
    int d = Convert.ToInt32(points[3]);

    return a + b + c + d; 
}

// static string HistoryEntry(int night, string winner, int points)
// {
    
// }