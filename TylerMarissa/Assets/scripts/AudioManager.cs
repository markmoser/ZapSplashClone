/**********************************************************************************

// File Name :         AudioManager.cs
// Author :            Marissa Moser
// Creation Date :     April 27, 2023
//
// Brief Description : Code for the Audio Manager. Called from anywhere in the 
            game to play a sound. Create new spund effects in the inspector.

**********************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    /// <summary>
    /// Start function assigns components to the sound class objects
    /// </summary>
    void Start()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;
            s.source.outputAudioMixerGroup = s.mixer;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    /// <summary>
    /// Function called from anywhere to play sound 
    /// </summary>
    /// <param name="name"></param>
    public void Play(string name)
    {
        Sound s = System.Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
}
