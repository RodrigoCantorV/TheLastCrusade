using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private float inputHorizontal;
    private float inputVertical;
    private Rigidbody rb;
    public Character pJ;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        InputListener();
    }

    void InputListener()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        inputVertical = Input.GetAxis("Vertical");

        if (Input.GetMouseButtonDown(0))
        {
           pJ.LeftAtack();
        }
        if (Input.GetMouseButtonDown(1))
        {
            pJ.RightAtack();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            pJ.SuperPower();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            pJ.Dash();
        }
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        rb.AddRelativeForce(Vector3.forward * inputVertical * pJ.getSpeed(), ForceMode.VelocityChange);
        rb.AddRelativeForce(Vector3.right * inputHorizontal * pJ.getSpeed(), ForceMode.VelocityChange);
        transform.localRotation = Quaternion.Euler(new Vector3(0, -RotationAngle(), 0));
        
    }
    float RotationAngle()
    {
        Vector3 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        Vector3 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        Vector3 direction = mouseOnScreen - positionOnScreen;   

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg ;

        return angle;
    }
}