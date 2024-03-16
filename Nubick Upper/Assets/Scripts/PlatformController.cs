using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private GameObject player;
    private int moveDirection;
    private bool hasToMove = true;

    private void Awake()
    {
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
        hasToMove = false;
        Invoke("DestroyPlatform", 10f);
    }
    private void DestroyPlatform()
    {
        Destroy(gameObject);
    }
}
