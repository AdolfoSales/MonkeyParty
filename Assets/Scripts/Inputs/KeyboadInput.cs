
using UnityEngine;
using UnityEngine.InputSystem;
////clase que hereda de baseInput que se encargar de capturar input pàra un teclado que va ser usado en un menú.
public class KeyboadInput : BaseInput
{
    private Keyboard keyboard;

    //private Vector2 movementInput;

    private void Awake()
    {
        iNPUT = INPUT.KEYBOARD;
    }

    //cuanbdo se crea el objeto me suscribo a los eventos
    private void OnEnable()
    {
        if (inputAction == null)
        {
            inputAction = new Inputs();
            inputAction.MenuTeclado.Mov.performed += Move;
            inputAction.MenuTeclado.Selection.performed += Enter;
            inputAction.MenuTeclado.Start.performed += StartButton;
            inputAction.Enable();
        }
    }

    //cuandpo ME DESACTVo me desactivo de los eventos.
    private void OnDisable()
    {
        inputAction.MenuTeclado.Mov.performed -= Move;
        inputAction.MenuTeclado.Selection.performed -= Enter;
        inputAction.MenuTeclado.Start.performed -= StartButton;
        inputAction.Disable();
    }

}

