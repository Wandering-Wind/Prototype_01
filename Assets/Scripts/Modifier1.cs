using UnityEngine;

public class Modifier1 : MonoBehaviour
{
    public int extraMoves = 3;
    private TurnManager turnManager;

    void Start()
    {
        turnManager = FindObjectOfType<TurnManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            turnManager.AddExtraMove(extraMoves);
            Destroy(gameObject);
        }
    }
}
