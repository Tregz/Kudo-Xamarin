using System;
using System.Collections.Generic;
using System.Linq;

namespace Kudo
{
    public class GameViewModel : BaseViewModel
    {
        // Test 1
        bool isTrue = false;
        public bool IsTrue
        {
            get { return isTrue; }
            set { SetProperty(ref isTrue, value); }
        }

        // Sudoku grid: 81 numbers, 9x9
        int[] digits = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        List<int[,]> list = new List<int[,]>();
        public List<int[,]> Sudoku
        {
            get
            {

                list = new List<int[,]>();
                Random r = new Random();
                for (int i = 0; i < 9; i++)
                {
                    Console.WriteLine("*** Grid " + i);
                    int[,] g = new int[3, 3];

                    Boolean completed3x3 = false;
                    int test = 0;
                    int failures = 0;
                    Boolean cancel = false;
                    while (!completed3x3)
                    {
                        //g = new int[3, 3];
                        HashSet<int> numbers = new HashSet<int>(digits);

                        int testRow = 0;
                        for (int row = 0; row < 3; row++)
                        {
                            Boolean completedRow = false;
                            while (!completedRow)
                            {
                                Boolean validRow = true;
                                for (int col = 0; col < 3; col++)
                                {
                                    try
                                    {
                                        List<int> available = new List<int>(numbers);
                                        Console.WriteLine("Numbers: " + string.Join("-", numbers));
                                        switch (i)
                                        {
                                            case 8:
                                                available.Remove(list, 5, null, col);
                                                available.Remove(list, 2, null, col);
                                                available.Remove(list, 7, row, null);
                                                available.Remove(list, 6, row, null);
                                                break;
                                            case 7:
                                                available.Remove(list, 4, null, col);
                                                available.Remove(list, 1, null, col);
                                                available.Remove(list, 6, row, null);
                                                break;
                                            case 6:
                                                available.Remove(list, 3, null, col);
                                                available.Remove(list, 0, null, col);
                                                break;
                                            case 5:
                                                available.Remove(list, 2, null, col);
                                                available.Remove(list, 4, row, null);
                                                available.Remove(list, 3, row, null);
                                                break;
                                            case 4:
                                                available.Remove(list, 1, null, col);
                                                available.Remove(list, 3, row, null);
                                                break;
                                            case 3:
                                                available.Remove(list, 0, null, col);
                                                break;
                                            case 2:
                                                available.Remove(list, 1, row, null);
                                                available.Remove(list, 0, row, null);
                                                break;
                                            case 1:
                                                available.Remove(list, 0, row, null);
                                                break;
                                            default:
                                                break;
                                        }

                                        // Catching index out of range
                                        Console.WriteLine("Available not empty: " + available.Count);
                                        Console.WriteLine("Available: " + string.Join("-", available));
                                        int random = available[r.Next(available.Count)];

                                        numbers.Remove(random);
                                        g[row, col] = random;

                                        if (i > 0 && row == 1 && col == 2) for (int value = 0; value < 3; value++) if (validRow)
                                                {
                                                    switch (i)
                                                    {
                                                        case 1:
                                                        case 4:
                                                        case 7:
                                                            if (numbers.Contains(list[i - 1][row + 1, value])) validRow = false;
                                                            break;
                                                        case 2:
                                                        case 5:
                                                        case 8:
                                                            if (numbers.Contains(list[i - 1][row + 1, value])) validRow = false;
                                                            if (numbers.Contains(list[i - 2][row + 1, value])) validRow = false;
                                                            break;
                                                    }

                                                }

                                        if (validRow && i > 1 && row == 1 && col == 2) for (int value = 0; value < 3; value++) if (validRow)
                                                {
                                                    switch (i)
                                                    {
                                                        case 5:
                                                        case 4:
                                                        case 3:
                                                            int count012 = 0;
                                                            if (numbers.Contains(list[i - 3][0, value])) count012++;
                                                            if (numbers.Contains(list[i - 3][1, value])) count012++;
                                                            if (numbers.Contains(list[i - 3][2, value])) count012++;
                                                            if (count012 == 3) validRow = false;
                                                            break;
                                                        case 8:
                                                        case 7:
                                                        case 6:
                                                            int count012345 = 0;
                                                            if (numbers.Contains(list[i - 3][0, value])) count012345++;
                                                            if (numbers.Contains(list[i - 3][1, value])) count012345++;
                                                            if (numbers.Contains(list[i - 3][2, value])) count012345++;
                                                            if (numbers.Contains(list[i - 6][0, value])) count012345++;
                                                            if (numbers.Contains(list[i - 6][1, value])) count012345++;
                                                            if (numbers.Contains(list[i - 6][2, value])) count012345++;
                                                            if (count012345 == 3) validRow = false;
                                                            break;
                                                    }
                                                }
                                        if (col == 2)
                                        {
                                            if (g[row, 0] == 0) validRow = false;
                                            if (g[row, 1] == 0) validRow = false;
                                            if (g[row, 2] == 0) validRow = false;
                                            if (validRow) completedRow = true;
                                            else {
                                                if (testRow++ > 5) {
                                                    completedRow = true;
                                                    if (row > 0) row--;
                                                    testRow = 0;
                                                    if (failures++ > 3) {
                                                        list.RemoveAt(--i);
                                                        --i;
                                                        cancel = true;
                                                        completed3x3 = true;
                                                        completedRow = true;
                                                        failures = 0;
                                                    }
                                                }
                                                else if (i == 8)
                                                {
                                                    list.RemoveAt(--i);
                                                    //list.RemoveAt(--i);
                                                    --i;
                                                    cancel = true;
                                                    completed3x3 = true;
                                                    completedRow = true;
                                                }
                                                else
                                                {
                                                    // Restore removed numbers and try again
                                                    if (g[row, 0] > 0) numbers.Add(g[row, 0]);
                                                    if (g[row, 1] > 0) numbers.Add(g[row, 1]);
                                                    if (g[row, 2] > 0) numbers.Add(g[row, 2]);
                                                } 
                                            }
                                            if (row == 2)
                                            {
                                                if (completedRow) completed3x3 = true;
                                                else if (test++ > 10) completed3x3 = true;
                                            }
                                        }
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Error at grid " + i + " col " + col + " row " + row + " completed? " + completedRow + " testRow " + testRow);
                                        if (col == 2 && row == 2)
                                        {
                                            if (i == 8)
                                            {
                                                list.RemoveAt(--i);
                                                //list.RemoveAt(--i);
                                                --i;
                                                cancel = true;
                                                completed3x3 = true;
                                            }
                                            completedRow = true;
                                        }
                                        else if (col == 2)
                                        {
                                            if (testRow++ > 5) {
                                                testRow = 0;
                                                list.RemoveAt(--i);
                                                --i;
                                                cancel = true;
                                                completed3x3 = true;
                                                completedRow = true;
                                            }
                                            else
                                            {
                                                if (g[row, 0] > 0) numbers.Add(g[row, 0]);
                                                if (g[row, 1] > 0) numbers.Add(g[row, 1]);
                                                if (g[row, 2] > 0) numbers.Add(g[row, 2]);
                                            }
                                        }
                                        else if (col == 1 && i == 8)
                                        {
                                            list.RemoveAt(--i);
                                            --i;
                                            cancel = true;
                                            completed3x3 = true;
                                        }
                                    }

                                }
                            }
                        }

                        
                    }
                    for (int row = 0; row < 3; row++)
                    {
                        for (int col = 0; col < 3; col++)
                        {
                            Console.Write(string.Format("{0} ", g[row, col]));
                        }
                        Console.Write(Environment.NewLine + Environment.NewLine);
                    }
                    if (!cancel) list.Add(g);
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

    public static void Remove(this List<int> available, List<int[,]> list, int grid, int? row, int? line)
    {
        available.Remove(list[grid][row ?? 0, line ?? 0]);
        available.Remove(list[grid][row ?? 1, line ?? 1]);
        available.Remove(list[grid][row ?? 2, line ?? 2]);
    }
}
