using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameSceneManager : MenuManager
{
    [SerializeField]
    private Button[] buttons;// playButton, optionButton, exitButton;

    private int buttonIndex = 0;

    private void Awake()
    {
        SetButtons();
        InputManager.instance.InstanciatePlayers(SCENE_TYPE.MENU);
        InitMenu();
    }


    protected override void Move(Vector2 dir)
    {
        if (dir.y > 0)
        {
            DownMov();
        }
        else
        {
            UpMov();
        }
    }

    private void UpMov()
    {
        buttons[buttonIndex].interactable = false;
        buttonIndex++;
        buttonIndex = buttonIndex > 2 ? 0 : buttonIndex;
        buttons[buttonIndex].interactable = true;
    }

    private void DownMov()
    {
        buttons[buttonIndex].interactable = false;
        buttonIndex--; 
        buttonIndex = buttonIndex < 0 ? 2 : buttonIndex;
        buttons[buttonIndex].interactable = true;

    }

    private void StartEnter()
    {
        print("Start");
    }

    protected override void EnterAction()
    {
        buttons[buttonIndex].onClick.Invoke();
    }


    private void SetButtons()
    {
        buttons[0].onClick.RemoveAllListeners();
        buttons[0].onClick.AddListener(
            delegate ()
            {
                GameManager.instance.LoadScene(SCENE.SELECTOR);
            });
        
        buttons[1].onClick.RemoveAllListeners();
        buttons[1].onClick.AddListener(
           delegate ()
           {
               GameManager.instance.LoadScene(SCENE.OPTIONS);
           });
        buttons[1].interactable = false;

        buttons[2].onClick.RemoveAllListeners();
        buttons[2].onClick.AddListener(
            delegate ()
            {
                GameManager.instance.CloseApp();
            });
        buttons[2].interactable = false;
    }
}
