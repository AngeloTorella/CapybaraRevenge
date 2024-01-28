using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSoundController : MonoBehaviour
{

    [SerializeField] List<AudioClip> audioClips;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    public IEnumerator Reload()
    {
        if (audioSource.isPlaying)
            audioSource.Stop();

        audioSource.clip = audioClips[1];
        audioSource.Play();
        yield return new WaitForSeconds(4.0f);
    }

    public IEnumerator Shoot()
    {
        if (audioSource.isPlaying)
            audioSource.Stop();

        audioSource.clip = audioClips[0];
        audioSource.Play();
        yield return new WaitForSeconds(0.01f);
    }

}
