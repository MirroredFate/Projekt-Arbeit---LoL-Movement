using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{

    public float attackDistance = 1.5f;
    public float attackRate = .5f;


    private NavMeshAgent navMeshAgent;

    //Für mögliche Animationen (walking = bool im animator)
    private bool walking;

    private bool enemyClicked;
    private Transform targetedEnemy;
    private float nextAttack;

    // Use this for initialization
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetButtonDown("Fire1"))
        {
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider.CompareTag("Enemy")) //Wurde ein objekt mit dem Tag "Enemy" angeklickt?
                {
                    targetedEnemy = hit.transform; //Setzt den Transform Component von hit auf targeted Enemy
                    enemyClicked = true;
                }
                else
                {
                    walking = true;
                    enemyClicked = false;
                    navMeshAgent.destination = hit.point; //Setzt das Ziel vom NavMeshAgent auf den Punkt, wo die Maus draufgeklickt hat.  
                    navMeshAgent.isStopped = false;
                    Debug.Log("I'm moving.");

                }
            }

        }
        //Ruft MoveAndAttack() auf
        if (enemyClicked)
        {
            MoveAndAttack();
        }

        //Für Animationen
        /*if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            if (!navMeshAgent.hasPath)
                walking = false;
        }
        else
        {
            walking = true;
        }*/
    }

    //Bewegt Objekt zum Gegner und greift an wenn in Reichweite
    private void MoveAndAttack()
    {
        if (targetedEnemy == null)
            return;
        navMeshAgent.destination = targetedEnemy.position; //Setzt Ziel des NavMeshAgents auf die position des angewählten Gegners
        if (navMeshAgent.remainingDistance >= attackDistance) //Setzt walking auf true, wenn die Distanz, die der NavMeshAgent noch gehen muss größer ist als die Angriffsreichweite des Objekts.
        {
            navMeshAgent.isStopped = false;
            walking = true;
        }

        if (navMeshAgent.remainingDistance <= attackDistance) // Greift an, wenn die Distanz, die der NavMeshAgent noch gehen muss kleiner ist, als die Angrifftsreichweite des Objekts.
        {
            transform.LookAt(targetedEnemy); //Schaut zum Gegner
            //Vector3 dirToShoot = targetedEnemy.transform.position - transform.position; //Setzt die Richtung wohin geschossen wird.
            if (Time.time > nextAttack)
            {
                nextAttack = Time.time + attackRate;
                Debug.Log("Gegner wird angegriffen!"); //Greift den Gegner an.
            }
            navMeshAgent.isStopped = true;
            walking = false;
        }
    }
}
