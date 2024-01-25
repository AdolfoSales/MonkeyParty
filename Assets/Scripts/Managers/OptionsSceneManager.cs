using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsSceneManager : MonoBehaviour
{

    [SerializeField]
    private Button graphicsButton, soundsButton, backButton;


    private void Awake()
    {
        SetButtons();
    }

    private void SetButtons()
    {
        graphicsButton.onClick.RemoveAllListeners();
        graphicsButton.onClick.AddListener(
            delegate ()
            {
                //GameManager.instance.LoadScene(SCENE.SELECTOR);
            });
        soundsButton.onClick.RemoveAllListeners();
        soundsButton.onClick.AddListener(
           delegate ()
           {
               
           });
        backButton.onClick.RemoveAllListeners();
        backButton.onClick.AddListener(
            delegate ()
            {
                GameManager.instance.LoadScene(SCENE.MAIN);
            });
    }
}
