using UnityEngine;

public class Modifier2 : MonoBehaviour // Minus Moves
{
    public int lessMoves = 3;
    private TurnManager turnManager;

    void Start()
    {
        turnManager = FindObjectOfType<TurnManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Playyer"))
        {
            turnManager.AddExtraMove(-lessMoves);  // Negative to reduce moves
            Destroy(gameObject);
        }
    }
}

