using UnityEngine;

public class Player1Script : MonoBehaviour
{
    private TurnManager turnManager;
    private NewBehaviourScript tileScript;

    void Start()
    {
        turnManager = FindObjectOfType<TurnManager>();
        tileScript = FindObjectOfType<NewBehaviourScript>();
    }

    private void OnMouseDown()
    {
        if (turnManager != null && turnManager.isPlayer1Turn)
        {
            Debug.Log("Player 1 rotates");
            tileScript.RotateTile();
            turnManager.RegisterMove();
        }
    }
}
