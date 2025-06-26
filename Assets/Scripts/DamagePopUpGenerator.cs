using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopUpGenerator : MonoBehaviour
{
    public static DamagePopUpGenerator current;

    public GameObject prefab;

    private void Awake(){
        current=this;
    }

    // Update is called once per frame
    private  void Update()
    {
       if (Input.GetKeyDown(KeyCode.Mouse0)){
            CreatePopUp(Vector3.one,Random.Range(0,1000).ToString(),Color.yellow);
        }
    }
    public void CreatePopUp(Vector3 position,string text,Color color){
        var popup=Instantiate(prefab,position, Quaternion.identity);
        var temp=popup.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        temp.text=text;
        temp.faceColor=color;
        //Destrot Timer
        Destroy(popup, 1f);
    }
}
