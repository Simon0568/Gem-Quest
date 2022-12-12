using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGen : MonoBehaviour
{

    [SerializeField] int width;
    [SerializeField] GameObject dirt;
    // Start is called before the first frame update
    void Start()
    {
        Generation();
    }

   void Generation(){
    for(int x=0;x<width;x++)//Spawns a tile on the X axis
    {
        Instantiate(dirt,new Vector2(x,0),Quaternion.identity);
    }
   }
}
