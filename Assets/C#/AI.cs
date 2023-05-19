using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AI : MonoBehaviour
{
    private enum AiState
    {
        Running,
        Hiding,

        Death,

    }
    [SerializeField]
    private GameObject[] _wayPoint;
    [SerializeField]
    private GameObject _end;

    [SerializeField]
    private NavMeshAgent _agent;
    [SerializeField]
    private AiState _currentState;

    [SerializeField]
    private int _placeToHide;
    [SerializeField]
    private float _time;

    [SerializeField]
    private bool _goToEnd = false;
    [SerializeField]
    private bool _noPath;




    // Start is called before the first frame update
    private void Start()
    {

        var Place = Random.Range(0, 16);
        _placeToHide = Place;
        var Time = Random.Range(0, 4);
        _time = Time;
        _wayPoint = GameObject.FindGameObjectsWithTag("Point");

    }

    // Update is called once per frame
    void Update()
    {







        movement();




    }
    private void movement()
    {
        if (_agent.remainingDistance <= 0.5 && _goToEnd == false)
        {

            var waypoint = _wayPoint[_placeToHide];
            _agent.SetDestination(waypoint.transform.position);
            StartCoroutine(DoWeHavePath());
        }
        if (_agent.hasPath == true)
        {
             _currentState = AiState.Running;
        }
        if (_noPath == true)
        {
            if (_agent.hasPath == false)
            {
                _currentState = AiState.Hiding;
                stopmove();
            }
        }
     
    }
    private void stopmove()
    {
        if (_time <= 0)
        {
            _agent.isStopped = false;
            _goToEnd = true;
          
        }
        else
        {
            _agent.isStopped = true;
            _time -= Time.deltaTime * 1;
           
        }
        if (_goToEnd == true)
        {
            _currentState = AiState.Running;
            _end = GameObject.Find("end");
            _agent.SetDestination(_end.transform.position);
            
        }
 
    }
    IEnumerator DoWeHavePath()
    {
       
        yield return new WaitForSeconds(1);
        _noPath = true;


    }

}
    
