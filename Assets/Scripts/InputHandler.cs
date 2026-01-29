using UnityEngine;
using UnityEngine.InputSystem;


public class InputHandler : MonoBehaviour
{
    private MyInputActions _inputActions;
    Camera _mainCam;
    [SerializeField] public LayerMask layerToClickOn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _mainCam = Camera.main;
        _inputActions = new MyInputActions();
        _inputActions.Player.Click.performed += Clicked;
        _inputActions.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Player.Click.performed -= Clicked;
        _inputActions.Enable();
    }

    private void Clicked(InputAction.CallbackContext value)
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();

        RaycastHit hit;
        Ray rayOrigin = _mainCam.ScreenPointToRay(mousePos);
        if(Physics.Raycast(rayOrigin, out hit,layerToClickOn))
        {
            Debug.Log("clicked on card");
            Card c =  hit.collider.GetComponent<Card>();
            c.SetSelected();
            
        }
        //to do
        //Raycast screen to world from mousepos
        //Check first hit object to see if it can be clicked.
    }
}
