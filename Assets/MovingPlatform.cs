using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float moveSpeed = 2f;      
    public float moveRange = 2f;
    public bool horizontalMove = true;
    
    private Vector2 startPosition;
    private Vector2 moveDirection;
    private Rigidbody2D rb;
    private bool movingForward = true;

    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        
        if (horizontalMove) {
            moveDirection = Vector2.right;
        } else {
            moveDirection = Vector2.up;
        }
    }

    void FixedUpdate()
    {
        float currentPosition;
        float startPos;

        // use x/y depending on move dir
        if (horizontalMove) {
            currentPosition = transform.position.x;
            startPos = startPosition.x;
        } else {
            currentPosition = transform.position.y;
            startPos = startPosition.y;
        }

        // move in opposite dir if hit range
        if (movingForward && currentPosition >= startPos + moveRange) {
            movingForward = false;
            moveDirection = horizontalMove ? Vector2.left : Vector2.down;
        } else if (!movingForward && currentPosition <= startPos) {
            movingForward = true;
            moveDirection = horizontalMove ? Vector2.right : Vector2.up;
        }

        rb.velocity = moveDirection * moveSpeed;
    }
}