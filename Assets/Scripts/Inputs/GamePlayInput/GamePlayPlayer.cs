using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]

//esta es la plase padre de todos los dispositivos de  tipo game Play 
public class GamePlayPlayer : MonoBehaviour
{
    [SerializeField]
    protected float movSpeed, jumpSpeed, limitSpeed;

    protected Rigidbody rB;

    protected bool canMove = true;

    protected BaseInput playerInput;

    protected Vector3 dir;

    // asigna una acción a cada tecla
    public virtual void SetUp(BaseInput _baseInput)
    {
        rB = GetComponent<Rigidbody>();
        playerInput = _baseInput;
        playerInput.SetMoveAction(MovePlayer);
        playerInput.SetEnterAction(JumpPlayer);
        playerInput.SetStartAction(StartMovePlayer);
        playerInput.SetEndMoveAction(EndMovePlayer);
        playerInput.SetStartButtonPressed(StartButtonPressed);
        playerInput.SetEnterAction2(OnEnterAction2Pressed);
    }

    // este es el codigo de la acción 
    //virtual es un metodo abstracto
    protected virtual void MovePlayer(Vector2 vector)
    {
        if (canMove && MovementAccepted(dir))
        {
            dir = new Vector3(vector.x, 0.0f, vector.y);
            rB.AddForce(dir * movSpeed, ForceMode.Impulse);
        }
    }

    protected virtual void StartMovePlayer()
    {
        canMove = true;
    }

    protected virtual void EndMovePlayer()
    {
        canMove = false;
    }

    protected virtual void StartButtonPressed()
    {
        print("Abre menu pausa");
    }

    protected virtual void JumpPlayer()
    {
        if(canMove)
            rB.AddForce(jumpSpeed * Vector3.up, ForceMode.Impulse);
    }

    protected virtual void OnEnterAction2Pressed()
    {
        
    }

    protected virtual bool MovementAccepted(Vector3 dir)
    {
        return rB.velocity.magnitude < limitSpeed;
    }

    public void OnDiePlayer()
    {
        Destroy(gameObject);
    }



    public int GetPlayerPosition()
    {
        return playerInput.GetIndex();
    }
}
