using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerControllerScript : MonoBehaviour
{
    private PlayerScript playerScript;
    private PlayerMovementScript playerMovementScript;
    private Rigidbody2D playerRigidbody2D;
    private GameObject player;

    
    public InputActionReference move; //what even is move?
    public UnityEvent MoveUp;
    public UnityEvent MoveDown;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ConnectReferences();
        ConnectEvents();
        //I might not even need this script
    }
    /*WARNING! I'm aware that I probably could be using BroadcastMessages instead of sending unecessary events. 
     * I chose not to because I saw the superiority in using SendMessages (its easier for me for some reason)*/
    private void ConnectEvents()
    {
        MoveUp.AddListener(playerMovementScript.MovePlayerUp);
        MoveDown.AddListener(playerMovementScript.MovePlayerDown);
    }
    private void ConnectReferences()
    {
        player = transform.parent.gameObject;
        playerRigidbody2D = player.GetComponent<Rigidbody2D>();
        playerScript = player.GetComponent<PlayerScript>();
        playerMovementScript = player.GetComponentInChildren<PlayerMovementScript>(); 
    }
    public void OnUp()
    {
        Debug.Log("OnUp fired!");
        MoveUp.Invoke();
    }
    public void OnDown()
    {
        Debug.Log("OnDown fired!");
        MoveDown.Invoke();
    }
  
}
