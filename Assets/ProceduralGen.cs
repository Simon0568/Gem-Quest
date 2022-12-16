using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGen : MonoBehaviour
{

    [SerializeField] int height;
    [SerializeField] GameObject dirt,dirtBottom;
    // Start is called before the first frame update
    void Start()
    {
        Generation();
    }

   void Generation(){
    for(int x=0;x<width;x++)//Spawns a tile on the X axis
    {
         for(int y=0; y<height; y++)//Spawns a tile on the X axis
    {
        Instantiate(dirtBottom,new Vector2(x,y),Quaternion.identity);
    }
        Instantiate(dirt,new Vector2(x,height),Quaternion.identity);
    }
   }
}
