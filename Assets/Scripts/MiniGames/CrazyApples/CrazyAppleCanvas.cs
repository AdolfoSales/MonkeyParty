using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrazyAppleCanvas : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverPanel;

    [SerializeField]
    private TMPro.TextMeshProUGUI text;

    [SerializeField]
    private float timeTransition;

    public void SetWinner(string playerName)
    {
        gameOverPanel.SetActive(true);
        text.text = "The winner is " + playerName;
        Invoke(nameof(GoToTab), timeTransition);
    }

    private void GoToTab()
    {
        GameManager.instance.LoadScene(SCENE.TAB);
    }
}
