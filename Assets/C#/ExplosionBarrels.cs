using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBarrels : MonoBehaviour
{
  
    [SerializeField]
    private SphereCollider _barrel;
    [SerializeField]
    private GameObject _explosionPrefab;
    [SerializeField]
    private AudioSource _barrelAudio;
    [SerializeField]
    private AudioClip _explosionSound;
    
    
   
    

    private void Start()
    {

        _barrel = transform.GetComponent<SphereCollider>();
    }



    public void Explosion()
    {
        Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
        _barrel.radius = 5;
        _barrelAudio.PlayOneShot(_explosionSound);
        
        Destroy(this.gameObject, 0.5f);
        
        Debug.Log("Hit");
               
    }
    
    
}
