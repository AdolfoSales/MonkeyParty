using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoleyCocoPlayerKey : GamePlayPlayer
{
    private bool onGround;

    [SerializeField]
    private Animator animator;

    //private void OnEnable()
    //{
    //    InputsActions.GamePlayActionMovePC += MovePlayer;
    //    InputsActions.GamePlayActionEnterPC += JumpPlayer;
    //}
    //private void OnDisable()
    //{
    //    InputsActions.GamePlayActionMovePC -= MovePlayer;
    //    InputsActions.GamePlayActionEnterPC += JumpPlayer;
    //}

    private void Update()
    {
        //if (canMove && dir != Vector3.zero)
        //{
        //    rB.velocity = dir * movSpeed;
        //}
        animator.SetFloat("MovSpeed", Mathf.Abs(rB.velocity.magnitude));
    }

    public override void SetUp(BaseInput _baseInput)
    {
        base.SetUp(_baseInput);
        int side = (playerInput.GetIndex().Equals(0) || playerInput.GetIndex().Equals(2) ? 0 : 1);
        print("Player " + playerInput.GetIndex() + " " + side);
        LimitsActions.setPlayer(playerInput, side);
    }

    protected override void OnEnterAction2Pressed()
    {
        BallActions.ServeBallByPlayer(playerInput.GetIndex());
    }

    protected override void JumpPlayer()
    {
        if (onGround)
        {
            print("JUMP");
            base.JumpPlayer();
            onGround = false;
            animator.SetBool("Jump",true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            onGround = true;
            animator.SetBool("Jump", false);
        }
    }
}
