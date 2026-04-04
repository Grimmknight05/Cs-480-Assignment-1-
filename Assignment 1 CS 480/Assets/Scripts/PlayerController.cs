using Unity.VisualScripting;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*Variables*/
    private Rigidbody rb; //Ref to rigidbody
    private float moveX; //X Movement variable
    private float moveY; //Y Movement variable
    public float playerSpeed = 5;//Speed of character movement Default 5
    public TextMeshProUGUI countText; //Referance to Score UI element
    private int playerPoints; //Storing score per player
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //Uses GetComponent to set rd to Rigidbody component
        setPlayerScore();// update UI
    }
    void OnMove(InputValue movementValue)//On any movement?
    {
        Vector2 movementVector = movementValue.Get<Vector2>();//Getting movement direction from movementValue param, and set it to Vector2 movementVector; (x,y)
        moveX = movementVector.x; // extract x from movementVector (x,y) make avalable to rest of code
        moveY = movementVector.y; // extract y from movementVector (y,x) make avalable to rest of code 
    }
    void setPlayerScore()//Displays player's score on UI
    {
        countText.text = "Score: " + playerPoints.ToString();
    }
    void OnTriggerEnter(Collider other)//execute once on trigger
    {
        if(other.gameObject.CompareTag("PickUp"))//If pickup
        {
            other.gameObject.SetActive(false); //disable pickup
            playerPoints += other.gameObject.GetComponent<PickUpDefault>().points;//chack pickups point value stored in PickUpDefault script
            print("PlayerPoints: " + playerPoints);//Debug
            setPlayerScore();// update UI

        }
    }
        

    void FixedUpdate()//Fixed interval update ensures physics is consistant regaurdless of framerate
    {
        //Construct movement vector3
        Vector3 movement = new Vector3(moveX, 0.0f, moveY); // Asign new Vector3(x,z,y) with moveX and moveY input, and no z input
        //Add force to player in cormovement
        rb.AddForce(movement * playerSpeed);//multiply movement Vector3 by playerSpeed varible
    }
}
