using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public enum INPUT : int
{
    KEYBOARD, GAMEPAD, JOYSTICK
}

//clase padre de todos las clases que capturan inputs
public class BaseInput : MonoBehaviour
{

    //cuando es detipo protected una variable lo puede utilizar cualquier clase que herede de qeste script 
    // en este caso quien herede el es el gamepplay, teclado, BaseInput..etc)
    [SerializeField]
    protected InputActionAsset inputActionAsset;
    // variable de tipo inputs, que es una refencias a los propies inputs de esta clase
    protected Inputs inputAction;
    // si puedo aplica input
    protected bool canMove = true;
    //pàra diferenciar entre los diferentes inputs
    protected INPUT iNPUT;
    // determina si mi avatar es player 1, player 2, player 3 o player 4 ( esto va segun el orden de creación)
    protected int playerIndexPosition;
    //es una a ccción para guardar un metodo en una variable-.
    protected UnityAction<Vector2> moveAction;
    // variable para asignar cada acción
    protected UnityAction enterAction, startAction, openMenuAction, startMoveAction, endMoveAction, startButtonAction, southAction;

    //metodo propio de Unity. se encarga que cuanbdo se crea el objeto, se crea el input acction y activa el input accions

    private void OnEnable()
    {
        if (inputAction == null)
        {
            inputAction = new Inputs();
            inputAction.Enable();
        }
    }


    private void OnDisable()
    {
        inputAction.Disable();
    }

    //la acción de moverse, cuando llega la orden de moverse
    public virtual void Move(InputAction.CallbackContext context)
    {
        if(canMove)
            moveAction?.Invoke(context.ReadValue<Vector2>());
        if (context.started)
        {
            startMoveAction?.Invoke();
        }
        else if(context.canceled)
        {
            endMoveAction?.Invoke();
        }

        //if (context.performed && canMove)
        //{
        //    InputsActions.menuActionMove?.Invoke(context.ReadValue<Vector2>());
        //}
    }
    //represeta la acción del inter del teclado y la del mando el D o si es play station seria el circulo
    public virtual void Enter(InputAction.CallbackContext context)
    {
        if(canMove)
            enterAction?.Invoke();
        //if (context.performed && canMove)
        //{
        //    InputsActions.MenuActionEnter?.Invoke();
        //}
    }
    //represeta la acción del inter del teclado y la del mando el A o si es play station seria la X
    public virtual void SouthAction(InputAction.CallbackContext context)
    {
        if(canMove)
            southAction?.Invoke();
    }
    //represeta la acción del inter del teclado y la del mando el start, en el tecclado scape
    public virtual void StartButton(InputAction.CallbackContext context)
    {
        if(canMove)
            startAction?.Invoke();
        //if (context.performed && canMove)
        //{
        //    InputsActions.StartActionEnter?.Invoke();
        //}
    }

    public virtual void OpenMenu(InputAction.CallbackContext context)
    {
        if(canMove)
            openMenuAction?.Invoke();

        //if (context.performed && canMove)
        //{
        //    InputsActions.OpenActionMenu?.Invoke();
        //}
    }
    //este es para setear las posiciones de cada jugador.
    public void SetIndex(int _index)
    {
        playerIndexPosition = _index;
    }
    // para saber la posición del jugador
    public int GetIndex()
    {
        return playerIndexPosition;
    }
    //para bloquear el input y no se puedo usar
    public void BlockInput()
    {
        canMove = false;
    }
    //para reanudar y qeu se vuelva activar
    public void ReleaseInput()
    {
        canMove = true;
    }
    //devolver el tipo de dispositivo( si es teclado , mando o yostick..)
    public INPUT GetTypeInput()
    {
        return iNPUT;
    }
    // asignan la acción ppropias del script con otras acciones-
    // esto corresponde a todos lo smetodos set
    public void SetMoveAction(UnityAction<Vector2> _moveAction)
    {
        moveAction = _moveAction;
    }

    public void SetEnterAction(UnityAction _enterAction)
    {
        enterAction = _enterAction;
    }

    public void SetStartAction(UnityAction _startAction)
    {
        startAction = _startAction;
    }

    public void SetOpenMenuAction(UnityAction _openMenuAction)
    {
        openMenuAction = _openMenuAction;
    }

    public void SetStartMoveAction(UnityAction _startMoveAction)
    {
        startMoveAction = _startMoveAction;
    }

    public void SetEndMoveAction(UnityAction _EndMoveAction)
    {
        endMoveAction = _EndMoveAction;
    }

    public void SetStartButtonPressed(UnityAction _startButtonAction)
    {
        startButtonAction = _startButtonAction;
    }

    public void SetEnterAction2(UnityAction _EnterAction2)
    {
        southAction = _EnterAction2;
    }
}
