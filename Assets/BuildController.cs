using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class BuildController : MonoBehaviour
{

    public Tile grassTile;
    public Tilemap groundTileMap;
    public float castDistance = 1.0f;
    public Transform rayCastPoint;
    public LayerMask mask;

    float blockDestroyTime=0.2f;

    Vector3 direction;

    RaycastHit2D hit;

    bool destroyingBlock=false;
    bool placingBlock=false;
  
   void FixedUpdate()
   {
        if(Input.GetKey(KeyCode.F)||Input.GetKey(KeyCode.C)){
            RayCastDirection();
        }    
   }
   void RayCastDirection(){
    if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0){
        direction.x=Input.GetAxis("Horizontal");
        direction.y=Input.GetAxis("Vertical");
    }
    hit=Physics2D.Raycast(rayCastPoint.position,direction,castDistance,mask.value);
    Vector2 endPos=rayCastPoint.position + direction;

    if(Input.GetKey(KeyCode.F)){
        if(hit.collider&& !destroyingBlock){
            destroyingBlock=true;
            StartCoroutine(DestroyingBlocks(hit.collider.gameObject.GetComponent<Tilemap>(),endPos));
        }
    }

    if(Input.GetKey(KeyCode.C)){
        if(!hit.collider && !placingBlock){
            placingBlock=true;
            StartCoroutine(PlacingBlocks(groundTileMap,endPos));
        }
    }
   }

    IEnumerator DestroyingBlocks(Tilemap map,Vector2 pos){
        yield return new WaitForSeconds(blockDestroyTime);
        pos.y=Mathf.Floor(pos.y);
        pos.x=Mathf.Floor(pos.x);
        map.SetTile(new Vector3Int((int)pos.x,(int)pos.y,0),null);
        destroyingBlock=false;
    }

    IEnumerator PlacingBlocks(Tilemap map,Vector2 pos){
        yield return new WaitForSeconds(0f);
        pos.y=Mathf.Floor(pos.y);
        pos.x=Mathf.Floor(pos.x);
        map.SetTile(new Vector3Int((int)pos.x,(int)pos.y,0),grassTile);
        placingBlock=false;
    }

}
