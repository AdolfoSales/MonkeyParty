using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//clase que hereda de baseInput que se encargar de capturar input pàra un mando que va ser usado en un menú.
public class GamePadMenuInput : BaseInput
{
    private Gamepad gamePad;

    private void Awake()
    {
        iNPUT = INPUT.GAMEPAD;
    }
    //cuanbdo se crea el objeto me suscribo a los eventos

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

    //cuandpo ME DESACTVo me desactivo de los eventos.
    private void OnDisable()
    {
        inputAction.MenuMando.Mov.performed -= Move;
        inputAction.MenuMando.Selection.performed -= Enter;
        inputAction.MenuMando.Start.performed -= StartButton;
        inputAction.Disable();
    }
}
