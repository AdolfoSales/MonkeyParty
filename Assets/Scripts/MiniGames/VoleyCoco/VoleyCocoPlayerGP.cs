using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VoleyCocoPlayerGP : GamePlayPlayer
{
    private bool onGround = false;

    [SerializeField]
    private Animator animator;

    public override void SetUp(BaseInput _baseInput)
    {
        base.SetUp(_baseInput);
        int side = (playerInput.GetIndex().Equals(0) || playerInput.GetIndex().Equals(2) ? 0 : 1);
        print("Player " + playerInput.GetIndex() + " " + side);
        LimitsActions.setPlayer(playerInput, side);
    }

    private void Update()
    {
        //if (canMove && dir != Vector3.zero)
        //{
        //    rB.velocity = dir * movSpeed;
        //}
        animator.SetFloat("MovSpeed", Mathf.Abs(rB.velocity.magnitude));
    }


    protected override void OnEnterAction2Pressed()
    {
        print("2ACTION");
        BallActions.ServeBallByPlayer(playerInput.GetIndex());
    }

    protected override void JumpPlayer()
    {
        if (onGround)
        {
            base.JumpPlayer();
            animator.SetBool("Jump", true);
            onGround = false;
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
