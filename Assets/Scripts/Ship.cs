using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ship : MonoBehaviour
{

    [SerializeField]
    float maxRelativeVelocity = 2f;

    [SerializeField]
    float maxRotation = 10f;

    [SerializeField]
    float thrustForce = 150f;

    [SerializeField]
    float torqueForce = 15f;

    [SerializeField]
    float fuel = 200f;

    [SerializeField]
    TextMeshProUGUI fueltxt;



    private void Update()
    {
        if (fuel > 0)
        {
            if (Input.GetKey(KeyCode.W))
            {
                GetComponent<Rigidbody2D>().AddForce(transform.up * thrustForce * Time.deltaTime);
                fuel -= 10 * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                GetComponent<Rigidbody2D>().AddTorque(torqueForce * Time.deltaTime);
                fuel -= 5 * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                GetComponent<Rigidbody2D>().AddTorque(-torqueForce * Time.deltaTime);
                fuel -= 5 * Time.deltaTime;
            }

            fueltxt.text = "Fuel: " + System.Convert.ToInt32(fuel).ToString();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            Debug.Log("Aterrei...");
            if (collision.relativeVelocity.magnitude > maxRelativeVelocity || Mathf.Abs(transform.localEulerAngles.z) > maxRotation)
            {
                Debug.Log("...mas explodi");
            }
        }
        else
        {
            Debug.Log("RIP");
        }

    }

}
