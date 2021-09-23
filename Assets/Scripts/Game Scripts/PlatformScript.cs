using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlatformScript : MonoBehaviour
{
    public float jumpForce = 10f;
    AudioSource m_AudioSource;
    public LevelGeneratorScript lgs;
    public Camera camera;
    Vector3 bottomLeftWorld,topRightWorld;
    public Animator animator;

    void Start()
    {
        m_AudioSource = GetComponent<AudioSource> ();
        bottomLeftWorld = camera.ViewportToWorldPoint(new Vector3(0, 0, camera.nearClipPlane));
        topRightWorld = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if(collision.collider.name == "Character")
            {
            if(rb != null)
            {   
                m_AudioSource.Play();
                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;
                StartCoroutine(Wait());
                
            }
            
            } 
        }
       
    }

    
   public void OnCollisionExit2D(Collision2D collision)
    {
       if(collision.collider.name == "DeathZone")
            {
                transform.position = new Vector3(Random.Range(bottomLeftWorld.x, topRightWorld.x), Random.Range(transform.position.y +5f,transform.position.y + 5f),0);
            }
    }

    IEnumerator Wait ()
    {
        animator.SetBool("isPop",true);
        yield return new WaitForSeconds(0.1f);
        transform.position = new Vector3(Random.Range(bottomLeftWorld.x, topRightWorld.x), Random.Range(transform.position.y +5f,transform.position.y + 5f),0);
        animator.SetBool("isPop",false);
        
    }
    
}
