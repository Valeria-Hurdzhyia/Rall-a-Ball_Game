using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;  // for our text

public class MovePlayer : MonoBehaviour
{
    public float speed = 0; // with this variable we will have possiility to change speed from inspector
    public TextMeshProUGUI countText; // this variable will hold a reference to the UI text component on the CountText GameObject
    public GameObject winTextObject;
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();  //this sets the value of variable rb by getting a reference to the Rigidbody component attached to the player object
        count = 0;
        setCountText();
        winTextObject.SetActive(false);
    }

    // Update is called once per frame
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>(); // this code takes or gets the Vector2 data from the movement value and store it in a Vector2

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void setCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winTextObject.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            setCountText();
        }
    }
}
