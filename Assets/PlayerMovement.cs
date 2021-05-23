
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float playerSpeed;
    public Player localplayer;
    AudioSource playerDestroySound;
    public AudioClip playerClip;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerDestroySound = GameObject.Find("SoundManger").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(horizontal, vertical) * playerSpeed;
        rb.position = new Vector2(Mathf.Clamp(rb.position.x, localplayer.xMin, localplayer.xMax), Mathf.Clamp(rb.position.y, localplayer.yMin, localplayer.yMax));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
            playerDestroySound.clip = playerClip;
            playerDestroySound.Play();
            SceneManager.LoadScene(2);
        }
    }

}
[System.Serializable]
public class Player
{
    public float xMin, xMax, yMin, yMax;

}
