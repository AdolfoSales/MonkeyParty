using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrazyApplesPlayerGP : GamePlayPlayer
{

    [SerializeField]
    protected GameObject ptcPrefab;

    [SerializeField]
    protected float repulsiveForce;


    private void OnEnable()
    {
        InputsActions.GamePlayActionMoveGP += MovePlayer;
        InputsActions.GamePlayActionEnterGP += JumpPlayer;
    }
    private void OnDisable()
    {
        InputsActions.GamePlayActionMoveGP -= MovePlayer;
        InputsActions.GamePlayActionEnterGP -= JumpPlayer;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LostZone"))
        {
            CrazyApplesSounds.instance.PlaySound(C_A_SOUNDS.FALLING);
            // Asignar puntos etc...
            PlayerActions.OnPlayerDie(this);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CrazyApplesSounds.instance.PlaySound(C_A_SOUNDS.IMPACT);

            GameObject ptc = Instantiate(ptcPrefab);
            ptc.transform.position = collision.GetContact(0).point;

            Vector3 dir = collision.transform.position - transform.position;
            rB.velocity = Vector3.zero;
            rB.AddForce(-dir * repulsiveForce, ForceMode.Force);
        }
        else if (collision.gameObject.CompareTag("Platform"))
        {
            canMove = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            canMove = false;
        }
    }
}
