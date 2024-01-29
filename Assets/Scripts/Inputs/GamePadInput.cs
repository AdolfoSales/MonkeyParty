using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GamePadInput : BaseInput
{
    private Gamepad gamePad;

    public void InitGamePad(Gamepad _gamePad)
    {
        gamePad = _gamePad;
    }

    private void OnEnable()
    {
        if (inputAction == null)
        {
            inputAction = new Inputs();
            inputAction.MenuMando.Mov.performed += Move;
            inputAction.MenuMando.Selection.performed += Enter;
            inputAction.MenuMando.Start.performed += StartButton;
            inputAction.Enable();
        }
    }


    private void OnDisable()
    {
        inputAction.MenuMando.Mov.performed -= Move;
        inputAction.MenuMando.Selection.performed -= Enter;
        inputAction.MenuMando.Start.performed -= StartButton;
        inputAction.Disable();
    }
}
