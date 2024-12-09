using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    /// AudioClip for jumping
    /// </summary>

    /// <summary>
    /// AudioClip for dying
    /// </summary>
    public AudioClip DeathAudio;

    /// <summary>
    /// AudioSource for the Bunny
    /// </summary>
    public AudioSource AudioSource;

    public AudioClip JumpAudio;

    private float coolDown = 0;

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
    void FixedUpdate()
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
        bool superjump = Input.GetKey(KeyCode.G);

        int horizontal = 0;
        int vertical = 0;

        Vector2 rayOrigin = new Vector2(transform.position.x, transform.position.y - .5f);

        if (right)
        {
            horizontal = 1;
            transform.localScale = new Vector3(0.2f, 0.2f,  0.2f); // facing right
        }

        if (left)
        {
            horizontal = -1;
            transform.localScale = new Vector3(-0.2f, 0.2f,  0.2f); // facing left
        }

        if (jump && coolDown < Time.time)
        {
            vertical = 10;
            AudioSource.PlayOneShot(JumpAudio);
            coolDown = Time.time + 0.5f;
        }

        if(superjump && coolDown < Time.time)
        {
            vertical = 40;
            AudioSource.PlayOneShot(JumpAudio);
            coolDown = Time.time + 2f;
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
