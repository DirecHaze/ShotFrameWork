using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    [SerializeField]
    private GameObject _startPoint;
    [SerializeField]
    private GameObject _botPrefab;
    [SerializeField]
    private int _bot;
   
    private bool _startSpawn = true;
    [SerializeField]
    private bool _startCount = false;
    public override void function()
    {
        base.function();

    }
    private void FixedUpdate()

    {
        StartCoroutine(Spwan());
    
       
        return;
    }
    IEnumerator Spwan()
    {
        while (_startSpawn == true)
        {
            
            for (int i = 0; i < _bot; i++)
            {

               
               
                yield return new WaitForSeconds(2);
                _startCount = true;
                if (_startCount == true)
                {
                    GameManager.Program.SpawnBotCount();
                }
                Debug.Log("Its work");
               
                Instantiate(_botPrefab, _startPoint.transform.position, Quaternion.identity);
                StopAllCoroutines();
                
            }
        }
        
        
    }
   

    public void StopSpawn()
    {
        _startSpawn = false;
     
    }

  

}
