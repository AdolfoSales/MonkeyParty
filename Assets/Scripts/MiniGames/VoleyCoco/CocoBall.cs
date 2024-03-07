using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public static class BallActions
{
    public static Action<int> ServeBallByPlayer;
    public static Action<Vector3, int[]> SetDirToServe;
}

[RequireComponent(typeof(Rigidbody))]
public class CocoBall : MonoBehaviour
{
    private Rigidbody rb;

    private GamePlayPlayer lastPlayerToched;

    private Vector3 initPos;

    private Vector3 dirToServe;

    private int[] playerToServe;

    [SerializeField]
    private float impactForce, startForce;


    private void Awake()
    {
        initPos = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        BallActions.ServeBallByPlayer += ServeBall;
        BallActions.SetDirToServe += SetDirToServe;
    }


    private void OnDisable()
    {
        BallActions.ServeBallByPlayer -= ServeBall;
        BallActions.SetDirToServe -= SetDirToServe;
    }

    private void Start()
    {
        InitBall();
    }

    private void InitBall()
    {
        rb.isKinematic = false;
        rb.velocity = Vector3.zero;
        transform.position = initPos;
        rb.AddForce((UnityEngine.Random.Range(0, 2) == 0 ? transform.right : -transform.right) * startForce);
    }

    private void SetDirToServe(Vector3 vector, int[] _playerToServe)
    {
        playerToServe = _playerToServe;
        dirToServe = vector;
        ResetBall();
    }

    public void ServeBall(int _player)
    {
        if(playerToServe!= null && playerToServe.Contains(_player))
        {
            rb.isKinematic = false;
            rb.AddForce(dirToServe * startForce);
            playerToServe = null;
        }
    }

    private void ResetBall()
    {
        lastPlayerToched = null;
        transform.position = initPos;
        rb.isKinematic = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GamePlayPlayer currentPlayer = collision.gameObject.GetComponent<GamePlayPlayer>();
            if (lastPlayerToched != null && lastPlayerToched.Equals(currentPlayer))
            {
                int lP = currentPlayer.GetPlayerPosition() == 0 || currentPlayer.GetPlayerPosition() == 2 ? 1 : 0;
                int rP = currentPlayer.GetPlayerPosition() == 1 || currentPlayer.GetPlayerPosition() == 3 ? 1 : 0;
                lastPlayerToched = null;
                LimitsActions.OnLostPlayer?.Invoke(currentPlayer.GetPlayerPosition());
                VoleyCocoActions.addPoints?.Invoke(lP, rP);
                ResetBall();
            }
            else
            {
                lastPlayerToched = currentPlayer;
                transform.position = currentPlayer.transform.GetChild(0).position;
                Vector3 dir = collision.gameObject.transform.forward;
                rb.velocity = Vector3.zero;
                rb.AddForce(dir * impactForce, ForceMode.Force);
            }
        }
        else if (collision.gameObject.CompareTag("LostZone"))
        {
            ResetBall();
        }
    }
}
