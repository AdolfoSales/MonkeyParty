using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public static class VoleyCocoActions
{
    public static Action<int,int> addPoints;
}


public class VoleyCocoManager : MiniGameManager
{
    private int leftPoints = 0, rightPoints = 0;

    [SerializeField]
    private TextMeshProUGUI leftPointsText, rightPointsText;

    [SerializeField]
    [Tooltip("Número de juegos por partida")]
    private int maxGames;

    [SerializeField]
    [Tooltip("Número de juegos para ganar la partida")]
    private int numGamesToWin;


    private void OnEnable()
    {
        VoleyCocoActions.addPoints += SetPoints;
    }

    private void OnDisable()
    {
        VoleyCocoActions.addPoints -= SetPoints;
    }

    private void Awake()
    {
        InputManager.instance.InstanciatePlayers(SCENE_TYPE.GAME_PLAY);
    }

    private void Start()
    {
        InitMiniGame();
        SetPoints();
    }

    private void SetPoints(int leftP = 0, int rightP = 0)
    {
        leftPoints += leftP > 0 ? leftP : 0;
        rightPoints += rightP > 0 ? rightP : 0;
        leftPointsText.text = leftPoints.ToString();
        rightPointsText.text = rightPoints.ToString();
        if (leftPoints >= numGamesToWin ||rightPoints >= numGamesToWin)
        {
            GameManager.instance.LoadScene(SCENE.TAB);
        }
    }
}
