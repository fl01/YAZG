using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip hitSound;
    public AudioClip deathSound;

    public void PlayHitSound(AudioSource source)
    {
        source.clip = hitSound;
        source.Play();
    }

    public void PlayDeathSound(AudioSource source)
    {
        source.clip = deathSound;
        source.Play();
    }
}
