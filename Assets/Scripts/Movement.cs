using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
//Movement for player only, not for tiles or anything like that
public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private bool canMove = true;
    private bool isDoubleMove = false; // Flag to track if player's movement distance is doubled

    // Basic movement parameters
    public float movSpeed;
    float speedX, speedY;
    Rigidbody2D rb;

    // Tile-based movement parameters
    public float tileSize = 1.25f;
    private Vector3 targetPosition;
    private bool isMoving;
    Movement movement;
    Collider2D col;
    Transform whereIam;
    GameObject parent;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.position = new Vector3(0.011f, 0.02f, 0);
        targetPosition = rb.position;
        col= GetComponent<Collider2D>();
        parent = gameObject.transform.parent.GetComponent<GameObject>(); //parent as a gameobject

    }

    void Update()
    {

        // Basic movement
        speedX = Input.GetAxisRaw("Horizontal") * movSpeed;
        speedY = Input.GetAxisRaw("Vertical") * movSpeed;
        rb.velocity = new Vector3(speedX, speedY);

        //whereIam = parent.transform;
        //get the name to find out which tile you are on to get a reference to the four surrounding tiles.



        // Tile-based movement
        if (canMove && !isMoving)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
                MovePlayer(Vector3.up);
            else if (Input.GetKeyDown(KeyCode.DownArrow))
                MovePlayer(Vector3.down);
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
                MovePlayer(Vector3.left);
            else if (Input.GetKeyDown(KeyCode.RightArrow))
                MovePlayer(Vector3.right);
        }
    }
    
    public void StopMovement(float duration)
    {
        canMove = false;
        Invoke("EnableMovement", duration);
    }

    public void SetDoubleMove(bool isDouble)
    {
        isDoubleMove = isDouble;
    }

    private void EnableMovement()
    {
        canMove = true;
    }

    // Method to move the player to the next tile
    private void MovePlayer(Vector3 direction)
    {
        // Calculate the movement distance based on whether the player's movement is doubled
        float distance = isDoubleMove ? tileSize * 2f : tileSize;
        targetPosition = transform.position + direction * distance;
        isMoving = true;

        Debug.Log(isMoving);
        return;

        canMove = true;

    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            // Move towards the target position
            //rb.position = Vector3.MoveTowards(rb.position, targetPosition, movSpeed * Time.fixedDeltaTime);
            //Vector3 force =targetPosition *movSpeed*Time.deltaTime;
            //rb.AddForce(force,ForceMode2D.Impulse);

            rb.MovePosition(Vector2.MoveTowards(rb.position, targetPosition, movSpeed * Time.fixedDeltaTime));

            // Check if reached the target position
            if (Vector3.Distance(rb.position, targetPosition) < 0.01f)
            {
                // Snap to the target position
                rb.position = targetPosition;
                isMoving = false;
                Debug.Log(isMoving);
            }
        }
    }
}
