using UnityEngine;

public class Modifier3 : MonoBehaviour //CANCELLED!!!
{
    public int gatePassTurns = 2;
    private TurnManager turnManager;
    private Movement movement;

    void Start()
    {
        turnManager = FindObjectOfType<TurnManager>();
        movement = GetComponentInParent<Movement>(); // Assuming modifier is a child of the player
    }

  //  void OnTriggerEnter2D(Collider2D other)
   // {
   //     if (other.CompareTag("Player1"))
   //     {
  //          movement.AllowGatePass(gatePassTurns);
  //          Destroy(gameObject);
       // }
   // }
}
