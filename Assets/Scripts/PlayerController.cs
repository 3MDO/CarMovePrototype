using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    //private variables
    [SerializeField] float speed = 10.0f; //protected // const float dersek herhangi bir ?ekilde de?i?tiremiyoruz //readonly //static
    [SerializeField] private float horsePower = 0;
    [SerializeField] float rpm;
    private const float turnSpeed = 25.0f;
    private float horizantalInput;
    private float verticalInput;
    private Rigidbody playerRb;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;
     
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    void FixedUpdate() //fixedupdate update den önce ça??r?l?yor genellikle hareket ile ilgili ?eyleri yap?yoruz 
    {
        // this is where we get player input 
        horizantalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (IsOnGround())
        {
            // we will move the vehicle forward
            //transform.Translate(0, 0, 1); // arac?m?z z yönünde süreklihareket etmesini sa?l?yor // transform.Translate(Vector3.forward);     ikiside benzer e
            ////transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);//speedi sildik diye kullanmıyoruz 
            playerRb.AddRelativeForce(Vector3.forward * horsePower * verticalInput);
            //we turn the vehicles
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizantalInput);

            speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 2.237f); // for kph ,change 3.6
            speedometerText.SetText("Speed: " + speed + "mph");

            rpm = (speed % 30) * 40;
            rpmText.SetText("RPM: " + rpm);
        }
    }

    bool IsOnGround()
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
