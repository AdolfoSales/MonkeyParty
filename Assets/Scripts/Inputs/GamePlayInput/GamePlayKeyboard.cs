using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GamePlayKeyboard : BaseInput
{
    private Keyboard keyboard;

    //private Vector2 movementInput;


    private void Awake()
    {
        iNPUT = INPUT.KEYBOARD;
    }

    private void OnEnable()
    {
        if (inputAction == null)
        {
            inputAction = new Inputs();
            inputAction.GamePlayTeclado.MovPc.performed += Move;
            inputAction.GamePlayTeclado.ActionPc.performed += Enter;
            inputAction.GamePlayTeclado.MenuPc.performed += StartButton;
            inputAction.GamePlayTeclado.ActionPc2.performed += SouthAction;
            inputAction.Enable();
        }
    }


    private void OnDisable()
    {
        inputAction.GamePlayTeclado.MovPc.performed -= Move;
        inputAction.GamePlayTeclado.ActionPc.performed -= Enter;
        inputAction.GamePlayTeclado.MenuPc.performed -= StartButton;
        inputAction.GamePlayTeclado.ActionPc2.performed -= SouthAction;
        inputAction.Disable();
    }
}
