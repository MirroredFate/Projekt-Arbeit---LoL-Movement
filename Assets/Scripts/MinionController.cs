using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionController : MonoBehaviour
{

    NavMeshAgent navMeshAgent;
    Transform waypoint;
    Transform nexus;
    Transform playernexus;
    bool waypointclear = false;
    bool player;




    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Use this for initialization
    void Start()
    {
        #region Pathfinding Waypoints
        nexus = GameObject.Find("Enemy Nexus").transform;
        playernexus = GameObject.FindGameObjectWithTag("Player Nexus").transform;

        //Sucht die Waypoints 

        // Wenn das Minion teil der Top Lane ist, wird Waypoint auf die Top Lane gesetzt.
        if (transform.parent.name == "Player Inhibitor Top") 
        {
            player = true;
            waypoint = GameObject.Find("Top Waypoint").transform;
            navMeshAgent.destination = waypoint.position;
            Debug.Log("Player: " + player);
        }

        // Wenn das Minion teil der Mid Lane ist oder keiner Lane angehört, wird Waypoint auf die Mid Lane gesetzt.
        if (transform.parent.name == "Player Inhibitor Mid" || transform.parent == null) 
        {
            player = true;
            waypoint = GameObject.Find("Mid Waypoint").transform;
            navMeshAgent.destination = waypoint.position;
            Debug.Log("Player" + player);
        }

        // Wenn das Minion teil der Bot Lane ist, wird Waypoint auf die Bot Lane gesetzt.
        if (transform.parent.name == "Player Inhibitor Bot") 
        {
            player = true;
            waypoint = GameObject.Find("Bot Waypoint").transform;
            navMeshAgent.destination = waypoint.position;
            Debug.Log("Player " + player);
        }

        // Wenn das Minion teil der Top Lane ist, wird Waypoint auf die Top Lane gesetzt.
        if (transform.parent.name == "Enemy Inhibitor Top") 
        {
            player = false;
            waypoint = GameObject.Find("Top Waypoint").transform;
            navMeshAgent.destination = waypoint.position;
            Debug.Log("Enemy " + player);
        }

        // Wenn das Minion teil der Mid Lane ist oder keiner Lane angehört, wird Waypoint auf die Mid Lane gesetzt.
        if (transform.parent.name == "Enemy Inhibitor Mid" || transform.parent == null) 
        {
            player = false;
            waypoint = GameObject.Find("Mid Waypoint").transform;
            navMeshAgent.destination = waypoint.position;
            Debug.Log("Enemy " + player);
        }

        // Wenn das Minion teil der Bot Lane ist, wird Waypoint auf die Bot Lane gesetzt.
        if (transform.parent.name == "Enemy Inhibitor Bot") 
        {
            player = false;
            waypoint = GameObject.Find("Bot Waypoint").transform;
            navMeshAgent.destination = waypoint.position;
            Debug.Log("Enemy " + player);
        }
        #endregion

    }


    // Update is called once per frame
    void Update()
    {
        #region Pathfinding Update
        //Läuft solange zum Waypoint bis er diesen erreicht hat.
        if (waypointclear == false) 
        {
            //Debug.Log(waypoint.name);
            navMeshAgent.destination = waypoint.position;

        }
        // Wenn waypointclear true ist, läuft das Minion zum gegnerischen Nexus.
        else if (waypointclear == true) 
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
                //Debug.Log(waypoint.name);
            }
        }
        #endregion

    }



    private void OnTriggerEnter(Collider other)
    {
        // Wenn das Minion den Waypoint erreicht, wird "waypointclear" auf true gesetzt.
        if (other.tag == "Waypoint")   
        {
            waypointclear = true;
        }

    }

  

}
