using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    private PlayerScript playerScript;
    private Rigidbody2D playerRigidbody;
    private GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ConnectReferences();
    }

    private void ConnectReferences()
    {
        player = gameObject.transform.parent.gameObject;
        playerScript = player.GetComponent<PlayerScript>();
        playerRigidbody = player.GetComponent<Rigidbody2D>();
    }
    public void MovePlayerUp() //broadcasted from the PlayerController PlayerInput Component
    {
        //lol new input system
        /*so because we have playerInput (component) . behavior set to Send Messages, it'll
         * send a default action to On{nameofinput}
          */
        /* I want this mostly just to send inputs, so I'll change it to fire actions direction which
         will be called in PlayerMovementScript*/
        playerRigidbody.linearVelocityY = playerScript.PlayerSpeed;
        Debug.Log("Up");
    }
    public void MovePlayerDown()
    {
        playerRigidbody.linearVelocityY = playerScript.PlayerSpeed;
        Debug.Log("Down");
    }
}
