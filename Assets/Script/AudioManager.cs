using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource backgroundAudioSource;
    [SerializeField] private AudioSource effectAudioSource;
    [SerializeField] private AudioClip backGroundClip;
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip coinClip;

    void Start()
    {
        PlayBackgroundMusic();
    }

    // Update is called once per frame
   
    public void PlayBackgroundMusic()
    {
        backgroundAudioSource.clip = backGroundClip;
        backgroundAudioSource.Play();
    }
    public void PlayCoinSound()
    {
        effectAudioSource.PlayOneShot(coinClip);
    }
    public void PlayJumpSound()
    {
        effectAudioSource.PlayOneShot(jumpClip);
    }
}
