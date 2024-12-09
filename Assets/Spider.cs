using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{

    public float moveSpeed = 2f;      
    public float moveRange = 2f;
    private Vector2 startPosition;
    private Vector2 moveDirection;
    private Rigidbody2D rb;
    private bool movingForward = true;

    public AudioClip spiderSound;
    private AudioSource audioSource;


    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        moveDirection = Vector2.right;
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        float currentPosition;
        float startPos;

        currentPosition = transform.position.x;
        startPos = startPosition.x;
        
        // move in opposite dir if hit range
        if (movingForward && currentPosition >= startPos + moveRange) {
            movingForward = false;
            moveDirection = Vector2.left;
            transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);

        } else if (!movingForward && currentPosition <= startPos) {
            movingForward = true;
            moveDirection = Vector2.right;
            transform.localScale = new Vector3(-0.4f, 0.4f, 0.4f);
        }

        rb.velocity = moveDirection * moveSpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bunny bunny = collision.gameObject.GetComponent<Bunny>();
        if (bunny != null)
        {
            audioSource.PlayOneShot(spiderSound);
            bunny.ResetPosition();
        }

        Monkey monkey = collision.gameObject.GetComponent<Monkey>();
        if (monkey != null)
        {
            audioSource.PlayOneShot(spiderSound);
            monkey.ResetPosition();
        }

        Turtle turt = collision.gameObject.GetComponent<Turtle>();
        if (turt != null)
        {
            audioSource.PlayOneShot(spiderSound);
            turt.ResetPosition();
        }
    }
}

    