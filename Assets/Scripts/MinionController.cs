using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionController : MonoBehaviour
{
    public float attackRate = .5f;
    public int attackDamage = 1;
    public int hp = 20;

    NavMeshAgent navMeshAgent;
    Transform waypoint;
    Transform nexus;
    Transform playernexus;
    Transform target;
    MinionController minion;
    bool waypointclear = false;
    bool player;
    bool enemyTargeted;
    float nextAttack;




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
            Debug.Log("Player " + player);
        }

        // Wenn das Minion teil der Mid Lane ist oder keiner Lane angehört, wird Waypoint auf die Mid Lane gesetzt.
        if (transform.parent.name == "Enemy Inhibitor Mid" || transform.parent == null)
        {
            player = false;
            waypoint = GameObject.Find("Mid Waypoint").transform;
            navMeshAgent.destination = waypoint.position;
            Debug.Log("Player " + player);
        }

        // Wenn das Minion teil der Bot Lane ist, wird Waypoint auf die Bot Lane gesetzt.
        if (transform.parent.name == "Enemy Inhibitor Bot")
        {
            player = false;
            waypoint = GameObject.Find("Bot Waypoint").transform;
            navMeshAgent.destination = waypoint.position;
            Debug.Log("Player " + player);
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

            }
            else
            {
                waypoint = playernexus;
                navMeshAgent.destination = waypoint.position;
                //Debug.Log(waypoint.name);
            }
        }
        #endregion

        #region Attack Update
        //Wenn die HP auf 0 ist, wird das Objekt zerstört. 
        if (hp <= 0)
        {
            Destroy(gameObject);
        }

        //Sollte das Minion ein Ziel haben (also enemyTargeted = true), wird Attack() ausgeführt. 
        if (enemyTargeted)
        {
            Attack();
        }
        //Wenn nicht, soll sich das Minion weiter bewegen. 
        else 
        {
            //Debug.Log("No minion in sight");
            navMeshAgent.isStopped = false;
        }
#endregion

    }



    private void OnTriggerEnter(Collider other)
    {
        #region Pathfinding
        // Wenn das Minion den Waypoint erreicht, wird "waypointclear" auf true gesetzt.
        if (other.tag == "Waypoint")
        {
            waypointclear = true;
        }
#endregion

        #region Angreifen
        //Wenn ein gegnerisches Minion in Reichweite ist, wird enemyTargeted auf true gesetzt, damit angegriffen werden kann. 
        if (other.tag == "Enemy Minion" && player == true)
        {
            enemyTargeted = true;
            target = other.transform;


            /*navMeshAgent.isStopped = true;
            target = other.transform;
            minion = target.GetComponent<MinionController>();
            Attack();*/
        }
        //Sonst soll das Minion sich weiter bewegen. 
        else
        {
            enemyTargeted = false;
            navMeshAgent.destination = waypoint.position;
            navMeshAgent.isStopped = false;
        }

        //Das gleiche, nur für gegnerische Minions
        if (other.tag == "Player Minion" && player == false)
        {
            enemyTargeted = true;
            target = other.transform;

            /*navMeshAgent.isStopped = true;
            target = other.transform;
            minion = target.GetComponent<MinionController>();
            Attack();*/
        }
        else
        {
            enemyTargeted = false;
            navMeshAgent.destination = waypoint.position;
            navMeshAgent.isStopped = false;
        }
#endregion
    }

    private void Attack()
    {
        //Gibt es kein Ziel, wird auch nicht angegriffen.
        if (target == null)
        {
            return;
        }
        else
        {
            transform.LookAt(target);
            minion = target.GetComponent<MinionController>();
            if (Time.time > nextAttack)
            {
                nextAttack = Time.time + attackRate;
                //Greift den Gegner an.
                minion.hp -= attackDamage;
                //Debug.Log("Gegner wird angegriffen!");
            }
            navMeshAgent.isStopped = true;
        }

    }



}
