using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    Transform target;

    float scrollPoint = 40;
    float zspeed;
    float xspeed;

    // Map Borders
    float topborder = 10;
    float downborder = -10.5f;
    float leftborder = -11;
    float rightborder = 10;
    bool lockedCamera = false;

    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = new Vector3(target.position.x, transform.position.y, target.position.z - 1);

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.Z))
        {
            lockedCamera = !lockedCamera;
        }

      

        if (Input.GetKey(KeyCode.Space) || lockedCamera == true)
        {
            Vector3 jumpBack = Vector3.Lerp(transform.position, target.position, 10);
            transform.position = new Vector3(jumpBack.x, transform.position.y, jumpBack.z - 1);
        }
        else
        {
            if (Input.mousePosition.x <= scrollPoint && transform.position.x > leftborder) // Kamera nach Links bewegen
            {
                xspeed = transform.position.x - 2 * Time.deltaTime;
                transform.position = new Vector3(xspeed, transform.position.y, transform.position.z);
            }

            if (Input.mousePosition.x >= Screen.width - scrollPoint && transform.position.x < rightborder) // Kamera nach Rechts bewegen
            {
                xspeed = transform.position.x + 2 * Time.deltaTime;
                transform.position = new Vector3(xspeed, transform.position.y, transform.position.z);
            }

            if (Input.mousePosition.y >= Screen.height - scrollPoint && transform.position.z < topborder) // Kamera nach Oben bewegen 
            {
                zspeed = transform.position.z + 2 * Time.deltaTime;
                transform.position = new Vector3(transform.position.x, transform.position.y, zspeed);
            }

            if (Input.mousePosition.y <= scrollPoint && transform.position.z > downborder) // Kamera nach Unten bewegen
            {
                zspeed = transform.position.z - 2 * Time.deltaTime;
                transform.position = new Vector3(transform.position.x, transform.position.y, zspeed);
            }

            if (Input.mousePosition.x <= 10 && Input.mousePosition.y >= Screen.height - scrollPoint && transform.position.x > leftborder && transform.position.z < topborder) // Kamera nach Links Oben bewegen
            {
                xspeed = transform.position.x - 2 * Time.deltaTime;
                zspeed = transform.position.z + 2 * Time.deltaTime;
                transform.position = new Vector3(xspeed, transform.position.y, zspeed);
            }

            if (Input.mousePosition.x >= Screen.width - 10 && Input.mousePosition.y >= Screen.height - scrollPoint && transform.position.x < rightborder && transform.position.z < topborder) // Kamera nach Rechts Oben bewegen
            {
                xspeed = transform.position.x + 2 * Time.deltaTime;
                zspeed = transform.position.z + 2 * Time.deltaTime;
                transform.position = new Vector3(xspeed, transform.position.y, zspeed);
            }

            if (Input.mousePosition.x >= Screen.width - 10 && Input.mousePosition.y >= Screen.height - scrollPoint && transform.position.x > leftborder && transform.position.z > downborder) // Kamera nach Links Unten bewegen
            {
                xspeed = transform.position.x - 2 * Time.deltaTime;
                zspeed = transform.position.z - 2 * Time.deltaTime;
                transform.position = new Vector3(xspeed, transform.position.y, zspeed);
            }

            if (Input.mousePosition.x >= Screen.width - 10 && Input.mousePosition.y >= Screen.height - scrollPoint && transform.position.x < rightborder && transform.position.z > downborder) // Kamera nach Rechts Unten bewegen
            {
                xspeed = transform.position.x + 2 * Time.deltaTime;
                zspeed = transform.position.z - 2 * Time.deltaTime;
                transform.position = new Vector3(xspeed, transform.position.y, zspeed);
            }
        }


        if (Input.mousePosition.x > scrollPoint && Input.mousePosition.x < Screen.width - scrollPoint && Input.mousePosition.y < Screen.height - scrollPoint && Input.mousePosition.y > scrollPoint) // Stoppt die Kamera wenn die Maus nicht am Rand ist
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }



    }
}
