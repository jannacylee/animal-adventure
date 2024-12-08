using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public Transform cameraTransform; 
    public float parallaxFactor = 0.5f;
    private Vector3 lastCameraPosition; 

    void Start() {
       lastCameraPosition = cameraTransform.position;
    }

    void Update() {
        Vector3 movement = cameraTransform.position - lastCameraPosition;
       transform.position += new Vector3(movement.x * parallaxFactor, movement.y * parallaxFactor, 0); // moves with camera, but @ parallax factor
       lastCameraPosition = cameraTransform.position;
    }
}
