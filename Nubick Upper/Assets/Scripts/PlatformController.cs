using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private GameObject player;
    private int moveDirection;
    private bool hasToMove = true;
    private float lvl;

    private void Awake()
    {
        moveSpeed = PlayerPrefs.GetFloat("speedPlatform");
        player = GameObject.FindGameObjectWithTag("Player");
        moveDirection = transform.position.x < player.transform.position.x ? 1 : -1;
    }
    private void Update()
    {
        if(hasToMove == true)
        {
            transform.position += Vector3.right * moveDirection * moveSpeed * Time.deltaTime;
        }   
    }
    public void StopMovement()
    {
        if(PlayerPrefs.GetFloat("lvl") > 1)
        {
            moveSpeed += 0.05f;
            PlayerPrefs.SetFloat("speedPlatform", moveSpeed);
        }
        lvl = PlayerPrefs.GetFloat("lvl");
        lvl += 0.2f;
        PlayerPrefs.SetFloat("lvl", lvl);
        hasToMove = false;
        Invoke("DestroyPlatform", 10f);
    }
    private void DestroyPlatform()
    {
        Destroy(gameObject);
    }
}
