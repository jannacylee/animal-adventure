using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : MonoBehaviour
{ 
    /// <summary>
    /// RigidBody of the turtle
    /// </summary>
    public Rigidbody2D RigidBody;

    /// <summary>
    /// Starting posn of the player, to respawn if the turtle dies
    /// </summary>
    public Vector3 StartingPosition;

    /// <summary>
    /// Moving velocity of the turtle
    /// </summary>
    private float WalkVelocity = 3.5f;

    /// <summary>
    /// AudioClip for dying
    /// </summary>
    public AudioClip DeathAudio;

    /// <summary>
    /// AudioSource for the turtle
    /// </summary>
    public AudioSource AudioSource;

    /// <summary>
    /// Boolean telling us if the turtle is in water or not
    /// </summary>
    public bool Swimming;

    private float JumpTimer = 0;


    // Start is called before the first frame update
    void Start()
    {
        RigidBody = GetComponent<Rigidbody2D>();
        StartingPosition = transform.position;
        AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    ///
    /// Reset the position of the turtle
    ///
    public void ResetPosition()
    {
        AudioSource.PlayOneShot(DeathAudio);
        transform.position = StartingPosition;
    }

    ///
    /// Manoeuvre the turtle, by running/swimming
    ///
    void Move()
    {
        bool left = Input.GetKey(KeyCode.A);
        bool right = Input.GetKey(KeyCode.D);
        bool jump = Input.GetKey(KeyCode.W);
        int vertical = 0;

        float horizontal = 0;

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

        if (Swimming)
        {
            RigidBody.gravityScale = -0.3f;

            if (jump && JumpTimer < Time.time)
            {
                vertical = 175;
                JumpTimer = Time.time + 1;
            }
            horizontal = horizontal * 1.5f;
        }
        else RigidBody.gravityScale = 1f;

        Vector2 movement = new Vector2(horizontal * WalkVelocity, 1+vertical);
        RigidBody.AddForce(movement);
    }
    public void Swim(bool status)
    {
        Swimming = status;
    }

    ///
    /// Reset the position of the turtle if off screen
    ///
    void OnBecameInvisible()
    {
        ResetPosition();
    }

}

