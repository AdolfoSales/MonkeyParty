
using UnityEngine;
using UnityEngine.InputSystem;

public class KeyboadInput : BaseInput
{
    private Keyboard keyboard;

    //private Vector2 movementInput;

    public void InitKeyboard(Keyboard _keyboard)
    {
        keyboard = _keyboard;
    }

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


    private void OnDisable()
    {
        inputAction.MenuTeclado.Mov.performed -= Move;
        inputAction.MenuTeclado.Selection.performed -= Enter;
        inputAction.MenuTeclado.Start.performed -= StartButton;
        inputAction.Disable();
    }

    //private void OnEnable()
    //{
    //    if (inputAction == null)
    //    {
    //        inputAction = new Inputs();
    //        inputAction.Enable();
    //        inputAction.Menu.Mov.performed += Move;
    //        inputAction.Menu.Selection.performed += Enter;
    //    }

    //}


    //private void OnDisable()
    //{
    //    inputAction.Menu.Mov.performed -= Move;
    //    inputAction.Menu.Selection.performed -= Enter;
    //    inputAction.Disable();
    //}


    //public override void Move(InputAction.CallbackContext context)
    //{
    //    print(context.valueType);
    //    if (context.performed)
    //    {
    //        InputsActions.menuActionMove?.Invoke(context.ReadValue<Vector2>());
    //    }
    //}

    //public override void Enter(InputAction.CallbackContext context)
    //{
    //    print(context.valueType);
    //    if (context.performed)
    //    { 
    //        InputsActions.MenuActionEnter?.Invoke();
    //    }
    //}
}

