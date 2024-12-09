using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Monkey : MonoBehaviour
{
    /// <summary>
    /// RigidBody of the monkey
    /// </summary>
    public Rigidbody2D rb;

    /// <summary>
    /// Starting posn of the player, to respawn if the monkey dies
    /// </summary>
    public Vector3 StartingPosition;

    /// <summary>
    /// Moving velocity of the monkey
    /// </summary>
    private float RunVelocity = 5;

    /// <summary>
    /// Interval to time jumps
    /// </summary>
    private float JumpTimer = 0;
    private float climbCd = 0;

    /// <summary>
    /// AudioClip for dying
    /// </summary>
    public AudioClip DeathAudio;

    /// <summary>
    /// AudioSource for the Monkey
    /// </summary>
    public AudioSource AudioSource;

    /// <summary>
    /// Boolean telling us if the monkey is climbing or not
    /// </summary>
    public bool Climbing;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartingPosition = transform.position;
        AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ClimbCheck();
        if (!Climbing)
        {
            Move();
        }
    }
    void Update()
    {
        ClimbCheck();
        if (Climbing)
        {
            Climb();
        }
    }

    ///
    /// Reset the position of the monkey, if they DIED rip
    ///
    public void ResetPosition()
    {
        AudioSource.PlayOneShot(DeathAudio);
        transform.position = StartingPosition;
    }

    ///
    /// Manoeuvre the monkey, either jumping or running
    ///
    void ClimbCheck()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, new Vector2(.2f, 1), 0);

        bool vine = false;
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Vine"))
            {
                vine = true;
            }
        }
        if(vine == true && Input.GetKey(KeyCode.G))
        {
            if(climbCd < Time.time)
            {
                climbCd = Time.time + 1;
                AudioSource.Play();
            }
            Climbing = true;
            return;
        }
        Climbing = false;
    }

    void Climb()
    {
        rb.gravityScale = 0;
        rb.velocity = Vector3.zero;
        int down = Input.GetKey(KeyCode.S) == true ? 1 : 0;
        int up = Input.GetKey(KeyCode.W) == true ? 1 : 0;
        transform.Translate((Vector3.down * (int) down  + Vector3.up *up) * Time.deltaTime);
    }
    void Move()
    {
        rb.gravityScale = 1;
        bool right = Input.GetKey(KeyCode.D);
        bool left = Input.GetKey(KeyCode.A);
        bool jump = Input.GetKey(KeyCode.W);

        int horizontal = 0;
        int vertical = 0;

        if (right)
        {
            horizontal = 1;
            transform.localScale = new Vector3(0.3f, 0.3f,  0.3f); // facing right
        }

        if (left)
        {
            horizontal = -1;
            transform.localScale = new Vector3(-0.3f,  0.3f,  0.3f); // facing left
        }

        if (jump && JumpTimer < Time.time)
        {
            vertical = 25;
            JumpTimer = Time.time + 1;
        }

        Vector2 movement = new Vector2(horizontal * RunVelocity, vertical * RunVelocity);
        rb.AddForce(movement);
    }

    ///
    /// Reset the position of the bunny if ran off screen
    ///
    void OnBecameInvisible()
    {
        ResetPosition();
    }

}
