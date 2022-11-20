using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBreak : MonoBehaviour
{

  void OnTriggerEnter2D(Collider2D other)
  {
        if(other.tag=="Player"){
            Destroy();
        }   
  }

  void Destroy(){
    Destroy(gameObject);
  }
}
