using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace Tetris.Board
{
    public class TetrisBlockTemplate
    {
        private static int TotalBlockCount = 0;
        public static List<TetrisBlockTemplate> Templates { get; } = new List<TetrisBlockTemplate>()
        {
            new TetrisBlockTemplate()
            {
                Matrix = new int[][]
                {
                    new int[] {1, 1},
                    new int[] {1, 1}
                },
                BlockSkinID = "Block1"
            },
            new TetrisBlockTemplate()
            {
                Matrix = new int[][]
                {
                    new int[] {0, 1, 0},
                    new int[] {1, 1, 1},
                    new int[] {0, 0, 0},
                },
                BlockSkinID = "Block2"
            },
            new TetrisBlockTemplate()
            {
                Matrix = new int[][]
                {
                    new int[] {0, 1, 0},
                    new int[] {1, 1, 0},
                    new int[] {1, 0, 0},
                },
                BlockSkinID = "Block3"
            },
            new TetrisBlockTemplate()
            {
                Matrix = new int[][]
                {
                    new int[] {0, 1, 0},
                    new int[] {0, 1, 1},
                    new int[] {0, 0, 1},
                },
                BlockSkinID = "Block4"
            },
            new TetrisBlockTemplate()
            {
                Matrix = new int[][]
                {
                    new int[] {1, 1, 0},
                    new int[] {0, 1, 0},
                    new int[] {0, 1, 0},
                },
                BlockSkinID = "Block5"
            },
            new TetrisBlockTemplate()
            {
                Matrix = new int[][]
                {
                    new int[] {0, 1, 1},
                    new int[] {0, 1, 0},
                    new int[] {0, 1, 0},
                },
                BlockSkinID = "Block6"
            },
            new TetrisBlockTemplate()
            {
                Matrix = new int[][]
                {
                    new int[] {0, 0, 0, 0},
                    new int[] {1, 1, 1, 1},
                    new int[] {0, 0, 0, 0},
                    new int[] {0, 0, 0, 0}
                },
                BlockSkinID = "Block7"
            }
        };
        public static TetrisBlockTemplate GetRandomTemplate()
        {
            TotalBlockCount++;
            int averageBlockCount = TotalBlockCount / Templates.Count;
            double rndValue = Program.Rnd.NextDouble();

            double minChance = 0;
            double maxChance = 0;

            var index = -1;
            for (int i = 0; i < Templates.Count; i++)
            {
                maxChance += (100 / Templates.Count - (Templates[i].AppearTime - averageBlockCount)) / 100f;
                if (minChance <= rndValue && rndValue < maxChance)
                {
                    index = i;
                    Templates[i].AppearTime++;
                    break;
                }
            }

            if (index < 0)
            {
                index = Program.Rnd.Next(0, Templates.Count);
                Templates[index].AppearTime++;
            }

            return Templates[index];
        }

        public int AppearTime = 0;
        public int[][] Matrix;
        public string BlockSkinID;
    }
}
