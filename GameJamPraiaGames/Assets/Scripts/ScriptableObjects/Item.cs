using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum ItemState
{ 
    On,
    Off,
}

public enum ItemType
{
    Light,
    Sound,
}

public class Item : MonoBehaviour
{
    public ItemState state;
    public ItemType type;

    public NPC npc;


    void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
        gameObject.layer = 6;
    }
    
    
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if(state == ItemState.On)
        {
            this.GetComponent<SpriteRenderer>().color = new Color (0,255,0);

        }
        else
        {
            this.GetComponent<SpriteRenderer>().color = new Color (254,0,0);
        }
    }

    public void Interact()
    {
        switch(state)
        {
            case ItemState.On:
                TurnOff();
            break;
            case ItemState.Off:
                TurnOn();
            break;

        }
    }   

    void TurnOn()
    {
        this.state = ItemState.On;
        if(npc.ate == false)
        {

            npc.Awake();
        }
    }

    void TurnOff()
    {
        this.state = ItemState.Off;
        if(npc.ate == false)
        {

            npc.Awake();
        }
    }


}