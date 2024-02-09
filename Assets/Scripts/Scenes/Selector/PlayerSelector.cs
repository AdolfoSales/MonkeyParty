using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelector : MonoBehaviour
{
    [SerializeField]
    private Image image;

    [SerializeField]
    private TMPro.TextMeshProUGUI text;
    

    public void SetImage(Sprite img)
    {
        image.sprite = img;
    }

    public void SetName(string _name)
    {
        text.text = _name;
    }
}
