using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Vehicle attributes")]
    private Rigidbody playerRb;

    [SerializeField]private float speed;
    [SerializeField]private float rpm;
    [SerializeField] private float horsePower = 0;
    private float turnSpeed = 50;
    private float horizontalInput;
    private float fowardInput;

    public string inputID;

    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;

    [Header("Camera")]
    public Camera mainCamera;
    public Camera insideCamera;
    public KeyCode switchKey;

    [Header("Text")]
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rpmText;

    


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 3.6f);
        speedometerText.SetText("Speed: " + speed + "km/h");

        rpm = Mathf.Round((speed % 30) * 40);
        rpmText.SetText(rpm + "RPM");

        if (Input.GetKeyDown(switchKey))
        {
            mainCamera.enabled = !mainCamera.enabled;
            insideCamera.enabled = !insideCamera.enabled;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isOnGround())
        {
            horizontalInput = Input.GetAxis("Horizontal" + inputID);
            fowardInput = Input.GetAxis("Vertical" + inputID);

            //transform.Translate(Vector3.forward * Time.deltaTime * speed * fowardInput);
            playerRb.AddRelativeForce(Vector3.forward * horsePower * fowardInput);
            transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        }        
    }

    bool isOnGround()
    {
        wheelsOnGround = 0;

        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }            
        }

        if (wheelsOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
