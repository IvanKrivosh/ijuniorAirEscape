using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Explosion : StoredObject
{    
    private AudioSource _audioSource;

    private void Awake()
    {        
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {        
        _audioSource.Play();
    }

}
