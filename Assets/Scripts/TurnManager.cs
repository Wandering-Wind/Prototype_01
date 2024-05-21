using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public Movement player1;
    public Movement player2;
    public int maxMoves = 5;
    private int currentMoves = 0;
    public bool isPlayer1Turn = true;
    public bool isPlayer2Turn = true;

    void Start()
    {
        SetCurrentPlayer(player1);
    }

    public void RegisterMove()
    {
        currentMoves++;
        Debug.Log($"Move registered. Current moves: {currentMoves}/{maxMoves}");

        if (currentMoves >= maxMoves)
        {
            SwitchTurn();
        }
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
    }

    private void SetCurrentPlayer(Movement player)
    {
        player1.enabled = player == player1;
        player2.enabled = player == player2;

        Debug.Log($"Current Player: {(player == player1 ? "Player 1" : "Player 2")}");
    }
}
