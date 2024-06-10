using UnityEngine;

public class Modifier4 : MonoBehaviour
{
    private TurnManager turnManager;

    void Start()
    {
        turnManager = FindObjectOfType<TurnManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Playyer"))
        {
            turnManager.SkipTurn();
            Destroy(gameObject);
        }
    }
}
