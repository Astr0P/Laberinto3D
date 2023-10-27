using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbControl : MonoBehaviour
{
    Rigidbody rb;
    float MoveSpeed = 10f;
    float Jump = 5f;
    bool puedeSaltar = true;
    public GameObject GameOver;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float HorInput = Input.GetAxis("Horizontal") * MoveSpeed;
        float VerInput = Input.GetAxis("Vertical") * MoveSpeed;

        rb.velocity = new Vector3(HorInput, rb.velocity.y, VerInput);

        if (Input.GetButtonDown("Jump") && puedeSaltar)
        {
            rb.velocity = new Vector3(rb.velocity.x, Jump, rb.velocity.z);
            puedeSaltar = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Terrain")
        {
            puedeSaltar = true;
        }
        if (collision.gameObject.name == "Enemy" || collision.gameObject.tag == "Void")
        {    
            GameOver.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    
}
