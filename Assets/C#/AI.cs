using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AI : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _wayPoint;
    [SerializeField]
    private NavMeshAgent _agent;
    [SerializeField]
    private int _point;
    private bool _startMove;


    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
       
        if (_agent.remainingDistance <= 0.5 && _point <= 1)
        {
            _point++;
            var waypoint = _wayPoint[_point];
            _agent.SetDestination(waypoint.transform.position);
        }

    }
}
