using UnityEngine;

public class Modifier4 : MonoBehaviour //SkipTurn
{
    private TurnManager turnManager;

    void Start()
    {
        turnManager = FindObjectOfType<TurnManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            turnManager.SkipTurn();
            Destroy(gameObject);
        }
    }
}
