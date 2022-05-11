using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerWalking : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform player;
    public Camera PlayerCam;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = PlayerCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                navMeshAgent.SetDestination(hit.point);
                Debug.DrawRay(PlayerCam.transform.position, hit.point, Color.white, 2f);
            }
        }
        //Debug.Log(Input.mousePosition);
    }
}
