using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameSceneManager : MonoBehaviour
{
    [SerializeField]
    private Button[] buttons;// playButton, optionButton, exitButton;

    private int buttonIndex = 0;

    private void OnEnable()
    {
        InputsActions.menuActionMove += Move;
        InputsActions.MenuActionEnter += EnterButton;
        InputsActions.StartActionEnter += StartEnter;
    }

    private void OnDisable()
    {
        InputsActions.menuActionMove -= Move;
        InputsActions.MenuActionEnter -= EnterButton;
        InputsActions.StartActionEnter -= StartEnter;
    }


    private void Move(Vector2 dir)
    {
        if (dir.y > 0)
        {
            UpMov();
        }
        else
        {
            DownMov();
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

    public void EnterButton()
    {
        buttons[buttonIndex].onClick.Invoke();
    }

    private void Awake()
    {
        SetButtons();
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
