using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigator : MonoBehaviour
{
    public AudioClip ClickSound;

    public void LoadScene(string sceneName)
    {
        float waitTIme = PlayClickSound();
        StartCoroutine(ChangeToScene(sceneName, waitTIme));
    }


    IEnumerator ChangeToScene(string sceneToChangeTo, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneToChangeTo);
    }


    float PlayClickSound()
    {
        GameObject go = new GameObject("Sound");
        AudioSource aSrc = go.AddComponent<AudioSource>();
        aSrc.clip = ClickSound;
        aSrc.volume = 0.7f;
        aSrc.Play();
        float len = ClickSound.length;
        Destroy(go, len);
        return len;

    }
}
