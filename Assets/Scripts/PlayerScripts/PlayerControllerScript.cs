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

    
    public InputActionReference up; //what even is move?
    public InputActionReference down;
    private bool lastUp;
    private bool lastDown;
    public delegate void PlayerMoveDirection(int upOrdown, bool isPressed); //1 up, 0 stasis, -1 down
    public PlayerMoveDirection OnPlayerMoveDirectionSet;
    public UnityEvent MoveUp;
    public UnityEvent MoveDown;
    


    //Input.GetKeyDown = action.WasPressedThisFrame(); true for a single frame after being pressed
    //Input.GetKey = action.IsPressed(); true every frame while being held
    //Input.GetKeyUp = action.WasReleasedThisFrame(); true the frame it was released
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ConnectReferences();
        ConnectEvents();
        //I might not even need this script
    }
    void Update()
    {
        KeyboardInputHandler();
    }

    /*WARNING! I'm aware that I probably could be using BroadcastMessages instead of sending unecessary events. 
     * I chose not to because I saw the superiority in using SendMessages (its easier for me for some reason)*/
    private void ConnectEvents()
    {
        //MoveUp.AddListener(playerMovementScript.MovePlayerUp);
        //MoveDown.AddListener(playerMovementScript.MovePlayerDown);
    }
    private void ConnectReferences()
    {
        player = transform.parent.gameObject;
        playerRigidbody2D = player.GetComponent<Rigidbody2D>();
        playerScript = player.GetComponent<PlayerScript>();
        playerMovementScript = player.GetComponentInChildren<PlayerMovementScript>(); 
    }
    private void KeyboardInputHandler()
    {
        if(up.action.IsPressed() && up.action.IsPressed() != lastUp) //if a new input is detected and the up button is pressed
        {
            Debug.Log($"up.action.IsPressed() = {up.action.IsPressed()}");
            OnPlayerMoveDirectionSet.Invoke(1, up.action.IsPressed());
        }
        else if (!up.action.IsPressed() && up.action.IsPressed() != lastUp)
        {
            Debug.Log($"up.action.IsPressed() = {up.action.IsPressed()}");
            OnPlayerMoveDirectionSet.Invoke(0, up.action.IsPressed());

        }
        if (down.action.IsPressed() && down.action.IsPressed() != lastDown) //if a new input is detected and the down button is pressed
        {
            Debug.Log($"down.action.IsPressed() = {down.action.IsPressed()}");
            OnPlayerMoveDirectionSet.Invoke(-1, down.action.IsPressed());
        }
        else if (!down.action.IsPressed() && down.action.IsPressed() != lastDown)
        {
            //if a new input is detected and the down button isn't pressed
            Debug.Log($"down.action.IsPressed() = {down.action.IsPressed()}");
            OnPlayerMoveDirectionSet.Invoke(0, down.action.IsPressed());
        }
        lastUp = up.action.IsPressed();
        lastDown = down.action.IsPressed();
    }
    public void OnUp(InputAction.CallbackContext dos) //I'm not quite sure what an InputActionMap is
    {
        //dos is temporary
        
        //if (dos.performed)
        //{
        //    //Debug.Log("OnDown fired!");
        //    //Debug.Log($"dos.started = {dos.started}, dos.performed = {dos.performed}, dos.canceled = {dos.canceled}");
        //    //Debug.Log($"dos.action.IsPressed() = {dos.action.IsPressed()}");
        //    OnPlayerMoveDirectionSet.Invoke(1, dos.action.IsPressed());
        //}
       

    }
    public void OnDown(InputAction.CallbackContext context)
    {
        //but I don't want to know while its fired... I want to know while it is held
        
        //MoveDown.Invoke(); // is this being fired?
        //if (context.performed)
        //{
        //    //Debug.Log("OnDown fired!");
        //    //Debug.Log($"context.started = {context.started}, context.performed = {context.performed}, context.canceled = {context.canceled}");
        //    //Debug.Log($"context.action.IsPressed() = {context.action.IsPressed()}");
        //    OnPlayerMoveDirectionSet.Invoke(-1, context.action.IsPressed());
        //}
        


    }
  
}
