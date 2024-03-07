using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class MenuPlayerInput : MonoBehaviour
{
    private BaseInput playerInput;

    public virtual void SetUp(BaseInput _baseInput)
    {
        playerInput = _baseInput;
        playerInput.SetMoveAction(MovePlayer);
        playerInput.SetEnterAction(ActionSouth);
        playerInput.SetStartAction(ActionStart);
    }

    protected virtual void MovePlayer(Vector2 vector)
    {
        MenuActions.Move?.Invoke(vector);
    }

    protected virtual void ActionSouth()
    {
        MenuActions.enterAction?.Invoke();
    }

    protected virtual void ActionStart()
    {
       MenuActions.startAction?.Invoke();
    }
}
