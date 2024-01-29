using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManagerBase : MonoBehaviour
{
    [SerializeField]
    protected Button[] buttonsYAxis;

    [SerializeField]
    protected Button[] buttonsXAxis;

    protected int buttonYaxisIndex = 0;

    protected int buttonXaxisIndex = 0;

    private void Start()
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
    }


    private void OnEnable()
    {
        InputsActions.menuActionMove += Move;
        InputsActions.MenuActionEnter += EnterButton;
        InputsActions.StartActionEnter += StartEnter;
    }

    private void OnDisable()
    {
        InputsActions.menuActionMove -= Move;
        InputsActions.MenuActionEnter -= EnterButton;
        InputsActions.StartActionEnter -= StartEnter;
    }

    protected virtual void Move(Vector2 dir)
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
        else if(dir.y < 0 && buttonsYAxis.Length > 0)    // down
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
        buttonXaxisIndex = buttonXaxisIndex < 0 ?  buttonsXAxis.Length - 1 : buttonXaxisIndex;
        buttonsXAxis[buttonXaxisIndex].interactable = true;
    }

    protected virtual void RightMov()
    {
        buttonsXAxis[buttonXaxisIndex].interactable = false;
        buttonXaxisIndex++;
        buttonXaxisIndex = buttonXaxisIndex >  buttonsXAxis.Length - 1 ? 0 : buttonXaxisIndex;
        buttonsXAxis[buttonXaxisIndex].interactable = true;
    }

    protected virtual void StartEnter()
    {
        //print("Start");
    }

    protected virtual void EnterButton()
    {
        buttonsYAxis[buttonYaxisIndex].onClick.Invoke();
    }
}
