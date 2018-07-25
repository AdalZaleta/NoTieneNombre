using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace TAAI
{
    public class Enemy_AI : MonoBehaviour
    {
        public GameObject player;
        public float maxDistance;
        Vector3 OG_pos;
        NavMeshAgent agent;
        bool canFollow = true;
        bool gotTarget;

        void OnTriggerEnter(Collider _col)
        {
            if (_col.gameObject.CompareTag("Player"))
            {
                if (canFollow)
                {
                    Debug.Log("PLAYER ENTERED");
                    gotTarget = true;
                }  
            }
        }

        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            OG_pos = transform.position;
        }

        void Update()
        {
            Debug.Log("Distance from OG: " + Vector3.Distance(transform.position, OG_pos));
            if (Vector3.Distance(transform.position, OG_pos) >= maxDistance)
            {
                Debug.Log("TOO FAR");
                agent.destination = OG_pos;
                FollowCD(2.0f);
                if (canFollow)
                {
                    gotTarget = false;
                }
            }
            else
            {
                if (gotTarget)
                {
                    Debug.Log("FOLLOWING PLAYER");
                    agent.destination = player.transform.position;
                }
            }
        }

        IEnumerator FollowCD(float cd_time)
        {
            canFollow = false;
            yield return new WaitForSeconds(cd_time);
            canFollow = true;
        }
    }
}