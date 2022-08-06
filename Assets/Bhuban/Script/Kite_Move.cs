using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kite_Move : MonoBehaviour
{
    public GameObject kite;
    public string secne;
    public AudioClip CrashSound;

    public Vector2 force;

    public Vector3 scale;
    public Vector3 MaxScale;
    public Vector3 MinScale;

    public bool dead;
    private Vector2 ScreenBounds;
    private float objectWidth;
    private float objectHeight;


    void Start()
    {
        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<MeshRenderer>().bounds.size.x / 2;
        objectHeight = transform.GetComponent<MeshRenderer>().bounds.size.y / 2;

    }

    void Update()
    {
        //Vector3 viewPos = transform.position;
        //viewPos.x = Mathf.Clamp(viewPos.x, ScreenBounds.x +  objectWidth, ScreenBounds.x * -1 - objectWidth);
        //viewPos.y = Mathf.Clamp(viewPos.y, ScreenBounds.y + objectHeight, ScreenBounds.y * -1 - objectHeight);

        //transform.position = viewPos;
        if (!dead)
        {
            if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightShift))              //to decrise the size of kite 
            {
                if (transform.localScale.x > MinScale.x)
                {
                    kite.gameObject.transform.localScale -= scale;
                }
            }

            else if (Input.GetKey(KeyCode.UpArrow))
            {
                GetComponent<Rigidbody>().AddForce(new Vector2(0, force.y));
            }

            else if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightShift))
            {
                if (transform.localScale.x < MaxScale.x)
                {
                    kite.gameObject.transform.localScale += scale;
                    GetComponent<Rigidbody>().AddForce(new Vector2(0, -force.y));
                }
            }

            else if (Input.GetKey(KeyCode.DownArrow))
            {
                GetComponent<Rigidbody>().AddForce(new Vector2(0, -force.y));
            }

            else if (Input.GetKey(KeyCode.RightArrow))
            {
                GetComponent<Rigidbody>().AddForce(new Vector2(force.x, 0));
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                GetComponent<Rigidbody>().AddForce(new Vector2(-force.x, 0));
            }

        }
        else if (dead)
        {
            this.GetComponent<Rigidbody>().useGravity = true;
            //GetComponent<Rigidbody>().freezeRotation = true;

            LoadSceneNow();
        }


    }

    private void OnBecameInvisible()
    {
        Debug.Log("Out of screen");
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag == "Enemy_Kite")
        {
            col.rigidbody.useGravity = true;
        }
        dead = true;

        PlayCrashSound();

        StartCoroutine(ChangeToScene("EndGame"));
    }


    void PlayCrashSound()
    {
        GameObject go = new GameObject("Sound");
        AudioSource aSrc = go.AddComponent<AudioSource>();
        aSrc.clip = CrashSound;
        aSrc.volume = 0.7f;
        aSrc.Play();

        Destroy(go, CrashSound.length);

    }


    void LoadSceneNow()
    {
        new WaitForSeconds(5);
        //SceneManager.LoadScene(secne);

    }
    IEnumerator ChangeToScene(string sceneToChangeTo)
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(sceneToChangeTo);
    }
}
