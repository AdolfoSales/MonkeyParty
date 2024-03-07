using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Clase que se encarga de crear un avatar cuando selecciones un player en la escenar de selección
public class PlayerSelector : MonoBehaviour
{

    //Para una imagen desde el editor. SerializeField es para que una variable se pueda modificar desde el editor
    [SerializeField]
    private Image image;

    //variable que metemos el texto que aparece en el avatar cuando lo seleccionamos, mostrando el nombre
    [SerializeField]
    private TMPro.TextMeshProUGUI text;
    
    //metodo para asignar la imagen al avatar
    public void SetImage(Sprite img)
    {
        image.sprite = img;
    }

    //metodo para asignar el nombre al avatar
    public void SetName(string _name)
    {
        text.text = _name;
    }
}
