using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public enum INPUT : int
{
    KEYBOARD, GAMEPAD, JOYSTICK
}

public class BaseInput : MonoBehaviour
{
    [SerializeField]
    protected InputActionAsset inputActionAsset;

    protected Inputs inputAction;

    protected bool canMove = true;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public virtual void Move(InputAction.CallbackContext context)
    {
        if (context.performed && canMove)
        {
            InputsActions.menuActionMove?.Invoke(context.ReadValue<Vector2>());
        }
    }

    public virtual void Enter(InputAction.CallbackContext context)
    {
        if (context.performed && canMove)
        {
            InputsActions.MenuActionEnter?.Invoke();
        }
    }

    public virtual void StartButton(InputAction.CallbackContext context)
    {
        if (context.performed && canMove)
        {
            InputsActions.StartActionEnter?.Invoke();
        }
    }

    public void BlockInput()
    {
        canMove = false;
    }

    public void ReleaseInput()
    {
        canMove = true;
    }
}
