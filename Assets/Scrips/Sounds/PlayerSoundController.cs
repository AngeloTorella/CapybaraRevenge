using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundController : MonoBehaviour
{

    [SerializeField] List<AudioClip> audioClips;

    private AudioSource audioSource;

    private bool isRolling;
    private bool isReloading;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        isRolling = false;
        isReloading = false;
    }

    private void Update()
    {
        if (isRolling)
            return;

        if (this.GetComponent<Rigidbody2D>().velocity.x != 0.0f)
        {
            audioSource.clip = audioClips[0];
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }

        }
        else
        {
            audioSource.Stop();
        }
    }

    public IEnumerator Roll()
    {
        isRolling = true;

        if (audioSource.isPlaying)
            audioSource.Stop();

        audioSource.clip = audioClips[1];
        audioSource.Play();
        yield return new WaitForSeconds(0.54f);
        isRolling = false;
    }

    public IEnumerator Reload()
    {
        isReloading = true;

        if (audioSource.isPlaying)
            audioSource.Stop();

        audioSource.clip = audioClips[3];
        audioSource.Play();
        yield return new WaitForSeconds(4.0f);
        isReloading = false;
    }
}
