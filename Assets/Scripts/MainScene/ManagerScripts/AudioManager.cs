using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip PuckCollision;
    public AudioClip Goal;

    public AudioClip WinGame;
    public AudioClip LoseGame;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayPuckCollision()
    {
        audioSource.PlayOneShot(PuckCollision);
    }

    public void PlayGoal()
    {
        audioSource.PlayOneShot(Goal);
    }

    public void PlayWinGame()
    {
        audioSource.PlayOneShot(WinGame);
    }
    public void PlayLoseGame()
    {
        audioSource.PlayOneShot(LoseGame);
    }
}
