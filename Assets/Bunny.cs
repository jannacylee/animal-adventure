using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Bunny : MonoBehaviour
{
    /// <summary>
    /// RigidBody of the bunny
    /// </summary>
    public Rigidbody2D RigidBody;

    /// <summary>
    /// Starting posn of the player, to respawn if the bunny dies
    /// </summary>
    public Vector3 StartingPosition;

    /// <summary>
    /// Moving velocity of the bunny
    /// </summary>
    private float RunVelocity = 10;

    /// <summary>
    /// Interval to time jumps
    /// </summary>
    private float JumpTimer = 0;

    /// <summary>
    /// AudioClip for jumping
    /// </summary>
    public AudioClip JumpAudio;

    /// <summary>
    /// AudioClip for dying
    /// </summary>
    public AudioClip DeathAudio;

    /// <summary>
    /// AudioSource for the Bunny
    /// </summary>
    public AudioSource AudioSource;


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
    /// Reset the position of the bunny, if they DIED rip
    ///
    public void ResetPosition()
    {
        AudioSource.PlayOneShot(DeathAudio);
        transform.position = StartingPosition;
    }

    ///
    /// Manoeuvre the bunny, either jumping or running
    ///
    void Move()
    {
        bool right = Input.GetKey(KeyCode.D);
        bool left = Input.GetKey(KeyCode.A);
        bool jump = Input.GetKey(KeyCode.W);

        int horizontal = 0;
        int vertical = 0;

        if (right)
        {
            horizontal = 1;
        }

        if (left)
        {
            horizontal = -1;
        }

        if (jump && JumpTimer < Time.time)
        {
            vertical = 50;
            JumpTimer = Time.time + 2;
        }

        Vector2 movement = new Vector2(horizontal * RunVelocity, vertical * RunVelocity);
        RigidBody.AddForce(movement);
    }

    ///
    /// Reset the position of the bunny if ran off screen
    ///
    void OnBecameInvisible()
    {
        ResetPosition();
    }

}
