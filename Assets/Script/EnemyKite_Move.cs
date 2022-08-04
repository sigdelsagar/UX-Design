using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyKite_Move : MonoBehaviour
{
    private Vector2 ScreenBounds;
    private float objectWidth;
    private float objectHeight;

    public float HorizontalSpeed;
    public float VerticalSpeed;
    public float UPAmplitude;
    public float DownAmplitude;
    public float RightAmplitude;
    public float LeftAmplitude;

    int FlagY = 0;
    int FlagX = 0;

    Vector3 TempPosition;
    public AudioClip EnemySound;

    void Start()
    {
        TempPosition = transform.position;
    }

    void Update()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, ScreenBounds.x + objectWidth, ScreenBounds.x * -1 - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, ScreenBounds.y + objectHeight, ScreenBounds.y * -1 - objectHeight);

        //transform.position = viewPos;

        if (TempPosition.x >= -12 && TempPosition.x <= 11)
        {
            PlaySound();
        }

        transform.position = TempPosition;
        //upamplitude theke kom holey vertical speed barabo
        if (FlagY == 0)
        {
            TempPosition.y += VerticalSpeed * Time.deltaTime;

            if (TempPosition.y >= UPAmplitude)
            {
                FlagY = 1;
            }
        }
        //upamplitude theke beshi holey vertical speed komabo
        else if (FlagY == 1)
        {
            TempPosition.y -= VerticalSpeed * Time.deltaTime;

            if (TempPosition.y <= DownAmplitude)
            {
                FlagY = 0;
            }
        }
        //right a jabo
        if (FlagX == 0)
        {
            TempPosition.x += HorizontalSpeed * Time.deltaTime;

            if (TempPosition.x >= RightAmplitude)
            {
                FlagX = 1;
            }
        }
        //left a jabo
        else if (FlagX == 1)
        {
            TempPosition.x -= HorizontalSpeed * Time.deltaTime;

            if (TempPosition.x <= LeftAmplitude)
            {
                FlagX = 0;
            }
        }
    }

    void PlaySound()
    {
        if (!EnemySound || GameObject.Find("Sound"))
            return;

        GameObject go = new GameObject("Sound");
        AudioSource aSrc = go.AddComponent<AudioSource>();
        aSrc.clip = EnemySound;
        aSrc.volume = 0.1f;
        aSrc.Play();

        Destroy(go, EnemySound.length);

    }
}

