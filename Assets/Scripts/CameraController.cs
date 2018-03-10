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
    float downborder = -12;
    float leftborder = -11.5f;
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

        //Setzt locked auf true oder false, je nachdem was es vor dem Drücken war. 
        if (Input.GetKeyDown(KeyCode.Z))
        {
            lockedCamera = !lockedCamera;
        }

      
        //Wenn Leertaste gedrückt wird oder lockedCamera auf true ist, so wird die Kamera auf den Spieler fokussiert.  
        if (Input.GetKey(KeyCode.Space) || lockedCamera == true)
        {
            Vector3 jumpBack = Vector3.Lerp(transform.position, target.position, 10);
            transform.position = new Vector3(jumpBack.x, transform.position.y, jumpBack.z - 1);
        }
        else
        {
            // Kamera nach Links bewegen
            if (Input.mousePosition.x <= scrollPoint && transform.position.x > leftborder) 
            {
                xspeed = transform.position.x - 2 * Time.deltaTime;
                transform.position = new Vector3(xspeed, transform.position.y, transform.position.z);
            }

            // Kamera nach Rechts bewegen
            if (Input.mousePosition.x >= Screen.width - scrollPoint && transform.position.x < rightborder) 
            {
                xspeed = transform.position.x + 2 * Time.deltaTime;
                transform.position = new Vector3(xspeed, transform.position.y, transform.position.z);
            }

            // Kamera nach Oben bewegen
            if (Input.mousePosition.y >= Screen.height - scrollPoint && transform.position.z < topborder)  
            {
                zspeed = transform.position.z + 2 * Time.deltaTime;
                transform.position = new Vector3(transform.position.x, transform.position.y, zspeed);
            }

            // Kamera nach Unten bewegen
            if (Input.mousePosition.y <= scrollPoint && transform.position.z > downborder) 
            {
                zspeed = transform.position.z - 2 * Time.deltaTime;
                transform.position = new Vector3(transform.position.x, transform.position.y, zspeed);
            }

            // Kamera nach Links Oben bewegen
            if (Input.mousePosition.x <= 10 && Input.mousePosition.y >= Screen.height - scrollPoint && transform.position.x > leftborder && transform.position.z < topborder) 
            {
                xspeed = transform.position.x - 2 * Time.deltaTime;
                zspeed = transform.position.z + 2 * Time.deltaTime;
                transform.position = new Vector3(xspeed, transform.position.y, zspeed);
            }

            // Kamera nach Rechts Oben bewegen
            if (Input.mousePosition.x >= Screen.width - 10 && Input.mousePosition.y >= Screen.height - scrollPoint && transform.position.x < rightborder && transform.position.z < topborder) 
            {
                xspeed = transform.position.x + 2 * Time.deltaTime;
                zspeed = transform.position.z + 2 * Time.deltaTime;
                transform.position = new Vector3(xspeed, transform.position.y, zspeed);
            }

            // Kamera nach Links Unten bewegen
            if (Input.mousePosition.x >= Screen.width - 10 && Input.mousePosition.y >= Screen.height - scrollPoint && transform.position.x > leftborder && transform.position.z > downborder) 
            {
                xspeed = transform.position.x - 2 * Time.deltaTime;
                zspeed = transform.position.z - 2 * Time.deltaTime;
                transform.position = new Vector3(xspeed, transform.position.y, zspeed);
            }

            // Kamera nach Rechts Unten bewegen
            if (Input.mousePosition.x >= Screen.width - 10 && Input.mousePosition.y >= Screen.height - scrollPoint && transform.position.x < rightborder && transform.position.z > downborder) 
            {
                xspeed = transform.position.x + 2 * Time.deltaTime;
                zspeed = transform.position.z - 2 * Time.deltaTime;
                transform.position = new Vector3(xspeed, transform.position.y, zspeed);
            }
        }

        // Stoppt die Kamera wenn die Maus nicht am Rand ist
        if (Input.mousePosition.x > scrollPoint && Input.mousePosition.x < Screen.width - scrollPoint && Input.mousePosition.y < Screen.height - scrollPoint && Input.mousePosition.y > scrollPoint) 
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }



    }
}
