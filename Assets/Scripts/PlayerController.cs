using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {

    NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
       Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
       RaycastHit hit;
        if (Input.GetButtonDown("Fire1"))
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                navMeshAgent.destination = hit.point;
                Debug.Log("I'm moving.");
            }
            else
            {
                Debug.Log("Nothing found");
            }
        }
    }
}
