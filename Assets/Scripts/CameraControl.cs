using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    bool FirstPerson;
    public GameObject Player;
    //public Transform Enemy;

    // Start is called before the first frame update
    void Start()
    {
        FirstPerson = false;
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("c") && FirstPerson == false)
        {
            FirstPerson = true;
        }
        else if (Input.GetKeyDown("c") && FirstPerson)
        {
            FirstPerson = false;
        }

        if (FirstPerson)
        {
            transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z);
            //transform.rotation = new Vector3(0, 0, 0);
        }
        else if (FirstPerson == false)
        {
            transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 3, Player.transform.position.z - 10);
            //transform.rotation = new Vector3(32f, 0, 0);
        }

        //transform.LookAt(Enemy);
    }
}
