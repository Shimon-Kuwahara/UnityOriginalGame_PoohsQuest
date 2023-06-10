using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneScript : MonoBehaviour
{
    public AudioClip sound1;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            audioSource.PlayOneShot(sound1);
            Debug.Log("click Ok");
            Invoke("Load", 2.0f);
        }
    }

    private void Load()
    {
        SceneManager.LoadScene("Introduction");
    }
}
