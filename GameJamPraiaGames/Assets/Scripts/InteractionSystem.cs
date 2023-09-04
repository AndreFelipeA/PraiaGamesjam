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

    public float eatCooldown;
    bool readyToScare = true;
    bool readyToEat = true;
    public Animator animator;

    private bool isDead = false;
    public SFXPlayer sfxPlayer;

    public delegate void PlayerDeath();
    public static event PlayerDeath OnPlayerDead;

   
    void Update()
    {
        if(isDead == false)
        {
            int button = InteractInput();
            if(button == 1)
            {
                if(DetectObject())
                {
                    if(detectedObject.layer == 6)
                    {
                        detectedObject.GetComponent<Item>().Interact();
                    }
                    
                }
            }
            else if(button == 2)
            {
                if(DetectObject())
                {
                    if(detectedObject.layer == 7)
                    {
                        detectedObject.GetComponent<NPC>().Interact();
                    }
                    
                }
            }

        }
    }

    int InteractInput()
    {
        if(Input.GetButtonDown("Fire1") && readyToScare == true){
            Scare();
            return 1;
        }
        else if(Input.GetButtonDown("Fire2") && readyToEat == true)
        {
            Eat();
            return 2;
        }
        return 0;
    }

    void Eat()
    {
        if(readyToEat)
        {
            readyToEat = false;
            Invoke(nameof(ResetEat), eatCooldown);
            sfxPlayer.PlayBite();
            animator.SetBool("biting", true);
            
        }
    }

    void Scare()
    {
        if (readyToScare)
        {
            readyToScare = false;
            Invoke(nameof(ResetScare), scareCooldown);
            sfxPlayer.PlayScare();
            animator.SetBool("scaring", true);
            
        }

    }


    private void ResetScare()
    {
        animator.SetBool("scaring", false);
        readyToScare = true;
    }

    private void ResetEat()
    {
        animator.SetBool("biting", false);
        readyToEat = true;
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
