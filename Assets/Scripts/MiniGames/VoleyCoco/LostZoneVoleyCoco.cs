using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LimitsActions
{
    public static Action<BaseInput,int> setPlayer;
    public static Action<int> OnLostPlayer;
}

public class LostZoneVoleyCoco : MonoBehaviour
{
    [SerializeField]
    private Vector2 dirToThrow;

    [SerializeField]
    private int side;

    private List<BaseInput> players = new();


    private void OnEnable()
    {
        LimitsActions.setPlayer += SetPlayer;
        LimitsActions.OnLostPlayer += OnLostBall;
    }

    private void OnDisable()
    {
        LimitsActions.setPlayer -= SetPlayer;
    }

    private void SetPlayer(BaseInput input, int _side)
    {
        if(side.Equals(_side))
            players.Add(input);
    }

    private void OnCollisionEnter(Collision collision)
    {
        OnLostBall(players[0].GetIndex());
    }

    private void OnLostBall(int _player )
    {
        if (!side.Equals(_player)) return;

        int[] indexs = new int[players.Count];
        for (int i = 0; i < indexs.Length; i++)
        {
            indexs[i] = players[i].GetIndex();
        }
        BallActions.SetDirToServe?.Invoke(dirToThrow, indexs);
        int lS = side == 1 ? 1 : 0;
        int rS = side == 0 ? 1 : 0;
        VoleyCocoActions.addPoints(lS, rS);
    }

    public void AddPoints()
    {
        OnLostBall(side);
    }
}
