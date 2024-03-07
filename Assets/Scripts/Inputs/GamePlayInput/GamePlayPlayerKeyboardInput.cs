using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GamePlayPlayerKeyboardInput : BaseInput
{
    private Keyboard keyboard;
    public void InitKeyboard(Keyboard _keyboard)
    {
        keyboard = _keyboard;
        iNPUT = INPUT.KEYBOARD;
    }

    private void OnEnable()
    {
        if (inputAction == null)
        {
            inputAction = new Inputs();
            inputAction.GamePlayTeclado.MovPc.performed += Move;
            inputAction.GamePlayTeclado.ActionPc.performed += Enter;
            inputAction.GamePlayTeclado.MenuPc.performed += OpenMenu;
            inputAction.Enable();
        }
    }

    public override void Move(InputAction.CallbackContext context)
    {
        if (context.performed && canMove)
        {
            InputsActions.GamePlayActionMovePC?.Invoke(context.ReadValue<Vector2>());
        }
    }

    public override void Enter(InputAction.CallbackContext context)
    {
        if (context.performed && canMove)
        {
            InputsActions.GamePlayActionEnterPC?.Invoke();
        }
    }

    public override void OpenMenu(InputAction.CallbackContext context)
    {
        if (context.performed && canMove)
        {
            InputsActions.GamePlayActionOpenMenuPC?.Invoke();
        }
    }


    private void OnDisable()
    {
        inputAction.GamePlayTeclado.MovPc.performed -= Move;
        inputAction.GamePlayTeclado.ActionPc.performed -= Enter;
        inputAction.GamePlayTeclado.MenuPc.performed -= OpenMenu;
        inputAction.Disable();
    }
}
