using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField]
    private int _health = 3;
    [SerializeField]
    private float _time = 5;
    [SerializeField]
    private GameObject[] _barrier;
    [SerializeField]
    private Collider _barrierCollider;




    // Update is called once per frame
    public void BarrierHit()
    {
        _health -= 1;

    }
    private void Update()
    {

        if (_health == 0)
        {
            BarrierDown();
            _barrier[0].SetActive(false);
            _barrier[1].SetActive(false);
            _barrierCollider.enabled = false;
            
        }
        if(_health == 3)
        {
            _barrier[0].SetActive(true);
            _barrier[1].SetActive(true);
            _barrierCollider.enabled = true;
        }
    }
   
   
  
    private void BarrierDown()
    {
        _time -= 1 * Time.deltaTime;
       

        if (_time <= 0)
        {
            
            _health = 3;
        
            _time = 5;
        }
    }
}
