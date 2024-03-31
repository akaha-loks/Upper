using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    public UnityEvent Landed;
    public UnityEvent Dead;
 

    [SerializeField] private GameObject spawnPlatform;

    [SerializeField] private float jumpForce;
    [SerializeField] private ContactFilter2D platform;

    [SerializeField] private AudioSource ad;

    public Rigidbody2D rb;

    private int score;

    private bool isOnPlatform => rb.IsTouching(platform);

  
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    public void Jump()
    {
        if(isOnPlatform == true)
        {
            rb.AddForce(Vector2.up *  jumpForce, ForceMode2D.Impulse);
            ad.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionObject = collision.gameObject;

        if (collisionObject.CompareTag("StartGame"))
        {
            Invoke("Spawn", 2f);
        }

        if (collisionObject.CompareTag("Finish"))
        {
            UI.LoadSceneName("Finish");
        }

        if (collisionObject.transform.parent != null) 
        {
            if(collisionObject.transform.parent.TryGetComponent(out PlatformController platform))
            {
                score++;
                PlayerPrefs.SetInt("Score", score);
                platform.StopMovement();
            }
        }
        if (collisionObject.CompareTag("DeathPlatform"))
        {
            Dead?.Invoke();
        }
        else if (collisionObject.CompareTag("Platform"))
        {
            collisionObject.tag = "Untagged";
            Landed?.Invoke();
        }
    }
    private void Spawn()
    {
        spawnPlatform.SetActive(true);
    }
}
