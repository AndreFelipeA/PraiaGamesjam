// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.Events;

// public class States : MonoBehaviour
// {


//     //Sonho, Pesadelo, Acordado

//     private enum State{
//         Dream, Nightmare, Awake
//     }
//     [SerializeField] private State _state;
//     public SpriteRenderer rend;
//     UnityEvent KeyPress;


//     // Start is called before the first frame update
//     void Start()
//     {
//         if(KeyPress == null) KeyPress = new UnityEvent();

//         KeyPress.AddListener(NextState);
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if(Input.GetKeyDown("g") && KeyPress != null)
//         {
//             KeyPress.Invoke();
//         }
//         switch(_state)
//         {
//             case State.Dream:
//                 rend.color = new Color(0, 10, 10, 255);
//                 break;
//             case State.Nightmare:
//                 rend.color = new Color(10, 0, 0, 255);
//                 break;
//             case State.Awake:
//                 rend.color = new Color(0, 0, 10, 0);
//                 break;
//             default: break;
//         }
//     }


//     void NextState()
//     {
//         _state++;
//         if(_state > State.Awake)
//         {
//             _state = State.Dream;
//         }
//     }
// }


