using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    float horizontalMove = 0f;
    bool canScare = true;
    int cooldown;
    public Animator animator;
    UnityEvent KeyPress;
    // Start is called before the first frame update
    void Start()
    {
        if(KeyPress == null) KeyPress = new UnityEvent();

        KeyPress.AddListener(Scare);
        cooldown = 20; 
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("speed", horizontalMove);
        if(Input.GetKeyDown("h") && KeyPress != null)
        {
            KeyPress.Invoke();
        }
        if(cooldown > 0){
            cooldown--;
        }else if(cooldown == 0){
            canScare = true;
        }

    }
    void Scare()
    {
        if(canScare){ 
            //placeholder
        }else{
            //placeholder
        }
    }
}
