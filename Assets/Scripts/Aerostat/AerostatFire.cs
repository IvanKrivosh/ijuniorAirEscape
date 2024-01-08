using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AerostatFire : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void TurnOn()
    {
        SetActive();
        _audioSource.Play();
    }

    public void TurnOff()
    {
        SetActive(false);
        _audioSource.Stop();
    }

    private void SetActive(bool active = true)
    {
        gameObject.SetActive(active);
    }
}
