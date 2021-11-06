using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;  // this will reference the player GameObject's position
    private Vector3 offset; // this will store the offset value
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position; 
    }

    // Update is called once per frame
    void LateUpdate() // the Update could run before other scripts. LateUpdate runs every frame just like Update, but will run after all of the other updates are done
    {
        transform.position = player.transform.position + offset; // now when a player moves the sphere with controls on the keyboard, the frame before displaying the camera, the camera GameObject is moved into a new position aligned with the player GameObject before the frame is displayed
    }
}
