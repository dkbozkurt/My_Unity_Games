// Dogukan Kaan Bozkurt
//		github.com/dkbozkurt

using UnityEngine.Audio;       // Dont forget to import
using UnityEngine;

/// <summary>
/// 
/// </summary>

[System.Serializable] 
public class Sound
{
    
    public string name;
    
    public AudioClip clip;

    [Range(0f,1f)]
    public float volume;

    [Range(-3f,3f)]
    public float pitch;

    public bool mute;
    
    public bool loop;

    public bool playOnAwake;
    
    
    
    [HideInInspector] public AudioSource source;


}
