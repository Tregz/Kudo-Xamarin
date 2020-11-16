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
        public List<int[,]> Grid
        {
            get
            {
                list = new List<int[,]>();
                Random r = new Random();
                for (int i = 0; i < 9; i++)
                {
                    Console.WriteLine("*** Grid " + i);
                    int[,] g = new int[3, 3];
                    List<int> numbers = digits.ToList();
                    for (int row = 0; row < 3; row++)
                    {
                        for (int col = 0; col < 3; col++)
                        {
                            try
                            {
                                List<int> available = new List<int>(numbers);
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
                            }
                            catch
                            {
                                // Restore removed numbers and try again
                                numbers.Add(g[row, 0]);
                                numbers.Add(g[row, 1]);
                                numbers.Add(g[row, 2]);
                                col = 0;
                            }
                        }
                    }
                    list.Add(g);
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
