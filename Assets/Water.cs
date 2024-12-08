using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    /// <summary>
    /// AudioClip for entering water
    /// </summary>
    public AudioClip SPLASH;

    /// <summary>
    /// AudioSource for water
    /// </summary>
    public AudioSource AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bunny bunny = collision.GetComponent<Bunny>();
        if (bunny != null)
        {
            bunny.ResetPosition();
        }
        Monkey monkey = collision.GetComponent<Monkey>();
        if (monkey != null)
        {
            monkey.ResetPosition();
        }
        Turtle turt = collision.GetComponent<Turtle>();
        if (turt != null)
        {
            AudioSource.PlayOneShot(SPLASH);
        }
    }
}
