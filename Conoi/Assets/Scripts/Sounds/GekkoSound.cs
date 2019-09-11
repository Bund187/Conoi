using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GekkoSound : MonoBehaviour
{
    public AudioClip gekkoSound;
    public AudioSource audioS;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (audioS.clip == gekkoSound)
            {
                StartCoroutine(LowVolume());
            }
            else
            {
                audioS.clip = gekkoSound;
                audioS.Play();
            }
        }
    }

    IEnumerator LowVolume()
    {
        while (audioS.volume > 0)
        {
            audioS.volume -= 0.01f;
            yield return null;
        }
        if (audioS.volume == 0)
        {
            audioS.clip = null;
            audioS.volume = 1;
        }
    }
}
