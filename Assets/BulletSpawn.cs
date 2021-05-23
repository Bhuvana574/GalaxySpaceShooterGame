
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    public GameObject bullet;//reference of the bullet
    AudioSource bulletaudio;
    public AudioClip bulletsound;
    // Start is called before the first frame update
    void Start()
    {
        bulletaudio = GameObject.Find("SoundManger").GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bulletRef = Instantiate(bullet);
            bulletRef.transform.position = transform.position + new Vector3(0, 0.45f, 0);
            bulletaudio.clip = bulletsound;
            bulletaudio.Play();

        }
    }
}
