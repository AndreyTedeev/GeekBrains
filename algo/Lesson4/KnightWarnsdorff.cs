using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson4
{
    class KnightWarnsdorff
    {
        int boardSize;
        int[,] board;

        // history of knight moves
        int[] histX, histY;

        // all knight moves possible (x, y)
        int[] moveX = { 1, 2, 2, 1, -1, -2, -2, -1 };
        int[] moveY = { -2, -1, 1, 2, 2, 1, -1, -2 };

        int x = 0, y = 0, moveNum = 0;

        public KnightWarnsdorff(int boardSize)
        {
            this.boardSize = boardSize;
            board = new int[boardSize, boardSize];
            histX = new int[boardSize * boardSize];
            histY = new int[boardSize * boardSize];
        }

        public void MoveKnight()
        {
            //Console.WriteLine(moveNum);
            board[x, y] = 1; // mark the cell as used
            histX[moveNum] = x;
            histY[moveNum] = y;
            moveNum++;
            if (moveNum >= histX.Length)
                return;
            // check all possible moves of the knight
            int newX = 1, newY = -1, rank = 8;
            int tempX, tempY;
            for (int m = 0; m < 8; m++)
            {
                tempX = x + moveX[m];
                tempY = y + moveY[m];
                // check if knight is inside the board bounds
                if (tempX < 0 || tempX > boardSize - 1 || tempY < 0 || tempY > boardSize - 1)
                    continue;
                // check if the cell is already used
                if (board[tempX, tempY] == 1)
                    continue;
                int count = countMovesFromPosition(tempX, tempY);
                if (count < rank)
                {
                    rank = count;
                    newX = tempX;
                    newY = tempY;
                    if (count == 1)
                        break;
                }
            }
            if (newX >= 0)
            {
                x = newX;
                y = newY;
                MoveKnight();
            }
            moveNum--;
            board[x, y] = 0;
            moveNum--;
            x = histX[moveNum];
            y = histY[moveNum];
            moveNum++;
        }

        int countMovesFromPosition(int x, int y)
        {
            int newX, newY, count = 0;
            for (int m = 0; m < 8; m++)
            {
                newX = x + moveX[m];
                newY = y + moveY[m];
                // check if knight is inside the board bounds
                if (newX < 0 || newX > boardSize - 1 || newY < 0 || newY > boardSize - 1)
                    continue;
                // check if the cell is already used
                if (board[newX, newY] == 1)
                    continue;
                count++;
            }
            return count;
        }

        public void PrintBoard()
        {
            Console.Clear();
            Console.CursorLeft = 0;
            Console.CursorTop = 10;
            Console.Write("Метод Варнсдорфа. Hit any key for next move ");
            Console.CursorLeft = 10;
            Console.CursorTop = 10;
            for (int a = 0; a <= boardSize * boardSize - 1; a++)
            {
                if (a % boardSize == 0)
                    Console.Write("\n");
                Console.Write("+");
            }
            for (int a = 0; a <= boardSize * boardSize - 1; a++)
            {
                Console.CursorLeft = histX[a];
                Console.CursorTop = histY[a] + 11;
                Console.Write('X');
                Console.ReadKey();
            }
            Console.WriteLine("\nThis is it! :)");
            Console.ReadKey();
        }
    }
}
