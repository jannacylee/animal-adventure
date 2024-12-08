using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Monkey : MonoBehaviour
{
    /// <summary>
    /// RigidBody of the monkey
    /// </summary>
    public Rigidbody2D RigidBody;

    /// <summary>
    /// Starting posn of the player, to respawn if the monkey dies
    /// </summary>
    public Vector3 StartingPosition;

    /// <summary>
    /// Moving velocity of the monkey
    /// </summary>
    private float RunVelocity = 5;

    /// <summary>
    /// AudioClip for jumping
    /// </summary>
    public AudioClip JumpAudio;

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

    /// <summary>
    /// Boolean to see if the player is on ground
    /// </summary>
    private bool isGrounded = false;


    // Start is called before the first frame update
    void Start()
    {
        RigidBody = GetComponent<Rigidbody2D>();
        StartingPosition = transform.position;
        AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
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
    void Move()
    {
        bool right = Input.GetKey(KeyCode.D);
        bool left = Input.GetKey(KeyCode.A);
        bool jump = Input.GetKey(KeyCode.W);

        int horizontal = 0;
        int vertical = 0;

        Vector2 rayOrigin = new Vector2(transform.position.x, transform.position.y - .5f);
        isGrounded = Physics2D.Raycast(rayOrigin, Vector2.down, .2f);

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

        if (jump && isGrounded)
        {
            vertical = 25;
        }

        Vector2 movement = new Vector2(horizontal * RunVelocity, vertical * RunVelocity);
        RigidBody.AddForce(movement);

        isGrounded = false;
    }

    ///
    /// Reset the position of the bunny if ran off screen
    ///
    void OnBecameInvisible()
    {
        ResetPosition();
    }

}
