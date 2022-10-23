using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public GameObject fingerOne;
    public GameObject fingerTwo;
    private TouchControls touchControls;
    private Vector2 fingerOneStart;
    private Vector2 fingerTwoStart;
    private bool finger1Touch = false;
    private bool finger2Touch = false;

    private void Awake()
    {
        touchControls = new TouchControls();
    }

    private void OnEnable()
    {
        touchControls.Enable();
    }

    private void OnDisable()
    {
        touchControls.Disable();
    }

    private void Start()
    {
        fingerOneStart = fingerOne.transform.position;
        fingerTwoStart = fingerTwo.transform.position;
        touchControls.Touch.TouchPress.started += ctx => StartTouch(ctx);
        touchControls.Touch.TouchPress.canceled += ctx => EndTouch(ctx);
        touchControls.Touch.TouchPress1.started += ctx => StartTouch1(ctx);
        touchControls.Touch.TouchPress1.canceled += ctx => EndTouch1(ctx);
    }

    private void Update()
    {
        if (finger1Touch)
        {
            fingerOne.transform.position = Camera.main.ScreenToWorldPoint(touchControls.Touch.TouchPosition.ReadValue<Vector2>());
        }
        if (finger2Touch)
        {
            fingerTwo.transform.position = Camera.main.ScreenToWorldPoint(touchControls.Touch.TouchPosition1.ReadValue<Vector2>());
        }
       
        
    }

    private void StartTouch(InputAction.CallbackContext context)
    {
        finger1Touch = true;
    }

    private void EndTouch(InputAction.CallbackContext context)
    {
        finger1Touch = false;
        fingerOne.transform.position = fingerOneStart;
    }

    private void StartTouch1(InputAction.CallbackContext context)
    {
        finger2Touch = true;
    }

    private void EndTouch1(InputAction.CallbackContext context)
    {
        finger2Touch = false;
        fingerTwo.transform.position = fingerTwoStart;
    }
}
