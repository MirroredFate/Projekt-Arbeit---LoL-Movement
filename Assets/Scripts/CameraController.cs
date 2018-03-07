using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    Transform target;

    float scrollPoint = 30;
    float zoffset;
    float xoffset;

    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = new Vector3(target.position.x, transform.position.y, target.position.z - 1);

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Input.mousePosition);

        if (Input.GetKey(KeyCode.Space))
        {
            transform.position = new Vector3(target.position.x, transform.position.y, target.position.z - 1);
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.mousePosition.x <= scrollPoint) // Kamera nach Links bewegen
            {
                xoffset = transform.position.x - 2 * Time.deltaTime;
                transform.position = new Vector3(xoffset, transform.position.y, transform.position.z);
            }

            if (Input.GetKey(KeyCode.RightArrow) || Input.mousePosition.x >= Screen.width - scrollPoint) // Kamera nach Rechts bewegen
            {
                xoffset = transform.position.x + 2 * Time.deltaTime;
                transform.position = new Vector3(xoffset, transform.position.y, transform.position.z);
            }

            if (Input.GetKey(KeyCode.UpArrow) || Input.mousePosition.y >= Screen.height - scrollPoint) // Kamera nach Oben bewegen 
            {
                zoffset = transform.position.z + 2 * Time.deltaTime;
                transform.position = new Vector3(transform.position.x, transform.position.y, zoffset);
            }

            if (Input.GetKey(KeyCode.DownArrow) || Input.mousePosition.y <= scrollPoint) // Kamera nach Unten bewegen
            {
                zoffset = transform.position.z - 2 * Time.deltaTime;
                transform.position = new Vector3(transform.position.x, transform.position.y, zoffset);
            }

            if (Input.mousePosition.x <= 10 && Input.mousePosition.y >= Screen.height - scrollPoint) // Kamera nach Links Oben bewegen
            {
                xoffset = transform.position.x - 2 * Time.deltaTime;
                zoffset = transform.position.z + 2 * Time.deltaTime;
                transform.position = new Vector3(xoffset, transform.position.y, zoffset);
            }

            if (Input.mousePosition.x >= Screen.width - 10 && Input.mousePosition.y >= Screen.height - scrollPoint) // Kamera nach Rechts Oben bewegen
            {
                xoffset = transform.position.x + 2 * Time.deltaTime;
                zoffset = transform.position.z + 2 * Time.deltaTime;
                transform.position = new Vector3(xoffset, transform.position.y, zoffset);
            }

            if (Input.mousePosition.x >= Screen.width - 10 && Input.mousePosition.y >= Screen.height - scrollPoint) // Kamera nach Links Unten bewegen
            {
                xoffset = transform.position.x - 2 * Time.deltaTime;
                zoffset = transform.position.z - 2 * Time.deltaTime;
                transform.position = new Vector3(xoffset, transform.position.y, zoffset);
            }

            if (Input.mousePosition.x >= Screen.width - 10 && Input.mousePosition.y >= Screen.height - scrollPoint) // Kamera nach Rechts Unten bewegen
            {
                xoffset = transform.position.x + 2 * Time.deltaTime;
                zoffset = transform.position.z - 2 * Time.deltaTime;
                transform.position = new Vector3(xoffset, transform.position.y, zoffset);
            }
        }


        if (Input.mousePosition.x > scrollPoint && Input.mousePosition.x < Screen.width - scrollPoint && Input.mousePosition.y < Screen.height - scrollPoint && Input.mousePosition.y > scrollPoint) // Stoppt die Kamera wenn die Maus nicht am Rand ist
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }



    }
}
