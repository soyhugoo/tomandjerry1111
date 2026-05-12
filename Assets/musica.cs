using System;
using UnityEngine;
using UnityEngine.Audio;



public class MixerVolumeController : MonoBehaviour
{
    // Esta variable es donde arrastrarás el GameMixer
    public AudioMixer masterMixer;

    // Esta es la función que TIENE que aparecer en el Slider
    public void SetSound(float soundLevel)
    {
        // "musicvol" debe ser el nombre exacto que pusiste en el paso 5 del profesor
        masterMixer.SetFloat("musicvol", soundLevel);
    }
}
    
