using System.Collections;
using UnityEngine;
using UnityEngine.AI;
public class AI : Singleton<AI>
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
    private GameObject _explosionPrefab;
    [SerializeField]
    private Collider _aiCollider;


    [SerializeField]
    private Animator _anim;
    [SerializeField]
    private AudioSource _aiAudio;
    [SerializeField]
    private AudioClip _deathSound;
    [SerializeField]
    private AudioClip _successSound;
    [SerializeField]
    private AudioClip _explosionSound;


    [SerializeField]
    private NavMeshAgent _agent;
    [SerializeField]
    private AiState _currentState;

    [SerializeField]
    private int _placeToHide;
    [SerializeField]
    private float _time;
    [SerializeField]
    private int _rngNumber;
   
   

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
        var RNG = Random.Range(1, 3);
        _rngNumber = RNG;
       
    }

    // Update is called once per frame
    void Update()
    {





        switch (_currentState)
        {
            case AiState.Running:
                movement();
                break;
            case AiState.Hiding:
                stopmove();
                break;
            case AiState.Death:
                Death();
                break;
           



        }



    }
    //move
    private void movement()
    {
       
        if (_agent.remainingDistance <= 0.5 && _goToEnd == false)
        {

            var waypoint = _wayPoint[_placeToHide];
            _agent.SetDestination(waypoint.transform.position);
            StartCoroutine(DoWeHavePath());
        }
        if (_agent.remainingDistance <= 0.5 && _goToEnd == true)
        {

            _end = GameObject.Find("end");
            _agent.SetDestination(_end.transform.position);
  
           
        }
        //checking path
        if (_agent.hasPath == true)
        {
            _currentState = AiState.Running;
        }
        
        if (_noPath == true)
        {
            if (_agent.hasPath == false)
            {
                _currentState = AiState.Hiding;
               
            }
        }
        //See if the bot will run or walk
        if(_rngNumber <= 1 )
        {
            _anim.SetInteger("WalkOrRun", 1);
        }
        if (_rngNumber >= 2)
        {
            _anim.SetInteger("WalkOrRun", 2);
            _agent.speed = 5f;
        }

    }
    //hide 
    private void stopmove()
    {
        if (_time <= 0)
        {
            _anim.SetBool("Hide", false);
            _agent.isStopped = false;
            _goToEnd = true;
            _currentState = AiState.Running;

        }
        else
        {
            _anim.SetBool("Hide", true);
            _agent.isStopped = true;
            _time -= Time.deltaTime * 1;

        }
      

    }
    //death
    public void GotHit()
    {
        _currentState = AiState.Death;
        _aiAudio.PlayOneShot(_deathSound);
        GameManager.Program.BotDestory();
        GameManager.Program.PlusScore();
    }
    

    private void Death()
    {
        
        Destroy(GetComponent<Collider>());
        _agent.isStopped = true;
        _anim.SetBool("Death", true);
        Destroy(this.gameObject, 2);
        
      
    }
  
    //When Bot win
    private void WiN()
    {
        Debug.Log("Bot Win");
        _aiAudio.PlayOneShot(_successSound);
        Invoke("AfterWin", 0.5f);
        GameManager.Program.BotThatWon();
        _aiCollider.enabled = false;
       
    }

    private void AfterWin()
    {
        
      
        _aiAudio.PlayOneShot(_explosionSound);
        Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
        _anim.SetBool("Death", true);
        GameManager.Program.BotDestory();
        Destroy(this.gameObject, 2);
        return;
      
    }
   
    //A path check
    IEnumerator DoWeHavePath()
    {

        yield return new WaitForSeconds(1);
        _noPath = true;


    }
    //See if Bot hit the end
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "End")
        {
            WiN();
            return;
        }
        if(other.tag == "Barrel")
        {
            GotHit();
            

            return;
        }
      
    }

}

