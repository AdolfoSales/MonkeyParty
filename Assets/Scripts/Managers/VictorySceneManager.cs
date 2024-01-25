using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictorySceneManager : MonoBehaviour
{
    [SerializeField]
    private Button mainButton;

    private void Awake()
    {
        SetButtons();
    }

    private void SetButtons()
    {
        mainButton.onClick.RemoveAllListeners();
        mainButton.onClick.AddListener(
            delegate ()
            {
                GameManager.instance.LoadScene(SCENE.MAIN);
            });
    }
}
