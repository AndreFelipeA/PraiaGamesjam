using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


[RequireComponent(typeof(SpriteRenderer))]

public class Dream : MonoBehaviour
{
    public Sprite dreaming;
    public Sprite nightmare;

    public Sprite awaken;
    
    public State state;
     void Update()
    {
        switch (state)
        {
            case State.Awaken:
                this.GetComponent<SpriteRenderer>().sprite = awaken;
                
            break;
            case State.Dreaming:

                this.GetComponent<SpriteRenderer>().sprite = dreaming;
            break;
            case State.Nightmare:
                this.GetComponent<SpriteRenderer>().sprite = nightmare;
            break;

        }
    }


}
