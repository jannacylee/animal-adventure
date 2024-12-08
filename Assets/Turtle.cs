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
    private float WalkVelocity = 2;

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

        int horizontal = 0;

        if (right)
        {
            horizontal = 1;
        }

        if (left)
        {
            horizontal = -1;
        }

        if (Swimming)
        {
            horizontal = horizontal * 4;
        }

        Vector2 movement = new Vector2(horizontal * WalkVelocity, 1);
        RigidBody.AddForce(movement);
    }

    ///
    /// Reset the position of the turtle if off screen
    ///
    void OnBecameInvisible()
    {
        ResetPosition();
    }

}

