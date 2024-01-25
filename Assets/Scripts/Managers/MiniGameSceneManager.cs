using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameSceneManager : MonoBehaviour
{
    [SerializeField]
    private Button optionsButton,tabButton;

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
        optionsButton.onClick.RemoveAllListeners();
        optionsButton.onClick.AddListener(
            delegate ()
            {
                GameManager.instance.LoadScene(SCENE.OPTIONS);
            });
        tabButton.onClick.RemoveAllListeners();
        tabButton.onClick.AddListener(
            delegate ()
            {
                GameManager.instance.LoadScene(SCENE.TAB);
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
