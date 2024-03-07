using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum C_A_SOUNDS : int
{
    IMPACT, FALLING ,
}

public class CrazyApplesSounds : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField]
    private List<AudioClip> clips = new List<AudioClip>();

    public static CrazyApplesSounds instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(C_A_SOUNDS c_A_SOUNDS)
    {
        audioSource.PlayOneShot(clips[(int)c_A_SOUNDS]);
    }
}
