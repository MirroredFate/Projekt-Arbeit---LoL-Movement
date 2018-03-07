using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionController : MonoBehaviour {

    private NavMeshAgent navMeshAgent;
    private Transform waypoint;
    private Transform nexus;
    private bool waypointclear = false;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Use this for initialization
    void Start () {

        nexus = GameObject.Find("Enemy Nexus").transform;

        //Sucht die Waypoints 
        if (transform.parent.name == "Player Inhibitor Top") // Wenn das Minion teil der Top Lane ist, wird Waypoint auf die Top Lane gesetzt.
        {
            waypoint = GameObject.Find("Top Waypoint").transform;
            navMeshAgent.destination = waypoint.position;
        }

        if (transform.parent.name == "Player Inhibitor Mid" || transform.parent == null) // Wenn das Minion teil der Mid Lane ist oder keiner Lane angehört, wird Waypoint auf die Mid Lane gesetzt.
        {
            waypoint = GameObject.Find("Mid Waypoint").transform;
            navMeshAgent.destination = waypoint.position;
        }

        if (transform.parent.name == "Player Inhibitor Bot") // Wenn das Minion teil der Bot Lane ist, wird Waypoint auf die Bot Lane gesetzt.
        {
            waypoint = GameObject.Find("Bot Waypoint").transform;
            navMeshAgent.destination = waypoint.position;
        }

    }
	
	// Update is called once per frame
	void Update () {

		if (waypointclear == false) //Läuft solange zum Waypoint bis er diesen erreicht hat.
        {
            //Debug.Log(waypoint.name);
            navMeshAgent.destination = waypoint.position;
        
        }else if(waypointclear == true) // Wenn waypointclear true ist, läuft das Minion zum gegnerischen Nexus.
        {
            waypoint = GameObject.Find("Enemy Nexus").transform;
            navMeshAgent.destination = waypoint.position;
            //Debug.Log(waypoint.name);
        }


	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Waypoint") // Wenn das Minion den Waypoint erreicht, wird "waypointclear" auf true gesetzt.  
        {
            waypointclear = true;
        }
    }
}
