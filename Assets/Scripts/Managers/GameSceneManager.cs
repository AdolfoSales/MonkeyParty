using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneManager : MonoBehaviour
{
    [SerializeField]
    private Button playButton, optionButton, exitButton;


    private void Awake()
    {
        SetButtons();
    }

    private void SetButtons()
    {
        playButton.onClick.RemoveAllListeners();
        playButton.onClick.AddListener(
            delegate ()
            {
                GameManager.instance.LoadScene(SCENE.SELECTOR);
            });
        optionButton.onClick.RemoveAllListeners();
        optionButton.onClick.AddListener(
           delegate ()
           {
               GameManager.instance.LoadScene(SCENE.OPTIONS);
           });
        exitButton.onClick.RemoveAllListeners();
        exitButton.onClick.AddListener(
            delegate ()
            {
                GameManager.instance.CloseApp();
            });
    }
}
