using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour

{
    private float hoverRange = 0.1f;
    private float hoverSpeed = 5f;
    public AudioClip appleSound;
    private Vector3 startPosition;
    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        audioSource = GetComponent<AudioSource>();
    }
        

    // Update is called once per frame
    void Update()
    {
        float hover = Mathf.Sin(Time.time * hoverSpeed) * hoverRange;
        transform.position = startPosition + Vector3.up * hover;
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            Collect();
        }
    }

    private void Collect() {
        audioSource.PlayOneShot(appleSound);
        Destroy(gameObject, appleSound.length);
    }
}

