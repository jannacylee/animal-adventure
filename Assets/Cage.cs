using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    /// <summary>
    /// Public audio to play when you win
    /// </summary>
    public AudioClip WinAudio;

    /// <summary>
    /// Audiosource for the finish object
    /// </summary>
    public AudioSource AudioSource;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bunny bunny = collision.gameObject.GetComponent<Bunny>();
        Monkey monkey = collision.gameObject.GetComponent<Monkey>();
        Turtle turt = collision.gameObject.GetComponent<Turtle>();
        if (bunny != null || monkey != null || turt != null)
        {
            AudioSource.PlayOneShot(WinAudio);
        }
    }
}
