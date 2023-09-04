using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{

    public List<GameObject> npcs = new List<GameObject>();


    private bool isOver = false;

    int npcCount;
    void Start()
    {
        PlayerMovement.OnGameOver += GameOver;
        Timer.OnTimeOver += GameOver;
        npcCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(isOver)
        {
            ReloadLevel();
        }
        npcCount = CheckNpcs();
        if(npcCount == npcs.Count)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        }
    }


    private int CheckNpcs()
    {
        int Count = 0;
        foreach(GameObject obj in npcs)
        {
            NPC npc = obj.GetComponent<NPC>();

            if(npc.ate == true)
            {
                Count++;
            }
        }

        return Count;
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        isOver = true;
    }
}
