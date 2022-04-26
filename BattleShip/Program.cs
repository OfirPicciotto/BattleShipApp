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

        //CreatePlayer(2);
        InitPlayers(players);

        while (player1.Score < 5 && player2.Score < 5) {

            if (currPlayer == "Player1") {
                PlayerTurn(player1.Board, player2.Board, player1.Score, player1.Name, player1Guesses);
            } else {
                PlayerTurn(player2.Board, player1.Board, player2.Score, player2.Name, player2Guesses);
            }
        }
    }

    //public static void CreatePlayer(int numPlayers) {
    //    for (int i = 1; i <= numPlayers; i++) {
    //        PlayerModel player = new PlayerModel($"Player{i}");
    //        players.Add(player);
    //    }
    //}

    private static void InitPlayers(List<PlayerModel> players) {
        players.Add(player1);
        players.Add(player2);
        foreach (var player in players) {
            ConsoleMessages.Welcome(0);
            Console.WriteLine(player.Name + " enter your ship positions: ");
            Console.WriteLine();
            BoardModel.BoardPlacement(player.Board);
            Console.Clear();
        }
    }

    private static void GetPlayerHit(int playerScore, int playerNum, List<string> guesses) {
        playerHit = ConsoleMessages.GetString($"Player{playerNum}, Please enter a cell to fire on (Hits: {playerScore}/5): ");
        playerHit = string.Concat(playerHit[0].ToString().ToUpper(), playerHit.AsSpan(1));
        if (playerHit == "") {
            playerHit = ConsoleMessages.GetString($"Player{playerNum}, Please enter a cell to fire on (Hits: {playerScore}/5): ");
        }
        guesses.Add(playerHit);
    }

    private static void PlayerTurn(List<string> board, List<string> opponentBoard, int playerScoreModel, string currPlayerName, List<string> guesses) {
        Thread.Sleep(TimeSpan.FromSeconds(0.5));
        Console.Clear();
        ConsoleMessages.Welcome(0);
        Console.WriteLine($"Player{playerNum} Board:");
        Console.WriteLine("-----------------------------");
        Console.WriteLine();
        BoardModel.PrintBoard(board);
        Console.WriteLine();
        Console.WriteLine($"Guesses so far ({guesses.Count}): {string.Join(", ", guesses)}");
        GetPlayerHit(playerScoreModel, playerNum, guesses);
        HandlePlayer(opponentBoard, currPlayerName);
    }

    private static void HandlePlayer(List<string> opponentBoard, string currPlayerName) {
        if (currPlayer == "Player1") {
            playerNum++;
            currPlayer = $"Player{playerNum}";
            playerScore = player1.Score;
            (_, playerScore) = BoardModel.CheckHit(opponentBoard, playerHit, playerScore);
            player1.Score = playerScore;
            BoardModel.CheckWin(currPlayerName, player1.Score);
        } else {
            playerNum--;
            currPlayer = $"Player{playerNum}";
            playerScore = player2.Score;
            (_, playerScore) = BoardModel.CheckHit(opponentBoard, playerHit, playerScore);
            player2.Score = playerScore;
            BoardModel.CheckWin(currPlayerName, player2.Score);
        }
    }
}

