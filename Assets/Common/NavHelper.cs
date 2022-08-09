using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavHelper : MonoBehaviour
{

    public AudioClip clickSound;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetMouseButtonDown(0))
        {
            PlayClickSound();
        }
    }


    private void PlayClickSound()
    {
        GameObject go = new GameObject("ClickSound");
        AudioSource audioSource = go.AddComponent<AudioSource>();
        audioSource.clip = clickSound;
        audioSource.Play();
        Destroy(go, clickSound.length);
    }

    public void LoadScreen(string sceneName)
    {
        StartCoroutine(ChangeScene(sceneName));
    }

    private IEnumerator ChangeScene(string sceneName)
    {
        yield return new WaitForSeconds(clickSound.length);
        SceneManager.LoadScene(sceneName);
    }
}
