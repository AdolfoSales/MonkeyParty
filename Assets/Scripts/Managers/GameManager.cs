using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public enum SCENE : int
{
    MAIN, OPTIONS, SELECTOR, TAB, TUTORIAL, MINIGAME, VICTORY_SCENE, NULL
};


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private SCENE cURRENT_sCENE;

    private SCENE pREV_sCENE;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void CloseApp()
    {
        Application.Quit();
    }

    public void LoadScene(SCENE _sCENE)
    {
        cURRENT_sCENE = _sCENE;
        if (pREV_sCENE == SCENE.NULL)
        {
            SceneManager.LoadScene((int)_sCENE);
        }
        else
        {
            SceneManager.LoadScene((int)pREV_sCENE);
            pREV_sCENE = SCENE.NULL;
        }
    }

    public void BackScene(SCENE _sCENE)
    {
        //pREV_sCENE = _pREV;
        cURRENT_sCENE = _sCENE;
        SceneManager.LoadScene((int)_sCENE);
    }
}
