using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorn : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bunny bunny = collision.gameObject.GetComponent<Bunny>();
        if (bunny != null)
        {
            bunny.ResetPosition();
        }
        Monkey monkey = collision.gameObject.GetComponent<Monkey>();
        if (monkey != null)
        {
            monkey.ResetPosition();
        }
        Turtle turt = collision.gameObject.GetComponent<Turtle>();
        if (turt != null)
        {
            turt.ResetPosition();
        }
    }
}

    

