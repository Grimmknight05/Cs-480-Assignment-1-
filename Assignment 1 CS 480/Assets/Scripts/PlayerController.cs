using Unity.VisualScripting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb; //Ref to rigidbody
    private float moveX; //X Movement variable
    private float moveY; //Y Movement variable

    void Start()
    {
        rb = GetComponent<Rigidbody>(); //Uses GetComponent to set rd to Rigidbody component
    }
    void OnMove(InputValue movementValue)//On any movement?
    {
        Vector2 movementVector = movementValue.Get<Vector2>();//Getting movement direction from movementValue param, and set it to Vector2 movementVector; (x,y)
        moveX = movementVector.x; // extract x from movementVector (x,y) make avalable to rest of code
        moveY = movementVector.x; // extract y from movementVector (y,x) make avalable to rest of code 
    }
    void Update()
    {

    }
    void FixedUpdate()//Fixed interval update ensures physics is consistant regaurdless of framerate
    {
        //Construct movement vector3
        Vector3 movement = new Vector3(moveX, 0.0f, moveY); // Asign new Vector3(x,z,y) with moveX and moveY input, and no z input
        //
        rb.AddForce(movement);
    }
}
