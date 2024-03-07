using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrazyApplesManager : MiniGameManager
{
    [SerializeField]
    private GameObject pcPlayerPrefab;

    [SerializeField]
    private GameObject gamePadPlayerPrefab;

    [SerializeField]
    private List<Transform> initPositions;

    [SerializeField]
    private GameObject caniAvatarPrefab;

    [SerializeField]
    private CrazyAppleCanvas crazyAppleCanvas;

    private List<GamePlayPlayer> players = new List<GamePlayPlayer>();


    private void OnEnable()
    {
        PlayerActions.OnPlayerDie += OnPlayerDie;
    }

    private void OnDisable()
    {
        PlayerActions.OnPlayerDie -= OnPlayerDie;
    }

    public void Awake()
    {
        InitMiniGame();
    }

    protected override void InstancePlayer(GameObject _prefab, BaseInput _baseInput)
    {
        GameObject currentPlayer = Instantiate(_prefab);
        int indexPos = Random.Range(0, initPositions.Count);
        currentPlayer.transform.position = initPositions[indexPos].position;
        initPositions.RemoveAt(indexPos);
        GameObject avatar = Instantiate(caniAvatarPrefab);
        avatar.GetComponent<PlayerAttachment>().InitAvatar(currentPlayer.transform);
        GamePlayPlayer player = currentPlayer.GetComponent<GamePlayPlayer>();
        //player.IniPlayer(avatar);
        players.Add(player);
    }

    private void OnPlayerDie(GamePlayPlayer _gamePlayPlayer)
    {
        players.Remove(_gamePlayPlayer);
        if (players.Count <= 1)
        {
            crazyAppleCanvas.SetWinner(players[0].name);
        }
    }
}
