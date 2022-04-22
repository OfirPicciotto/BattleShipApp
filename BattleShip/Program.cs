using BoardLibrary;
using ConsoleMessageLibrary;
using PlayerLibrary;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;



public class Program {
    private static int playerNum = 1;
    private static string currPlayer = $"Player{playerNum}";
    private static int playerScore = 0;
    private static string playerHit;
    private static List<string> player1Guesses = new List<string>();
    private static List<string> player2Guesses = new List<string>();
    private static PlayerModel player1 = new PlayerModel("Player1");
    private static PlayerModel player2 = new PlayerModel("Player2");
    private static List<PlayerModel> players = new List<PlayerModel>();

    public static void Main(string[] args) {
        players.Add(player1);
        players.Add(player2);

        foreach (var player in players) {
            ConsoleMessages.Welcome(0);
            Console.WriteLine(player.Name + " enter your ship positions: ");
            Console.WriteLine();
            BoardModel.BoardPlacement(player.Board);
            Console.Clear();
        }

        while (player1.Score < 5 && player2.Score < 5) {

            if (currPlayer == "Player1") {
                HandlePlayer(player2.Board, player1.Score, player1.Name);
            } else {
                HandlePlayer(player1.Board, player2.Score, player2.Name);
            }
        }
    }

    private static string GetPlayerHit(int playerScore, int playerNum) {
        playerHit = ConsoleMessages.GetString($"Player{playerNum}, Please enter a cell to fire on (Hits: {playerScore}/5): ");
        if (playerHit == "") {
            playerHit = ConsoleMessages.GetString($"Player{playerNum}, Please enter a cell to fire on (Hits: {playerScore}/5): ");
        }
        return playerHit;
    }

    private static string PlayerTurn(List<string> board, int playerScoreModel, List<string> guesses) {
        Thread.Sleep(TimeSpan.FromSeconds(0.5));
        Console.Clear();
        ConsoleMessages.Welcome(0);
        Console.WriteLine($"Player{playerNum} Board:");
        Console.WriteLine("-----------------------------");
        Console.WriteLine();
        BoardModel.PrintBoard(board);
        Console.WriteLine();
        Console.WriteLine($"Guesses so far ({guesses.Count}): {string.Join(", ", guesses)}");
        playerHit = GetPlayerHit(playerScoreModel, playerNum);
        guesses.Add(playerHit);
        return playerHit;
    }

    private static void HandlePlayer(List<string> opponentBoard, int playerScoreModel, string currPlayerName) {
        if (currPlayer == "Player1") {
            playerNum++;
            playerScore = playerScoreModel;
            (opponentBoard, playerScore) = BoardModel.CheckHit(opponentBoard, playerHit, playerScore);
            playerScoreModel = playerScore;
            BoardModel.CheckWin(currPlayerName, playerScoreModel);
        } else {
            playerNum--;
            playerScore = playerScoreModel;
            (opponentBoard, playerScore) = BoardModel.CheckHit(opponentBoard, playerHit, playerScore);
            playerScoreModel = playerScore;
            BoardModel.CheckWin(currPlayerName, playerScoreModel);
        }
    }
}
}
