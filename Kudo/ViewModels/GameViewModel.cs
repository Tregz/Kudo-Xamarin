using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Kudo
{
    public class GameViewModel : BaseViewModel
    {
        public Game Game { get; set; }
        public int HiddenCount { get; set; }
        private readonly int[] digits = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        private List<int[,]> Incomplete { get; set; }
        private List<int[,]> Soluce { get; set; }
        private Boolean Debug { get; set; }
        public Command LoadGameCommand { get; set; }

        public GameViewModel()
        {
            Title = "Game";
            LoadGameCommand = new Command(async () => await ExecuteLoadGameCommand());
        }

        async Task ExecuteLoadGameCommand()
        {
            if (IsBusy) return;

            IsBusy = true;

            try
            {
                String id = Preferences.Get("game", "0");
                Game = await DataStore.GetItemAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        // Sudoku grid: 81 numbers, 9x9
        public List<int[,]> Sudoku
        {
            get
            {
                Debug = false;
                Soluce = new List<int[,]>();
                Random random = new Random();
                int again = 0;
                int stuck = 0;
                int fails = 0;
                for (int i = 0; i < 9; i++)
                {
                    if (Debug) Console.WriteLine("Create grid " + i);
                    Boolean cancel = false;
                    Boolean completed3x3 = false;
                    int failures = 0;
                    int[,] g = new int[3, 3];
                    int i3x3 = 0;
                    while (!completed3x3)
                    {
                        HashSet<int> numbers = new HashSet<int>(digits);
                        int iRow = 0;
                        for (int row = 0; row < 3; row++)
                        {
                            Boolean completedRow = false;
                            while (!completedRow)
                            {
                                Boolean validRow = true;
                                for (int col = 0; col < 3; col++)
                                {
                                    // Numbers left t
                                    if (Debug) numbers.Print("Numbers");
                                    List<int> a = new List<int>(numbers);
                                    // Remove unavailable numbers from list a
                                    switch (i)
                                    {
                                        case 8:
                                            a.Remove(Soluce, 5, null, col);
                                            a.Remove(Soluce, 2, null, col);
                                            a.Remove(Soluce, 7, row, null);
                                            a.Remove(Soluce, 6, row, null);
                                            break;
                                        case 7:
                                            a.Remove(Soluce, 4, null, col);
                                            a.Remove(Soluce, 1, null, col);
                                            a.Remove(Soluce, 6, row, null);
                                            break;
                                        case 6:
                                            a.Remove(Soluce, 3, null, col);
                                            a.Remove(Soluce, 0, null, col);
                                            break;
                                        case 5:
                                            a.Remove(Soluce, 2, null, col);
                                            a.Remove(Soluce, 4, row, null);
                                            a.Remove(Soluce, 3, row, null);
                                            break;
                                        case 4:
                                            a.Remove(Soluce, 1, null, col);
                                            a.Remove(Soluce, 3, row, null);
                                            break;
                                        case 3:
                                            a.Remove(Soluce, 0, null, col);
                                            break;
                                        case 2:
                                            a.Remove(Soluce, 1, row, null);
                                            a.Remove(Soluce, 0, row, null);
                                            break;
                                        case 1:
                                            a.Remove(Soluce, 0, row, null);
                                            break;
                                        default:
                                            break;
                                    }
                                    if (Debug) a.Print("Available");
                                    if (a.Count > 0)
                                    {
                                        int value = a[random.Next(a.Count)];
                                        numbers.Remove(value);
                                        g[row, col] = value;

                                        // Check that second row is valid
                                        if (row == 1 && col == 2 && validRow)
                                            if (!IsValidRow(numbers, Soluce, i, row))
                                                validRow = false;

                                        if (col == 2)
                                        {
                                            if (g[row, 0] == 0) validRow = false;
                                            if (g[row, 1] == 0) validRow = false;
                                            if (g[row, 2] == 0) validRow = false;
                                            if (validRow) completedRow = true;
                                            else
                                            {
                                                fails++;
                                                if (iRow++ > 5)
                                                {
                                                    completedRow = true;
                                                    if (row > 0) row--;
                                                    iRow = 0;
                                                    if (failures++ > 3)
                                                    {
                                                        cancel = true;
                                                        completed3x3 = true;
                                                        completedRow = true;
                                                        failures = 0;
                                                    }
                                                }
                                                else if (i == 8)
                                                {
                                                    cancel = true;
                                                    completed3x3 = true;
                                                    completedRow = true;
                                                }
                                                else
                                                {
                                                    // Try again
                                                    numbers.Restore(g, row);
                                                }
                                            }
                                            if (row == 2)
                                            {
                                                if (completedRow)
                                                    completed3x3 = true;
                                                else if (i3x3++ > 10)
                                                    completed3x3 = true;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        fails++;
                                        if (Debug)
                                        {
                                            String error = "Error in grid " + i;
                                            error += " at row " + row + ",";
                                            error += " column " + col + ".";
                                            Console.WriteLine(error);
                                        }
                                        if (col == 2 && row == 2)
                                        {
                                            if (i == 8)
                                            {
                                                cancel = true;
                                                completed3x3 = true;
                                            }
                                            completedRow = true;
                                        }
                                        else if (col == 2)
                                        {
                                            if (iRow++ < 5)
                                            {
                                                // Try again
                                                numbers.Restore(g, row);
                                            }
                                            else
                                            {
                                                iRow = 0;
                                                completedRow = true;
                                            }
                                        }
                                        else if (i > 6 || fails > 100)
                                        {
                                            cancel = true;
                                            completedRow = true;
                                            completed3x3 = true;
                                        }
                                    }
                                }
                            }
                        }                        
                    }
                    if (Debug) for (int row = 0; row < 3; row++)
                        for (int col = 0; col < 3; col++)
                            Console.Write(string.Format("{0} ", g[row, col]));
                        Console.Write(Environment.NewLine + Environment.NewLine);
                    if (cancel && stuck++ < 15)
                    {
                        Soluce.RemoveAt(--i);
                        if (again++ > 5) {
                            Soluce.RemoveAt(--i);
                            again = 0;
                        }
                        --i;
                    }
                    else Soluce.Add(g);
                }
                if (fails < 100) return Soluce;
                else return Sudoku;
            }
        }

        public List<int[,]> Puzzle
        {
            get
            {
                HiddenCount = 0;
                Incomplete = new List<int[,]>();
                foreach (int[,] grid in Soluce)
                    Incomplete.Add(grid.Clone() as int[,]);
                int hiddens = 6;
                if (Game != null) switch (Game.Level)
                {
                    case 0:
                        hiddens = 6;
                        break;
                    case 1:
                        hiddens = 12;
                        break;
                    case 2:
                        hiddens = 18;
                        break;
                }
                for (int i = 0; i < hiddens; i++) HideValue();
                return Incomplete;
            }
        }

        private Boolean IsValidRow(HashSet<int> a, List<int[,]> b, int g, int r)
        {
            // Check that numbers for the next row should be valid
            if (g > 0) for (int i = 0; i < 3; i++)
                {
                    switch (g)
                    {
                        case 1:
                        case 4:
                        case 7:
                            if (a.Contains(b[g - 1][r + 1, i])) return false;
                            break;
                        case 2:
                        case 5:
                        case 8:
                            if (a.Contains(b[g - 1][r + 1, i])) return false;
                            else if (a.Contains(b[g - 2][r + 1, i])) return false;
                            break;
                    }
                    int count = 0;
                    switch (g)
                    {
                        case 5:
                        case 4:
                        case 3:
                            for (int j = 0; j < 3; j++)
                                if (a.Contains(b[g - 3][j, i])) count++;
                            if (count == 3) return false;
                            break;
                        case 8:
                        case 7:
                        case 6:
                            for (int j = 0; j < 3; j++)
                            {
                                if (a.Contains(b[g - 3][j, i])) count++;
                                if (a.Contains(b[g - 6][j, i])) count++;
                            }
                            if (count == 3) return false;
                            break;
                    }
                }
            return true;
        }

        private void HideValue()
        {
            Random random = new Random();
            int grid = random.Next(5);
            int row = random.Next(3);
            int col = random.Next(3);
            if (Incomplete[grid][row, col] >= 0)
            {
                Incomplete[grid][row, col] = -1;
                HiddenCount++;
                if (grid != 4 || row != 1 || col != 1)
                {
                    Incomplete[8 - grid][2 - row, 2 - col] = -1; // mirror
                    HiddenCount++;
                }
            }
            else HideValue();
        }
    }
}

internal static class GameExtensions
{

    public static void Print(this ICollection<int> c, String about)
    {
        Console.WriteLine(about + ": " + string.Join("-", c));
    }

    public static void Remove(this List<int> a, List<int[,]> b, int g, int? r, int? c)
    {
        for (int i = 0; i < 3; i++) a.Remove(b[g][r ?? i, c ?? i]);
    }

    public static void Restore(this ICollection<int> c, int[,] g, int r)
    {
        for (int i = 0; i < 3; i++) if (g[r, i] > 0) c.Add(g[r, i]);
    }
}
