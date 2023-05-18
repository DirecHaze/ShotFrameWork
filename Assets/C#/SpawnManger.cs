using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManger : Singleton<SpawnManger>
{
    [SerializeField]
    private GameObject _startPoint;
    [SerializeField]
    private GameObject _botPrefab;
    [SerializeField]
    private int _bot;
    private bool _startMove = true;
    public override void function()
    {
        base.function();
        
        
        StartCoroutine(Spwan());
    }
    IEnumerator Spwan()
    {
        while (_startMove == true)
        {
            for (int i = 0; i < _bot; i++)
            {
                yield return new WaitForSeconds(3);
                Debug.Log("Its work");

                Instantiate(_botPrefab, _startPoint.transform.position, Quaternion.identity);
            }
        }
        
        
    }

}
