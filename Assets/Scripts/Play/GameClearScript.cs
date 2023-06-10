using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;

public class GameClearScript : MonoBehaviour
{
    public AudioClip sound;
    public AudioClip sound1;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(sound);

    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            audioSource.PlayOneShot(sound1);
            Debug.Log("click Ok");
            Invoke("Load", 2.0f);
        }
    }

    private void Load()
    {
        SceneManager.LoadScene("Stage1");
    }
}
