using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
 using UnityEngine;
public class Coins : MonoBehaviour 
{ 
    [SerializeField] GameObject Obj_prefab;  
    public float minCount=100, maxCount=200, currentCount=0;  
    float lastAddedObj=0;  
     void AddObj(){  
        Vector3 Objposition= new Vector3(Random.Range(-217.8f,-96.817f), -1f,Random.Range(351.3f,464.7f));  
        GameObject objName = Instantiate(Obj_prefab);  
        objName.transform.position=Objposition;  
        objName.transform.parent=transform;  
        currentCount++; 
}  
     void Start(){if(currentCount<=100){ 
          AddObj();}} 
     void Update(){if(currentCount<=100 ){ 
          AddObj();} } 
 
}