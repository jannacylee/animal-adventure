using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    /// <summary>
    /// AudioClip for entering water
    /// </summary>
    /// <summary>
    /// AudioSource for water
    /// </summary>
    public AudioSource audioSource;
    private float splashCd = 0;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

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
            if (!turt.Swimming)
            {
                turt.Swim(true);
                if (splashCd < Time.time)
                {
                    audioSource.Play();
                    splashCd = Time.time + 1f;
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Turtle turt = collision.GetComponent<Turtle>();
        if (turt != null)
        {
            turt.Swim(false);
        }
    }
}
