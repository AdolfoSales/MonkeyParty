using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabSceneManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel;

    [SerializeField]
    private Button tutorialButton, optionButton, victoryButton;

    [SerializeField]
    private KeyCode pauseKey;

    private void Awake()
    {
        SetButtons();
    }

    private void SetButtons()
    {
        tutorialButton.onClick.RemoveAllListeners();
        tutorialButton.onClick.AddListener(
            delegate ()
            {
                GameManager.instance.LoadScene(SCENE.TUTORIAL);
            }
            );
        optionButton.onClick.RemoveAllListeners();
        optionButton.onClick.AddListener(
            delegate ()
            {
                GameManager.instance.LoadScene(SCENE.OPTIONS);
            }
            );
        victoryButton.onClick.RemoveAllListeners();
        victoryButton.onClick.AddListener(
            delegate ()
            {
                GameManager.instance.LoadScene(SCENE.VICTORY_SCENE);
            }
            );
        pausePanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(pauseKey)) 
        {
            pausePanel.SetActive(!pausePanel.activeInHierarchy);
        }
    }
}
