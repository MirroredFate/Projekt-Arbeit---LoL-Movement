using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionController : MonoBehaviour
{

    private NavMeshAgent navMeshAgent;
    private Transform waypoint;
    private Transform nexus;
    private Transform playernexus;
    private bool waypointclear = false;
    private bool player;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Use this for initialization
    void Start()
    {

        nexus = GameObject.Find("Enemy Nexus").transform;
        playernexus = GameObject.FindGameObjectWithTag("Player Nexus").transform;

        //Sucht die Waypoints 
        if (transform.parent.name == "Player Inhibitor Top") // Wenn das Minion teil der Top Lane ist, wird Waypoint auf die Top Lane gesetzt.
        {
            player = true;
            waypoint = GameObject.Find("Top Waypoint").transform;
            navMeshAgent.destination = waypoint.position;
            Debug.Log("Player: " + player);
        }

        if (transform.parent.name == "Player Inhibitor Mid" || transform.parent == null) // Wenn das Minion teil der Mid Lane ist oder keiner Lane angehört, wird Waypoint auf die Mid Lane gesetzt.
        {
            player = true;
            waypoint = GameObject.Find("Mid Waypoint").transform;
            navMeshAgent.destination = waypoint.position;
            Debug.Log("Player" + player);
        }

        if (transform.parent.name == "Player Inhibitor Bot") // Wenn das Minion teil der Bot Lane ist, wird Waypoint auf die Bot Lane gesetzt.
        {
            player = true;
            waypoint = GameObject.Find("Bot Waypoint").transform;
            navMeshAgent.destination = waypoint.position;
            Debug.Log("Player " + player);
        }

        if (transform.parent.name == "Enemy Inhibitor Top") // Wenn das Minion teil der Top Lane ist, wird Waypoint auf die Top Lane gesetzt.
        {
            player = false;
            waypoint = GameObject.Find("Top Waypoint").transform;
            navMeshAgent.destination = waypoint.position;
            Debug.Log("Enemy " + player);
        }

        if (transform.parent.name == "Enemy Inhibitor Mid" || transform.parent == null) // Wenn das Minion teil der Mid Lane ist oder keiner Lane angehört, wird Waypoint auf die Mid Lane gesetzt.
        {
            player = false;
            waypoint = GameObject.Find("Mid Waypoint").transform;
            navMeshAgent.destination = waypoint.position;
            Debug.Log("Enemy " + player);
        }

        if (transform.parent.name == "Enemy Inhibitor Bot") // Wenn das Minion teil der Bot Lane ist, wird Waypoint auf die Bot Lane gesetzt.
        {
            player = false;
            waypoint = GameObject.Find("Bot Waypoint").transform;
            navMeshAgent.destination = waypoint.position;
            Debug.Log("Enemy " + player);
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (waypointclear == false) //Läuft solange zum Waypoint bis er diesen erreicht hat.
        {
            //Debug.Log(waypoint.name);
            navMeshAgent.destination = waypoint.position;

        }
        else if (waypointclear == true) // Wenn waypointclear true ist, läuft das Minion zum gegnerischen Nexus.
        {
            if (player == true)
            {
                waypoint = nexus;
                navMeshAgent.destination = waypoint.position;
                //Debug.Log(waypoint.name);

            }else
            {
                waypoint = playernexus;
                navMeshAgent.destination = waypoint.position;
                Debug.Log(waypoint.name);
            }
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Waypoint") // Wenn das Minion den Waypoint erreicht, wird "waypointclear" auf true gesetzt.  
        {
            waypointclear = true;
        }
    }
}
