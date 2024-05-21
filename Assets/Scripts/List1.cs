using UnityEngine;

public class Player2Script : MonoBehaviour
{
    private TurnManager turnManager;
    private NewBehaviourScript tileScript;

    void Start()
    {
        turnManager = FindObjectOfType<TurnManager>();
        tileScript = FindObjectOfType<NewBehaviourScript>();
    }

    public void OnMouseDown()
    {
        if (turnManager != null && !turnManager.isPlayer1Turn)
        {
            Debug.Log("Player 2 rotates");
            tileScript.RotateTile();
            turnManager.RegisterMove();
        }
    }
}
