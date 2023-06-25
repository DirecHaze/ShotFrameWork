using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class RayCast : MonoBehaviour
{

   
  
    [SerializeField]
    private AudioSource _playerAuido;
    [SerializeField]
    private AudioClip _gunShot;
    [SerializeField]
    private AudioClip _missShot;

   
    // Update is called once per frame
    void Update()
    {
        hit();
        
    }
    // where we hit
    private void hit()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            StartCoroutine(GunShot());

           
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Shootable")))
            {
                Debug.Log("Hit" + hit.point);
                if (hit.collider.tag == "Bot")
                {
                    hit.transform.GetComponent<AI>().GotHit();
                    Debug.Log("Hit:" + hit.collider.name);
                }
                if(hit.collider.tag == "Barrel")
                {
                    hit.transform.GetComponent<ExplosionBarrels>().Explosion();
                    
                }
                if(hit.collider.tag == "Environment")
                {
                    _playerAuido.PlayOneShot(_missShot);
                }
                if(hit.collider.tag == "Wall")
                {
                    hit.transform.GetComponent<Barrier>().BarrierHit();
                }


            }

        }
       
    }
    IEnumerator GunShot()
    {
        _playerAuido.PlayOneShot(_gunShot);
        yield return new WaitForSeconds(1f);
        _playerAuido.Stop();
    }
   
}
