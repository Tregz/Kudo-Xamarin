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

        int[] digits = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        int[,] grid = new int[8, 8];
        int[,] grid0 = new int[2, 2];
        int[,] grid1 = new int[2, 2];
        int[,] grid2 = new int[2, 2];
        int[,] grid3 = new int[2, 2];
        int[,] grid4 = new int[2, 2];
        int[,] grid5 = new int[2, 2];
        int[,] grid6 = new int[2, 2];
        List<int[,]> list = new List<int[,]>();

        public List<int[,]> Grid
        {
            get {
                Random r = new Random();

                for (int i = 0; i < 9; i++)
                {
                    int[,] g = new int[3, 3];
                    List<int> numbers = digits.ToList();
                    for (int j = 0; j < 9; j++)
                    {
                        int random = numbers[r.Next(numbers.Count)];
                        numbers.Remove(random);
                        switch (j)
                        {
                            case 0: case 1: case 2: g[0, j] = random;
                                break;
                            case 3: case 4: case 5: g[1, j-3] = random;
                                break;
                            default: g[2, j-6] = random;
                                break;
                        }
                    }
                    list.Add(g);
                }

                /* for (int i = 0; i < 9; i++) {
                    for (int j = 0; j < 9; j++) {
                        //int k = 9 * 1;
                        grid[i, j] = (int) list[k][j];
                        // TODO grid before
                    }
                } */
                return list;
            }
        }

        public GameViewModel()
        {
            Title = "Game";   
        }
    }
}
