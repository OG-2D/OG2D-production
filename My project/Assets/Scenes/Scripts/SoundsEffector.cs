using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsEffector : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip jumpSound, shootSound, loseSound;

    public void PlayJumpSound() => audioSource.PlayOneShot(jumpSound);

    public void PlayShootSound() => audioSource.PlayOneShot(shootSound);

    public void PlayLoseSound() => audioSource.PlayOneShot(loseSound);


}
