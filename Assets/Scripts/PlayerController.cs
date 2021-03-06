﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{

    public float attackDistance = 1.5f;
    public float attackRate = .5f;
    public int attackDamage = 2;


    NavMeshAgent navMeshAgent;

    bool enemyClicked;
    Transform targetedEnemy;
    MinionController minion;
    float nextAttack;

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
        if (Input.GetButton("Fire1"))
        {
            if (Physics.Raycast(ray, out hit, 100))
            {
                //Angreifen
                //Wurde ein objekt mit dem Tag "Enemy" angeklickt?
                if (hit.collider.CompareTag("Enemy Minion")) 
                {
                    //Setzt den Transform Component von hit auf targeted Enemy
                    targetedEnemy = hit.transform; 
                    enemyClicked = true;
                }
                else
                //Bewegen
                {
                    enemyClicked = false;
                    //Setzt das Ziel vom NavMeshAgent auf den Punkt, wo die Maus draufgeklickt hat.
                    navMeshAgent.destination = hit.point;   
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

        
    }

    //Bewegt Objekt zum Gegner und greift an wenn in Reichweite
    private void MoveAndAttack()
    {
        if (targetedEnemy == null)
            return;
        //Setzt Ziel des NavMeshAgents auf die position des angewählten Gegners
        navMeshAgent.destination = targetedEnemy.position;
        //Setzt walking auf true, wenn die Distanz, die der NavMeshAgent noch gehen muss größer ist als die Angriffsreichweite des Objekts.
        if (navMeshAgent.remainingDistance >= attackDistance) 
        {
            navMeshAgent.isStopped = false;
        }

        // Greift an, wenn die Distanz, die der NavMeshAgent noch gehen muss kleiner ist, als die Angrifftsreichweite des Objekts.
        if (navMeshAgent.remainingDistance <= attackDistance) 
        {
            transform.LookAt(targetedEnemy); //Schaut zum Gegner
            //Vector3 dirToShoot = targetedEnemy.transform.position - transform.position; //Setzt die Richtung wohin geschossen wird.
            minion = targetedEnemy.GetComponent<MinionController>();
            if (Time.time > nextAttack)
            {
                nextAttack = Time.time + attackRate;
                //Greift den Gegner an.
                minion.hp -= attackDamage;
                Debug.Log("Gegner wird angegriffen!");
            }
            navMeshAgent.isStopped = true;
        }
    }
}
