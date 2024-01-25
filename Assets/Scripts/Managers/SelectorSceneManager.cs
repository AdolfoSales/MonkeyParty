using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectorSceneManager : MonoBehaviour
{
    [SerializeField]
    private Button backButton, playButton;


    private void Awake()
    {
        SetButtons();
    }

    private void SetButtons()
    {
        backButton.onClick.RemoveAllListeners();
        backButton.onClick.AddListener(
            delegate()
            {
                GameManager.instance.LoadScene(SCENE.MAIN);
            }
            );
        playButton.onClick.RemoveAllListeners();
        playButton.onClick.AddListener(
            delegate ()
            {
                GameManager.instance.LoadScene(SCENE.TAB);
            }
            );
    }
}
