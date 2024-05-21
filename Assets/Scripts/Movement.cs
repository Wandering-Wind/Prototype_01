using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private bool canMove = true;
    private float movementCooldown = 2f;
    private float cooldownTimer = 0f;
    private bool isDoubleMove = false;

    public float tileSize = 1.25f;
    private Vector3 targetPosition;

    private TurnManager turnManager;
    private PowerUpManager powerUpManager;

    public GameObject extraMoveIndicator; // Reference to the extra move indicator UI element
    public float indicatorDisplayTime = 2f; // Time to display the indicator

    void Start()
    {
        targetPosition = transform.position;
        turnManager = FindObjectOfType<TurnManager>();
        powerUpManager = FindObjectOfType<PowerUpManager>();

        if (extraMoveIndicator != null)
        {
            extraMoveIndicator.SetActive(false); // Ensure the indicator is hidden at the start
        }
    }

    void Update()
    {
        if (!enabled) return;

        if (!canMove)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0f)
            {
                canMove = true;
            }
        }

        if (canMove)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow)) MovePlayer(Vector3.up);
            else if (Input.GetKeyDown(KeyCode.DownArrow)) MovePlayer(Vector3.down);
            else if (Input.GetKeyDown(KeyCode.LeftArrow)) MovePlayer(Vector3.left);
            else if (Input.GetKeyDown(KeyCode.RightArrow)) MovePlayer(Vector3.right);
        }
    }

    private void MovePlayer(Vector3 direction)
    {
        if (canMove)
        {
            float distance = isDoubleMove ? tileSize * 2f : tileSize;
            targetPosition += direction * distance;
            canMove = false;
            StopMovement(movementCooldown);

            if (turnManager != null)
            {
                turnManager.RegisterMove();
            }
        }
    }

    void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PowerUp"))
        {
            if (powerUpManager != null)
            {
                powerUpManager.RemovePowerUp(collision.gameObject); // Remove the power-up from the active list
            }

            Destroy(collision.gameObject);
            Debug.Log("Power-up collected! Extra move granted.");
            ShowExtraMoveIndicator(); // Display the indicator
            if (turnManager != null)
            {
                turnManager.AddExtraMove(); // Grant an extra move
            }
        }
    }

    private void ShowExtraMoveIndicator()
    {
        if (extraMoveIndicator != null)
        {
            extraMoveIndicator.SetActive(true);
            Invoke("HideExtraMoveIndicator", indicatorDisplayTime);
        }
    }

    private void HideExtraMoveIndicator()
    {
        if (extraMoveIndicator != null)
        {
            extraMoveIndicator.SetActive(false);
        }
    }

    public void StopMovement(float duration)
    {
        canMove = false;
        cooldownTimer = duration;
    }

    public void SetDoubleMove(bool isDouble)
    {
        isDoubleMove = isDouble;
    }
}
