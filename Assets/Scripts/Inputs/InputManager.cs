using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Experimental.GraphView.GraphView;


public enum SCENE_TYPE : int
{
    GAME_PLAY, MENU
}

public class InputManager : MonoBehaviour
{
    // Número máximo de jugadores
    [SerializeField]
    private int maxPlayers;

    // Prefabs de los jugadores
    [SerializeField]
    private GameObject menuKeyboard, menuGamePad, gamePlayGamePad, gamePlayKeyboard;

    // Lista de jugadores creados
    private List<BaseInput> players = new List<BaseInput>();
    
    public static InputManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SetUp();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //metodo apra saber que tipo de dispositivos a detectado, envia un mensaje para saber que dispositivos que han conectado
    private void SetUp()
    {
        var devices = InputSystem.devices;
        //es un tipo de for para recorrer una lista de dispositivos 
        foreach (var device in devices)
        {
            // Verificar si el dispositivo es un gamepad
            if (device is Gamepad)
            {
               
                if (device.displayName.Contains("DualShock") || device.displayName.Contains("DualSense"))
                {
                    Debug.Log("Se ha detectado un gamepad de PlayStation.");
                }
                else if (device.displayName.Contains("Xbox"))
                {
                    Debug.Log("Se ha detectado un gamepad de xbox.");
                }
            }
            else if (device is Keyboard)
            {
                Debug.Log("Se encontró un teclado " + device.GetType().Name);
        
            }
            else if (device is Joystick)
            {
                Debug.Log("Se encontró un joystick " + device.GetType().Name);
            }
        }

    }
    // es el que crear los diferentes tipos de inputs
    public void InstanciatePlayers(SCENE_TYPE sCENE_TYPE)
    {
        var devices = InputSystem.devices;
        foreach (var device in devices)
        {
            if (device is Gamepad)
            {
                GameObject gamePadPlayer = Instantiate(sCENE_TYPE.Equals(SCENE_TYPE.MENU) ? menuGamePad : gamePlayGamePad);
                //gamePadPlayer.GetComponent<GamePadMenuInput>().InitGamePad(InputSystem.GetDevice<Gamepad>());
                players.Add(gamePadPlayer.GetComponent<BaseInput>());
                players[players.Count - 1].SetIndex(players.Count - 1);
            }
            else if (device is Keyboard)
            {
                GameObject keyboardPlayer = Instantiate(sCENE_TYPE.Equals(SCENE_TYPE.MENU) ? menuKeyboard : gamePlayKeyboard);
                //keyboardPlayer.GetComponent<KeyboadInput>().InitKeyboard(InputSystem.GetDevice<Keyboard>());
                players.Add(keyboardPlayer.GetComponent<BaseInput>());
                players[players.Count - 1].SetIndex(players.Count - 1);
            }
            else if (device is Joystick)
            {
            }
            
        }
    }
    // te devuelve un input.
    public BaseInput GetPlayer(int index)
    {
        return players[index];
    }
    //te devuelve la cantidad de jugadores que hay en el juego
    public int GetNumPlayers()
    {
        return players.Count;
    }
    // te devuelve una lista de todos los jugadores que tengamos.
    public BaseInput[] GetPlayers()
    {
        return players.ToArray();
    }
}
