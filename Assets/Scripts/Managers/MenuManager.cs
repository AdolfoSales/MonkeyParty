using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class MenuActions
{
    public static Action<Vector2> Move;
    public static Action enterAction;
    public static Action startAction;
}

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pcPlayerMenuPrefab;

    [SerializeField]
    private GameObject gamePadPlayerMenuPrefab;

    private void OnEnable()
    {
        MenuActions.Move += Move;
        MenuActions.startAction += StartAction;
        MenuActions.enterAction+= EnterAction;
    }

    protected virtual void InitMenu()
    {
        foreach (BaseInput bI in InputManager.instance.GetPlayers())
        {
            CreatePlayer(bI);
        }
    }


    protected virtual void CreatePlayer(BaseInput _baseInput)
    {
        switch (_baseInput.GetTypeInput())
        {
            case INPUT.KEYBOARD:
                InstancePlayer(pcPlayerMenuPrefab, _baseInput);
                break;
            case INPUT.GAMEPAD:
                InstancePlayer(gamePadPlayerMenuPrefab, _baseInput);
                break;
            case INPUT.JOYSTICK:
                break;
        }
    }

    protected virtual void InstancePlayer(GameObject _prefab, BaseInput _baseInput)
    {
        GameObject currentPlayer = Instantiate(_prefab);
        currentPlayer.GetComponent<MenuPlayerInput>().SetUp(_baseInput);

        //GameObject avatar = Instantiate(caniAvatarPrefab);
        //avatar.GetComponent<PlayerAttachment>().InitAvatar(currentPlayer.transform);
        //GamePlayPlayer player = currentPlayer.GetComponent<GamePlayPlayer>();
        //player.IniPlayer(avatar);
        //players.Add(player);
    }

    protected virtual void Move(Vector2 dir)
    {
        
    }

    protected virtual void EnterAction()
    {

    }

    protected virtual void StartAction()
    {

    }
}
