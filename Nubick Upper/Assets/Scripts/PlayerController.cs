using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public UnityEvent Landed;
    public UnityEvent Dead;

    [SerializeField] private float jumpForce;
    [SerializeField] private ContactFilter2D platform;

    public Rigidbody2D rb;

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
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionObject = collision.gameObject;

        if (collisionObject.transform.parent != null) 
        {
            if(collisionObject.transform.parent.TryGetComponent(out PlatformController platform))
            {
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
}
