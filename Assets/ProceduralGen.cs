using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGen : MonoBehaviour
{

    [SerializeField] int height;
    [SerializeField] int width;
    [SerializeField] int minStoneSpawn,maxStoneSpawn;
    [SerializeField] GameObject dirt,dirtBottom,stone;
    // Start is called before the first frame update
    void Start()
    {
        Generation();
    }

   void Generation(){
    for(int x=0;x<width;x++)//Spawns a tile on the X axis
    {
    int minHeight= height - 1;
    int maxHeight = height + 2;
    height=Random.Range(minHeight,maxHeight);
    int minStoneSpawn= height-5;
    int maxStoneSpawn= height-6; 
    int totalStoneSpawn=Random.Range(minStoneSpawn,maxStoneSpawn);

         for(int y=0; y<height; y++)//Spawns a tile on the X axis
    {
        if(y<totalStoneSpawn){
            spawnObj(y,x,stone);
        }else{
            spawnObj(y,x,dirtBottom);
        }
        if(totalStoneSpawn==height){
            spawnObj(height,x,stone);
        }else{
            spawnObj(height,x,dirt);
        }
    }
    }
   }

   void spawnObj(int height,int width,GameObject obj){
    obj=Instantiate(obj,new Vector2(width,height),Quaternion.identity);
    obj.transform.parent=this.transform;
   }
}
