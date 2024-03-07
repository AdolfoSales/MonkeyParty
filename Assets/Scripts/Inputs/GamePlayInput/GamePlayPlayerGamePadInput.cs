using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class GamePlayPlayerGamePadInput : BaseInput
{
    private Gamepad gamePad;

    private void Awake()
    {
        iNPUT = INPUT.GAMEPAD;
    }

    private void OnEnable()
    {
        if (inputAction == null)
        {
            inputAction = new Inputs();
            inputAction.GamePlayGamePad.MovGp.performed += Move;
            inputAction.GamePlayGamePad.ActionGp.performed += Enter;
            inputAction.GamePlayGamePad.MenuGp.performed += StartButton;
            inputAction.GamePlayGamePad.ActionGp2.performed += SouthAction;
            inputAction.Enable();
        }
    }


    private void OnDisable()
    {
        inputAction.GamePlayGamePad.MovGp.performed -= Move;
        inputAction.GamePlayGamePad.ActionGp.performed -= Enter;
        inputAction.GamePlayGamePad.MenuGp.performed -= StartButton;
        inputAction.GamePlayGamePad.ActionGp2.performed -= SouthAction;
        inputAction.Disable();
    }
}
