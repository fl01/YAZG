using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource _source;

    public AudioClip hitSound;
    public AudioClip deathSound;

    void Awake()
    {
        _source = GetComponent<AudioSource>();
    }

    public void PlayHitSound()
    {
        Play(hitSound);
    }

    public void PlayDeathSound()
    {
        Play(deathSound);
    }

    public void Play(AudioClip sound)
    {
        _source.clip = sound;
        _source.Play();
    }
}
