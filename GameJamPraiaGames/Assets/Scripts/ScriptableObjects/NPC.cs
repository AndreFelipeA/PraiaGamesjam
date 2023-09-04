using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;



public enum State 
{
    Awaken,
    Dreaming,
    Nightmare,
}
[RequireComponent(typeof(CircleCollider2D))]
[Serializable]
public class NPC : MonoBehaviour
{

    public State state;
    public bool likesLight;
    public bool likesNoise;

    public Sprite sleeping;
    public Sprite awake;

    public GameObject itemChecker;

    public List<GameObject> items = new List<GameObject>();

    private int soundItems;
    private int lightItems;

    public bool isAwake;

    public float awakeCooldown;


    public GameObject dream;


    void Start()
    {
        itemChecker = transform.GetChild(0).gameObject;
        CheckList();
    }
    void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
        gameObject.layer = 7;
    }
    


    // Update is called once per frame
    void Update()
    {
        StateHandler();
    }

    public void Interact()
    {
        switch(state)
        {
            case State.Dreaming:
                Awake();
            break;
            case State.Awaken:
                Nightmare();
            break;
            case State.Nightmare:
                Sleeping();
            break;

        }
    }   

    public void Awake()
    {
        this.state = State.Awaken;
        this.GetComponent<SpriteRenderer>().sprite = awake;
        isAwake = true;
        Invoke(nameof(ResetAwake), awakeCooldown);

        dream.GetComponent<Dream>().state = State.Awaken;

    }

    private void ResetAwake()
    {
        isAwake = false;
    }

    void Sleeping()
    {
        if(isAwake == false)
        {
            this.state = State.Dreaming;
            this.GetComponent<SpriteRenderer>().sprite = sleeping;

            dream.GetComponent<Dream>().state = State.Dreaming;


        }
    }

    void Nightmare()
    {
        if(isAwake == false)
        {
            this.state = State.Nightmare;
            this.GetComponent<SpriteRenderer>().sprite = sleeping;

            dream.GetComponent<Dream>().state = State.Nightmare;


        }
    }




    void CheckList()
    {
        foreach(GameObject obj in items)
        {
            Item item = obj.GetComponent<Item>();
            if(item.state == ItemState.On && item.type == ItemType.Light)
            {
                lightItems++;
            }

            if(item.state == ItemState.On && item.type == ItemType.Sound)
            {
                soundItems++;
            }
        }
    }

    void StateHandler()
    {
        if(likesLight == true && lightItems == 1 && likesNoise == true && soundItems == 1)
        {
            Sleeping();
        }
        if(likesLight == true && lightItems == 1 && likesNoise == true && soundItems == 0)
        {
            Nightmare();
        }
        if(likesLight == false && lightItems == 1 && likesNoise == true && soundItems == 1)
        {
            Sleeping();
        }


    }

}
