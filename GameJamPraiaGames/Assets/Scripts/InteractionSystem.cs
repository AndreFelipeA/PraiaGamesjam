using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    public Transform detectionPoint;
    private const float detectionRadius =0.2f;
    public LayerMask detectionLayer;

    public GameObject detectedObject;

    
    public float scareCooldown;
    bool readyToScare = true;
    public Animator animator;

    private bool isDead = false;
    
    public delegate void PlayerDeath();
    public static event PlayerDeath OnPlayerDead;
    void Update()
    {
        if(isDead == false)
        {
            if(InteractInput())
            {
                if(DetectObject())
                {
                    print(detectedObject.name);
                    if(detectedObject.layer == 7)
                    {

                        detectedObject.GetComponent<NPC>().Interact();
                    }
                    else
                        detectedObject.GetComponent<Item>().Interact();
                    
                }
            }

        }
    }

    bool InteractInput()
    {
        if(Input.GetButtonDown("Fire1") && readyToScare == true){
            Scare();
            return true;
        }
        return false;
    }

    void Scare()
    {
        if (readyToScare)
        {
            readyToScare = false;
            Invoke(nameof(ResetScare), scareCooldown);
            animator.SetBool("scaring", true);
        }

    }


    private void ResetScare()
    {
        animator.SetBool("scaring", false);
        readyToScare = true;
    }


    bool DetectObject()
    {

        Collider2D obj =  Physics2D.OverlapCircle(detectionPoint.position,detectionRadius,detectionLayer);
        if(obj != null)
        {
            detectedObject = obj.gameObject;
            return true;
        }
        detectedObject = null;
        return false;

    }



    void OnTriggerEnter2D(Collider2D other)
    {
        print(other.gameObject.layer);
        if(other.gameObject.layer == 7)
        {
            if(other.gameObject.GetComponent<NPC>().state == State.Awaken)
            {
                isDead = true;
                if(OnPlayerDead != null)
                {
                    OnPlayerDead();
                }
            }
        }
       
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(detectionPoint.position,detectionRadius);
    }
}
