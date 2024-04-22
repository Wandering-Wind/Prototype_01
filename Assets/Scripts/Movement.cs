using UnityEngine;

public class Movement : MonoBehaviour
{
    // Basic movement parameters
    public float movSpeed;
    float speedX, speedY;
    Rigidbody2D rb;

    // Tile-based movement parameters
    public float tileSize = 1.25f;
    private Vector3 targetPosition;
    private bool isMoving;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetPosition = transform.position;
    }

    void Update()
    {
        // Basic movement
        speedX = Input.GetAxisRaw("Horizontal") * movSpeed;
        speedY = Input.GetAxisRaw("Vertical") * movSpeed;
        rb.velocity = new Vector3(speedX, speedY);

        // Tile-based movement
        if (!isMoving)
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

    // Method to move the player to the next tile
    private void MovePlayer(Vector3 direction)
    {
        targetPosition = transform.position + direction * tileSize;
        isMoving = true;
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            // Move towards the target position
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movSpeed * Time.fixedDeltaTime);

            // Check if reached the target position
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                // Snap to the target position
                transform.position = targetPosition;
                isMoving = false;
            }
        }
    }
}
