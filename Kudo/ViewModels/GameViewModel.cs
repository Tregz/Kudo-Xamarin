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
                    Boolean cancel = false;
                    while (!completed3x3)
                    {
                        //g = new int[3, 3];
                        List<int> numbers = digits.ToList();

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
                                        Console.WriteLine(string.Join("\t", numbers));
                                        switch (i)
                                        {
                                            case 8:
                                                switch (col)
                                                {
                                                    case 2:
                                                        available.Remove(list[5][0, 2]);
                                                        available.Remove(list[5][1, 2]);
                                                        available.Remove(list[5][2, 2]);
                                                        available.Remove(list[2][0, 2]);
                                                        available.Remove(list[2][1, 2]);
                                                        available.Remove(list[2][2, 2]);
                                                        break;
                                                    case 1:
                                                        available.Remove(list[5][0, 1]);
                                                        available.Remove(list[5][1, 1]);
                                                        available.Remove(list[5][2, 1]);
                                                        available.Remove(list[2][0, 1]);
                                                        available.Remove(list[2][1, 1]);
                                                        available.Remove(list[2][2, 1]);
                                                        break;
                                                    case 0:
                                                        available.Remove(list[5][0, 0]);
                                                        available.Remove(list[5][1, 0]);
                                                        available.Remove(list[5][2, 0]);
                                                        available.Remove(list[2][0, 0]);
                                                        available.Remove(list[2][1, 0]);
                                                        available.Remove(list[2][2, 0]);
                                                        break;
                                                }
                                                switch (row)
                                                {
                                                    case 2:
                                                        available.Remove(list[7][2, 0]);
                                                        available.Remove(list[7][2, 1]);
                                                        available.Remove(list[7][2, 2]);
                                                        available.Remove(list[6][2, 0]);
                                                        available.Remove(list[6][2, 1]);
                                                        available.Remove(list[6][2, 2]);
                                                        break;
                                                    case 1:
                                                        available.Remove(list[7][1, 0]);
                                                        available.Remove(list[7][1, 1]);
                                                        available.Remove(list[7][1, 2]);
                                                        available.Remove(list[6][1, 0]);
                                                        available.Remove(list[6][1, 1]);
                                                        available.Remove(list[6][1, 2]);
                                                        break;
                                                    case 0:
                                                        available.Remove(list[7][0, 0]);
                                                        available.Remove(list[7][0, 1]);
                                                        available.Remove(list[7][0, 2]);
                                                        available.Remove(list[6][0, 0]);
                                                        available.Remove(list[6][0, 1]);
                                                        available.Remove(list[6][0, 2]);
                                                        break;
                                                }
                                                break;
                                            case 7:
                                                switch (col)
                                                {
                                                    case 2:
                                                        available.Remove(list[4][0, 2]);
                                                        available.Remove(list[4][1, 2]);
                                                        available.Remove(list[4][2, 2]);
                                                        available.Remove(list[1][0, 2]);
                                                        available.Remove(list[1][1, 2]);
                                                        available.Remove(list[1][2, 2]);
                                                        break;
                                                    case 1:
                                                        available.Remove(list[4][0, 1]);
                                                        available.Remove(list[4][1, 1]);
                                                        available.Remove(list[4][2, 1]);
                                                        available.Remove(list[1][0, 1]);
                                                        available.Remove(list[1][1, 1]);
                                                        available.Remove(list[1][2, 1]);
                                                        break;
                                                    case 0:
                                                        available.Remove(list[4][0, 0]);
                                                        available.Remove(list[4][1, 0]);
                                                        available.Remove(list[4][2, 0]);
                                                        available.Remove(list[1][0, 0]);
                                                        available.Remove(list[1][1, 0]);
                                                        available.Remove(list[1][2, 0]);
                                                        break;
                                                }
                                                switch (row)
                                                {
                                                    case 2:
                                                        available.Remove(list[6][2, 0]);
                                                        available.Remove(list[6][2, 1]);
                                                        available.Remove(list[6][2, 2]);
                                                        break;
                                                    case 1:
                                                        available.Remove(list[6][1, 0]);
                                                        available.Remove(list[6][1, 1]);
                                                        available.Remove(list[6][1, 2]);
                                                        break;
                                                    case 0:
                                                        available.Remove(list[6][0, 0]);
                                                        available.Remove(list[6][0, 1]);
                                                        available.Remove(list[6][0, 2]);
                                                        break;
                                                }
                                                break;
                                            case 6:
                                                switch (col)
                                                {
                                                    case 2:
                                                        available.Remove(list[3][0, 2]);
                                                        available.Remove(list[3][1, 2]);
                                                        available.Remove(list[3][2, 2]);
                                                        available.Remove(list[0][0, 2]);
                                                        available.Remove(list[0][1, 2]);
                                                        available.Remove(list[0][2, 2]);
                                                        break;
                                                    case 1:
                                                        available.Remove(list[3][0, 1]);
                                                        available.Remove(list[3][1, 1]);
                                                        available.Remove(list[3][2, 1]);
                                                        available.Remove(list[0][0, 1]);
                                                        available.Remove(list[0][1, 1]);
                                                        available.Remove(list[0][2, 1]);
                                                        break;
                                                    case 0:
                                                        available.Remove(list[3][0, 0]);
                                                        available.Remove(list[3][1, 0]);
                                                        available.Remove(list[3][2, 0]);
                                                        available.Remove(list[0][0, 0]);
                                                        available.Remove(list[0][1, 0]);
                                                        available.Remove(list[0][2, 0]);
                                                        break;
                                                }
                                                break;
                                            case 5:
                                                switch (col)
                                                {
                                                    case 2:
                                                        available.Remove(list[2][0, 2]);
                                                        available.Remove(list[2][1, 2]);
                                                        available.Remove(list[2][2, 2]);
                                                        break;
                                                    case 1:
                                                        available.Remove(list[2][0, 1]);
                                                        available.Remove(list[2][1, 1]);
                                                        available.Remove(list[2][2, 1]);
                                                        break;
                                                    case 0:
                                                        available.Remove(list[2][0, 0]);
                                                        available.Remove(list[2][1, 0]);
                                                        available.Remove(list[2][2, 0]);
                                                        break;
                                                }
                                                switch (row)
                                                {
                                                    case 2:
                                                        available.Remove(list[4][2, 0]);
                                                        available.Remove(list[4][2, 1]);
                                                        available.Remove(list[4][2, 2]);
                                                        available.Remove(list[3][2, 0]);
                                                        available.Remove(list[3][2, 1]);
                                                        available.Remove(list[3][2, 2]);
                                                        break;
                                                    case 1:
                                                        available.Remove(list[4][1, 0]);
                                                        available.Remove(list[4][1, 1]);
                                                        available.Remove(list[4][1, 2]);
                                                        available.Remove(list[3][1, 0]);
                                                        available.Remove(list[3][1, 1]);
                                                        available.Remove(list[3][1, 2]);
                                                        break;
                                                    case 0:
                                                        available.Remove(list[4][0, 0]);
                                                        available.Remove(list[4][0, 1]);
                                                        available.Remove(list[4][0, 2]);
                                                        available.Remove(list[3][0, 0]);
                                                        available.Remove(list[3][0, 1]);
                                                        available.Remove(list[3][0, 2]);
                                                        break;
                                                }
                                                break;
                                            case 4:
                                                switch (col)
                                                {
                                                    case 2:
                                                        available.Remove(list[1][0, 2]);
                                                        available.Remove(list[1][1, 2]);
                                                        available.Remove(list[1][2, 2]);
                                                        break;
                                                    case 1:
                                                        available.Remove(list[1][0, 1]);
                                                        available.Remove(list[1][1, 1]);
                                                        available.Remove(list[1][2, 1]);
                                                        break;
                                                    case 0:
                                                        available.Remove(list[1][0, 0]);
                                                        available.Remove(list[1][1, 0]);
                                                        available.Remove(list[1][2, 0]);
                                                        break;
                                                }
                                                switch (row)
                                                {
                                                    case 2:
                                                        available.Remove(list[3][2, 0]);
                                                        available.Remove(list[3][2, 1]);
                                                        available.Remove(list[3][2, 2]);
                                                        break;
                                                    case 1:
                                                        available.Remove(list[3][1, 0]);
                                                        available.Remove(list[3][1, 1]);
                                                        available.Remove(list[3][1, 2]);
                                                        break;
                                                    case 0:
                                                        available.Remove(list[3][0, 0]);
                                                        available.Remove(list[3][0, 1]);
                                                        available.Remove(list[3][0, 2]);
                                                        break;
                                                }
                                                break;
                                            case 3:
                                                switch (col)
                                                {
                                                    case 2:
                                                        available.Remove(list[0][0, 2]);
                                                        available.Remove(list[0][1, 2]);
                                                        available.Remove(list[0][2, 2]);
                                                        break;
                                                    case 1:
                                                        available.Remove(list[0][0, 1]);
                                                        available.Remove(list[0][1, 1]);
                                                        available.Remove(list[0][2, 1]);
                                                        break;
                                                    case 0:
                                                        available.Remove(list[0][0, 0]);
                                                        available.Remove(list[0][1, 0]);
                                                        available.Remove(list[0][2, 0]);
                                                        break;
                                                }
                                                break;
                                            case 2:
                                                switch (row)
                                                {
                                                    case 2:
                                                        available.Remove(list[1][2, 0]);
                                                        available.Remove(list[1][2, 1]);
                                                        available.Remove(list[1][2, 2]);
                                                        available.Remove(list[0][2, 0]);
                                                        available.Remove(list[0][2, 1]);
                                                        available.Remove(list[0][2, 2]);
                                                        break;
                                                    case 1:
                                                        available.Remove(list[1][1, 0]);
                                                        available.Remove(list[1][1, 1]);
                                                        available.Remove(list[1][1, 2]);
                                                        available.Remove(list[0][1, 0]);
                                                        available.Remove(list[0][1, 1]);
                                                        available.Remove(list[0][1, 2]);
                                                        break;
                                                    case 0:
                                                        available.Remove(list[1][0, 0]);
                                                        available.Remove(list[1][0, 1]);
                                                        available.Remove(list[1][0, 2]);
                                                        available.Remove(list[0][0, 0]);
                                                        available.Remove(list[0][0, 1]);
                                                        available.Remove(list[0][0, 2]);
                                                        break;
                                                }
                                                break;
                                            case 1:
                                                switch (row)
                                                {
                                                    case 2:
                                                        available.Remove(list[0][2, 0]);
                                                        available.Remove(list[0][2, 1]);
                                                        available.Remove(list[0][2, 2]);
                                                        break;
                                                    case 1:
                                                        available.Remove(list[0][1, 0]);
                                                        available.Remove(list[0][1, 1]);
                                                        available.Remove(list[0][1, 2]);
                                                        break;
                                                    case 0:
                                                        available.Remove(list[0][0, 0]);
                                                        available.Remove(list[0][0, 1]);
                                                        available.Remove(list[0][0, 2]);
                                                        break;
                                                }
                                                break;
                                            default:
                                                break;
                                        }

                                        // Catching index out of range
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
                                            if (validRow) completedRow = true;
                                            else {

                                                if (testRow++ > 50) completedRow = true;
                                                else {

                                                    // Restore removed numbers and try again
                                                    if (g[row, 0] > 0 && !numbers.Contains(g[row, 0])) numbers.Add(g[row, 0]);
                                                    if (g[row, 1] > 0 && !numbers.Contains(g[row, 1])) numbers.Add(g[row, 1]);
                                                    if (g[row, 2] > 0 && !numbers.Contains(g[row, 2])) numbers.Add(g[row, 2]);
                                                    row--;
                                                } 
                                            }
                                        }



                                        if (row == 2 && col == 2 && completedRow) completed3x3 = true;
                                        else if (col == 2) completedRow = true;

                                        if (test++ > 100) completed3x3 = true;

                                        //if (row == 2 && col == 2 && valid) completed = true;
                                        //if (row == 2 && col == 2 && valid) completed = true;
                                        //else if (test++ > 100) completed = true;
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Error at col " + col + " row " + row + " completed? " + completedRow);
                                        if (col == 2 && row == 2)
                                        {
                                            if (i == 8) list.RemoveAt(--i);
                                            if (i > 0) --i;
                                            cancel = true;
                                            completedRow = true;
                                            completed3x3 = true;
                                        }
                                        else
                                        {
                                            if (g[row, 0] > 0 && !numbers.Contains(g[row, 0])) numbers.Add(g[row, 0]);
                                            if (g[row, 1] > 0 && !numbers.Contains(g[row, 1])) numbers.Add(g[row, 1]);
                                            if (g[row, 2] > 0 && !numbers.Contains(g[row, 2])) numbers.Add(g[row, 2]);
                                            row--;
                                            completedRow = true;
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
