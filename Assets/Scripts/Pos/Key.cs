using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject checkScreen;
    int keycode;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        if (keycode == 0)
        {
            transform.rotation = Quaternion.Euler(90, 90, 0);
            audioSource.Play();
            keycode = 1;
        }
        else
        if (keycode == 1)
        {
            transform.rotation = Quaternion.Euler(90, 145, 0);
            audioSource.Play();
            keycode = 2;
        }
        else
        if (keycode == 2)
        {
            transform.rotation = Quaternion.Euler(90, 30, 0);
            audioSource.Play();

            keycode = 3;
        }
        else
        if (keycode == 3)
        {
            transform.rotation = Quaternion.Euler(90, 60, 0);
            audioSource.Play();

            keycode = 0;
        }
        if (keycode == 1)
        {
            StageManager.stageManager.Stage610();
            checkScreen.SetActive(true);
        }
        if (keycode == 2)
        {
            checkScreen.SetActive(false);
        }
    }
}
