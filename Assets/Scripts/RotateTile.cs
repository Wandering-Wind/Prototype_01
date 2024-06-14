using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float rotationSpeed;
    public bool ClockwiseRotation;

    private TurnManager turnManager;
    //AudioManager audioManager;

    void Start()
    {
        turnManager = FindObjectOfType<TurnManager>();
    }

    void Update()
    {
        // Continuous rotation logic can be enabled if required
        // if (ClockwiseRotation == false)
        // {
        //     rotZ = Time.deltaTime * rotationSpeed;
        // }
        // else
        // {
        //     rotZ += -Time.deltaTime * rotationSpeed;
        // }
        // transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }

    private void OnMouseDown()
    {
        // Only allow rotation if the current player is active and the panel is not active
        if (turnManager != null && !TurnEndUIManager.isPanelActive)
        {
            if (turnManager.isPlayer1Turn)
            {
                Debug.Log("rotates");
                RotateTile();
                turnManager.RegisterMove();
            }
            else if (turnManager.isPlayer2Turn)
            {
                Debug.Log("Rotates for Player2");
                RotateTile();
                turnManager.RegisterMove();
            }
        }
    }

    public void RotateTile()
    {
        transform.Rotate(0, 0, -90);
       // audioManager.PlaySFX(audioManager.tileMusic); 
       //This code somehow messes with the player switch communicator
    }

    private bool IsActivePlayer()
    {
        Movement activePlayer = turnManager.isPlayer1Turn ? turnManager.player1 : turnManager.player2;
        return transform.IsChildOf(activePlayer.transform) || transform == activePlayer.transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(transform, true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(null, false);
        }
    }
}
