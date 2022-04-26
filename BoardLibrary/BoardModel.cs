using System;
using ConsoleMessageLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardLibrary {

    public class BoardModel {
        private static List<string> letters = new List<string> { "A", "B", "C", "D", "E" };

        public static List<string> BoardPlacement(List<string> board) {
            int numOfShips = 5;
            for (int i = 0; i < numOfShips; i++) {
                int shipNum = i + 1;
                string cell = GetCell(shipNum);
                while (board.IndexOf(cell) == -1) {
                    cell = GetCell(shipNum);
                }
                board = BoardMark(board, cell, "*");
            }
            return board;
        }

        private static string GetCell(int shipNum) {
            string cell = ConsoleMessages.GetString($"Enter cell to place ship #{shipNum} (Values from A1-E5): ");
            cell =  string.Concat(cell[0].ToString().ToUpper(), cell.AsSpan(1));
            while (cell == "" || cell == null) {
                cell = ConsoleMessages.GetString($"Enter cell to place ship #{shipNum} (Values from A1-E5): ");
            }
            return cell;
        }

        public static List<string> InitBoard() {
            List<string> board = new List<string>();
            for (int i = 0; i < letters.Count; i++) {
                for (int j = 1; j < letters.Count + 1; j++) {
                    board.Add(letters[i] + j);
                }
            }
            return board;
        }

        public static void PrintBoard(List<string> board) {
            int idx = 0;
            int LineCharacterLimit = 5;
            foreach (var cell in board) {
                idx++;
                if (idx == LineCharacterLimit) {
                    Console.WriteLine(" {0} ", cell);
                    idx = 0;
                } else {
                    Console.Write(" {0} ", cell);
                }
            }
        }

        public static (List<string>, int) CheckHit(List<string> board, string cell, int playerScore) {
            int idx = board.IndexOf(cell);
            int idxHit = board.IndexOf($"*{cell}*");
            if (idxHit != -1) {
                Console.WriteLine();
                Console.WriteLine("HIT!!!");
                board = BoardMark(board, cell, " XX ");
                playerScore++;
                return (board, playerScore);
            } else if (idx != -1) {
                Console.WriteLine();
                Console.WriteLine("MISSED");
                board = BoardMark(board, cell, " OO ");
                return (board, playerScore);
            } else {
                Console.WriteLine("You entered an invalid cell and missed your turn!!!");
                Thread.Sleep(TimeSpan.FromSeconds(1));
                return (board, playerScore);
            }
        }

        public static List<string> BoardMark(List<string> board, string cell, string mark) {
            int idx = board.IndexOf(cell);
            string cellToBoard = $"*{cell}*";
            int idxHit = board.IndexOf(cellToBoard);
            if (mark == "*") {
                while (idx == -1) {
                    Console.WriteLine("Not a valid cell, Try again.");
                    idx = board.IndexOf(cell);
                }
                board[idx] = cellToBoard;
            } else if (idxHit != -1) {
                board[idxHit] = mark;
            } else {
                board[idx] = mark;
            }
            return board;
        }

        public static bool CheckWin(string playerName, int playerScore) {
            if (playerScore == 5) {
                Console.Clear();
                ConsoleMessages.Welcome(0);
                Console.WriteLine();
                Console.WriteLine($"Congratulations {playerName}!!! You Won The Game!!!");
                return true;
            }
            return false;
        }
    }

}
