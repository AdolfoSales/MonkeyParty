using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialSceneManager : MonoBehaviour
{
    [SerializeField]
    private Button playButton;

    [SerializeField]
    private KeyCode pauseKey;

    [SerializeField]
    private GameObject pausePanel;


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
                GameManager.instance.LoadScene(SCENE.MINIGAME);
            });
    }

    private void Update()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            pausePanel.SetActive(!pausePanel.activeInHierarchy);
        }
    }
}
