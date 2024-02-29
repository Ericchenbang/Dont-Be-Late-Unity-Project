using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Volumn : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void SetVolumn(float volumn)
    {
        audioMixer.SetFloat("volumn", volumn);
    }
}
