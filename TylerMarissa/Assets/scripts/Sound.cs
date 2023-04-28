/**********************************************************************************

// File Name :         Sound.cs
// Author :            Marissa Moser
// Creation Date :     April 27, 2023
//
// Brief Description : Class for the Sound effects.

**********************************************************************************/

using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;

    public AudioMixerGroup mixer;

    [Range(0f, 1f)]
    public float volume;

    [Range(0f, 3f)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;
}
