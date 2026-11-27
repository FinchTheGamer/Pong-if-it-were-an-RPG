using System.Collections;
using NUnit.Framework.Constraints;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    private PlayerScript playerScript;
    private PlayerControllerScript playerControllerScript;
    private Rigidbody2D playerRigidbody;
    private GameObject player;
    private Hashtable InputToValue;
    private int playerMoveDirection;
    private bool doesPlayerWantToGoUp = false; //true is up, false is down 
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ConnectReferences();
        //broo I can't even make a player move anymore
    }
    void Update()
    {
        MovementHandler();

        //why don't we just get when it is held
    }
    private void ConnectReferences()
    {
        player = gameObject.transform.parent.gameObject;
        playerScript = player.GetComponent<PlayerScript>();
        playerControllerScript = player.GetComponentInChildren<PlayerControllerScript>();
        playerRigidbody = player.GetComponent<Rigidbody2D>();

        playerControllerScript.OnPlayerMoveDirectionSet += MovePlayerUpOrDown;
    }

    private void MovementHandler()
    {
        //if (doesPlayerWantToGoUp)
        //{
        //    playerMoveDirection = 1;
        //}
        //else if (!doesPlayerWantToGoUp)
        //{
        //    playerMoveDirection = -1; //is that more inefficient?
        //}
        playerRigidbody.linearVelocity = new Vector2(playerRigidbody.linearVelocityX, playerMoveDirection * playerScript.PlayerSpeed); //wait is creating a new object every second expensive
        //Debug.Log($"playerMoveDirection = {playerMoveDirection}");
    }
    public void MovePlayerUp() //broadcasted from the PlayerController PlayerInput Component
    {
        //lol new input system
        /*so because we have playerInput (component) . behavior set to Send Messages, it'll
         * send a default action to On{nameofinput}
          */
        /* I want this mostly just to send inputs, so I'll change it to fire actions direction which
         will be called in PlayerMovementScript*/
        /*New solution: what if we set the move direction to up?*/
        //doesPlayerWantToGoUp = true;
        /*so if we imagine the old input system for a second
        /we need to get 1 or -1 if any input is pressed along the vertical (W-S or UpKey-DownKey) axis
         I think the hardest part would be getting zero*/

        //lol forgot about the boolean
    }
    public void MovePlayerDown()
    {
        //playerRigidbody.linearVelocityY = -(playerScript.PlayerSpeed);
        //each time this is received, it makes the player once more move
        //Debug.Log("Down");
        //I'm still hoarding old code
        //playerMoveDirection = new Vector2(playerRigidbody.linearVelocityX, playerRigidbody.linearVelocityY - 1);
        //doesPlayerWantToGoUp = false;
    }
    private void MovePlayerUpOrDown(int dir, bool isPressed)
    {
         //ugh OKay little steppe little steppe (i'm aware that is closer to the landscape of central asia than a "step")
        //we are going to use isPressed to check
        if(isPressed)
        {
            playerMoveDirection = dir;
        }
        else
        {
            playerMoveDirection = 0;
        }
        //for somereason, it isn't being reset to 0 when down?
    }
}
