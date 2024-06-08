using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    public Movement player1;
    public Movement player2;
    public int maxMoves = 5;
    private int currentMoves = 0;
    public bool isPlayer1Turn = true;
    public bool isPlayer2Turn = true;

    public Text movesText; // Reference to the UI Text object for moves
    public Text turnNotificationText; // Reference to the UI Text object for turn notification

    void Start()
    {
        SetCurrentPlayer(player1);
        UpdateMovesText(); // Update moves text when the game starts
        DisplayTurnNotification(); // Display the initial turn notification
    }

    public void RegisterMove()
    {
        currentMoves++;
        Debug.Log($"Move registered. Current moves: {currentMoves}/{maxMoves}");

        if (currentMoves >= maxMoves)
        {
            SwitchTurn();
        }
        UpdateMovesText(); // Update moves text after each move
    }

    public void AddExtraMove(int moves)
    {
        currentMoves -= moves; // Adding or reducing moves
        Debug.Log($"Moves adjusted by {moves}. Current moves: {currentMoves}/{maxMoves}");

        UpdateMovesText();
    }

    public void SkipTurn()
    {
        currentMoves = maxMoves; // Forces switch turn
        Debug.Log("Turn skipped.");
        SwitchTurn();
    }

    private void SwitchTurn()
    {
        currentMoves = 0;
        isPlayer1Turn = !isPlayer1Turn;

        if (isPlayer1Turn)
        {
            SetCurrentPlayer(player1);
        }
        else
        {
            SetCurrentPlayer(player2);
        }

        UpdateMovesText(); // Update moves text when a new turn starts
        DisplayTurnNotification(); // Display a notification for the new turn
    }

    private void SetCurrentPlayer(Movement player)
    {
        player1.enabled = player == player1;
        player2.enabled = player == player2;

        Debug.Log($"Current Player: {(player == player1 ? "Player 1" : "Player 2")}");
    }

    private void UpdateMovesText()
    {
        movesText.text = $"Moves Left: {maxMoves - currentMoves}";
    }

    private void DisplayTurnNotification()
    {
        string currentPlayer = isPlayer1Turn ? "Player 1" : "Player 2";
        turnNotificationText.text = $"Turn: {currentPlayer}";
        Debug.Log($"New turn: {currentPlayer}");
    }
}
