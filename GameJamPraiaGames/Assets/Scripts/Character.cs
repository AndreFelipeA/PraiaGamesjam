using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    float horizontalMove = 0f;
    int cooldown;
    public Animator animator;
    UnityEvent KeyPress;
    // Start is called before the first frame update
    void Start()
    {
        //Codigo do Andras

        //if(KeyPress == null) KeyPress = new UnityEvent();

        //KeyPress.AddListener(Scare);
        //cooldown = 20; 
    }

    // Update is called once per frame
    void Update()
    {
        cooldown--;
        if (cooldown < 0)
            cooldown = 0;

        Scare();
        movementAnimation();

        //Codigo do Andras

        /*if(Input.GetKeyDown("h") && KeyPress != null)
        {
            KeyPress.Invoke();
        }
        if(cooldown > 0){
            cooldown--;
        }else if(cooldown == 0){
            canScare = true;
        }*/

    }
    void Scare()
    {
        if (Input.GetKeyDown("h") && cooldown == 0){
            animator.SetBool("scaring", true);
            cooldown = 200;
        }
        if (cooldown < 19.5)
            animator.SetBool("scaring", false);
    }

    void movementAnimation()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        if (horizontalMove != 0)
            animator.SetBool("moving", true);
        else
            animator.SetBool("moving", false);
    }
}
