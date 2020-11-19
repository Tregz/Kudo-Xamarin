using System;
using System.Collections.Generic;

namespace Kudo
{
    public class GameViewModel : BaseViewModel
    {
        // Sudoku grid: 81 numbers, 9x9
        int[] digits = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        List<int[,]> list = new List<int[,]>();
        public List<int[,]> Sudoku
        {
            get
            {
                list = new List<int[,]>();
                Random r = new Random();
                int again = 0;
                for (int i = 0; i < 9; i++)
                {
                    Console.WriteLine("* Grid " + i);
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
                                    numbers.Print("Numbers");
                                    List<int> a = new List<int>(numbers);
                                    // Remove unavailable numbers
                                    switch (i)
                                    {
                                        case 8:
                                            a.Remove(list, 5, null, col);
                                            a.Remove(list, 2, null, col);
                                            a.Remove(list, 7, row, null);
                                            a.Remove(list, 6, row, null);
                                            break;
                                        case 7:
                                            a.Remove(list, 4, null, col);
                                            a.Remove(list, 1, null, col);
                                            a.Remove(list, 6, row, null);
                                            break;
                                        case 6:
                                            a.Remove(list, 3, null, col);
                                            a.Remove(list, 0, null, col);
                                            break;
                                        case 5:
                                            a.Remove(list, 2, null, col);
                                            a.Remove(list, 4, row, null);
                                            a.Remove(list, 3, row, null);
                                            break;
                                        case 4:
                                            a.Remove(list, 1, null, col);
                                            a.Remove(list, 3, row, null);
                                            break;
                                        case 3:
                                            a.Remove(list, 0, null, col);
                                            break;
                                        case 2:
                                            a.Remove(list, 1, row, null);
                                            a.Remove(list, 0, row, null);
                                            break;
                                        case 1:
                                            a.Remove(list, 0, row, null);
                                            break;
                                        default:
                                            break;
                                    }
                                    a.Print("Available");
                                    if (a.Count > 0)
                                    {
                                        int random = a[r.Next(a.Count)];
                                        numbers.Remove(random);
                                        g[row, col] = random;

                                        // Check that second row is valid
                                        if (row == 1 && col == 2 && validRow)
                                            if (!row.IsValid(numbers, list, i))
                                                validRow = false;

                                        if (col == 2)
                                        {
                                            if (g[row, 0] == 0) validRow = false;
                                            if (g[row, 1] == 0) validRow = false;
                                            if (g[row, 2] == 0) validRow = false;
                                            if (validRow) completedRow = true;
                                            else
                                            {
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
                                    else {
                                        String error = "Error at grid " + i;
                                        error += " col " + col + " row " + row;
                                        error += " completed? " + completedRow;
                                        error += " i3x3 " + i3x3;
                                        error += " iRow " + iRow;
                                        Console.WriteLine(error);
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
                                        else if (col == 1 && i == 8)
                                        {
                                            cancel = true;
                                            completed3x3 = true;
                                        }
                                    }
                                }
                            }
                        }                        
                    }
                    for (int row = 0; row < 3; row++)
                        for (int col = 0; col < 3; col++)
                            Console.Write(string.Format("{0} ", g[row, col]));
                        Console.Write(Environment.NewLine + Environment.NewLine);
                    if (cancel)
                    {
                        list.RemoveAt(--i);
                        if (again++ > 5) {
                            list.RemoveAt(--i);
                            again = 0;
                        }
                        --i;
                    }
                    else list.Add(g);
                }
                return list;
            }
        }

        public GameViewModel()
        {
            Title = "Game";
        }
    }
}

internal static class GameExtensions
{

    public static Boolean IsValid(this int r, HashSet<int> a, List<int[,]> b, int g) {
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
