using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum MONO : int
{
    EMO, CANI, ELEGANTE, FRIKI
}


public class SelectorSceneManager : SceneManagerBase
{
    [SerializeField]
    private Sprite[] avatars;

    [SerializeField]
    private string[] monoNames;

    [SerializeField]
    private GameObject selectorPrefab;

    [SerializeField]
    private Transform pool;

    private int playerIndex = 0;



    private void Awake()
    {
        SetButtons();
    }

    private void Start()
    {
        ChoosePlayer();
    }

    private void SetButtons()
    {
        // mono emo
        buttonsXAxis[0].onClick.RemoveAllListeners();
        buttonsXAxis[0].onClick.AddListener(
            delegate ()
            {
                CreateAvatar(MONO.EMO);
            });
        // mono cani
        buttonsXAxis[1].onClick.RemoveAllListeners();
        buttonsXAxis[1].onClick.AddListener(
            delegate ()
            {
                CreateAvatar(MONO.CANI);
            });
        //mono elegante
        buttonsXAxis[2].onClick.RemoveAllListeners();
        buttonsXAxis[2].onClick.AddListener(
            delegate ()
            {
                CreateAvatar(MONO.ELEGANTE);
            });
        //mono friki
        buttonsXAxis[3].onClick.RemoveAllListeners();
        buttonsXAxis[3].onClick.AddListener(
            delegate ()
            {
                CreateAvatar(MONO.FRIKI);
            });
    }

    protected override void EnterButton()
    {
        buttonsXAxis[buttonXaxisIndex].onClick.Invoke();
    }

    private void CreateAvatar(MONO mONO)
    {
        GameObject currentAvatar = Instantiate(selectorPrefab, pool);
        var selector = currentAvatar.GetComponent<PlayerSelector>();
        selector.SetImage(avatars[(int)mONO]);
        selector.SetName(monoNames[(int)mONO]);
        playerIndex++;
        ChoosePlayer();
    }

    public void ChoosePlayer()
    {
        if (playerIndex < InputManager.instance.GetNumPlayers())
        {
            foreach (BaseInput player in InputManager.instance.GetPlayers())
            {
                player.BlockInput();
            }

            InputManager.instance.GetPlayer(playerIndex).ReleaseInput();
        }
        else
        {
            foreach (BaseInput player in InputManager.instance.GetPlayers())
            {
                player.ReleaseInput();
            }
            GameManager.instance.LoadScene(SCENE.TAB);
        }
    }
}
