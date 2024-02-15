using System;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.Serialization;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    
    void Awake()
    {
        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }
    }
    
    void Start()
    {
        Play("PongTheme");
    }
    
    public void Play(string name)
    {
        Sound sound = Array.Find(sounds, s => s.name == name);
        sound.source.Play();
    }
}
