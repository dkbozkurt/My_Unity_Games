// Dogukan Kaan Bozkurt
// github.com/dkbozkurt

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundHandler : MonoBehaviour
{
    // Audio sources
    #region Audios
    [SerializeField] private AudioSource jump;
    [SerializeField] private AudioSource die;
    [SerializeField] private AudioSource increase;
    [SerializeField] private AudioSource endGame;
    #endregion

    // Jumping sound
    public void PlayJump()
    {
        jump.Play();
    }

    // Die sound
    public void PlayDie()
    {
        die.Play();
    }

    // Increase sound
    public void PlayIncrease()
    {
        increase.Play();
    }

    // End Game sound
    public void PlayEndGame()
    {
        endGame.Play();
    }
}
