using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum MONO : int
{
    EMO, CANI, ELEGANTE, FRIKI
}


public class SelectorSceneManager : MenuManager
{
    [SerializeField]
    protected Button[] buttonsYAxis;

    [SerializeField]
    protected Button[] buttonsXAxis;

    protected int buttonYaxisIndex = 0;

    protected int buttonXaxisIndex = 0;


    [SerializeField]
    private Sprite[] avatars;

    [SerializeField]
    private string[] monoNames;

    [SerializeField]
    private GameObject selectorPrefab;

    [SerializeField]
    private Transform pool;

    private int playerIndex = 0;


    private void Start()
    {
        InputManager.instance.InstanciatePlayers(SCENE_TYPE.MENU);
        InitMenu();
        SetButtons();
        ChoosePlayer();
    }

    private void SetButtons()
    {
        foreach (Button b in buttonsXAxis)
        {
            b.interactable = false;
        }
        if (buttonsXAxis.Length > 0)
            buttonsXAxis[buttonXaxisIndex].interactable = true;

        foreach (Button b in buttonsYAxis)
        {
            b.interactable = false;
        }
        if (buttonsYAxis.Length > 0)
            buttonsYAxis[buttonYaxisIndex].interactable = true;


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

    protected override void Move(Vector2 dir)
    {
        if (dir.x < 0 && buttonsXAxis.Length > 0)// left
        {
            LeftMov();
        }
        else if (dir.x > 0 && buttonsXAxis.Length > 0)// rig
        {
            RightMov();
        }
        else if (dir.y > 0 && buttonsYAxis.Length > 0)// up
        {
            UpMov();
        }
        else if (dir.y < 0 && buttonsYAxis.Length > 0)    // down
        {
            DownMov();
        }
    }

    protected virtual void UpMov()
    {
        buttonsYAxis[buttonYaxisIndex].interactable = false;
        buttonYaxisIndex++;
        buttonYaxisIndex = buttonYaxisIndex > buttonsYAxis.Length - 1 ? 0 : buttonYaxisIndex;
        buttonsYAxis[buttonYaxisIndex].interactable = true;
    }

    protected virtual void DownMov()
    {
        buttonsYAxis[buttonYaxisIndex].interactable = false;
        buttonYaxisIndex--;
        buttonYaxisIndex = buttonYaxisIndex < 0 ? buttonsYAxis.Length - 1 : buttonYaxisIndex;
        buttonsYAxis[buttonYaxisIndex].interactable = true;
    }

    protected virtual void LeftMov()
    {
        buttonsXAxis[buttonXaxisIndex].interactable = false;
        buttonXaxisIndex--;
        buttonXaxisIndex = buttonXaxisIndex < 0 ? buttonsXAxis.Length - 1 : buttonXaxisIndex;
        buttonsXAxis[buttonXaxisIndex].interactable = true;
    }

    protected virtual void RightMov()
    {
        buttonsXAxis[buttonXaxisIndex].interactable = false;
        buttonXaxisIndex++;
        buttonXaxisIndex = buttonXaxisIndex > buttonsXAxis.Length - 1 ? 0 : buttonXaxisIndex;
        buttonsXAxis[buttonXaxisIndex].interactable = true;
    }

    protected virtual void StartEnter()
    {
        //print("Start");
    }

    protected override void EnterAction()
    {
        buttonsXAxis[buttonXaxisIndex].onClick.Invoke();
    }
}
