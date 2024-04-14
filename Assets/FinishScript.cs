using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScript : MonoBehaviour
{

    public GameManager manager;
   
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.GetComponent<PlayerController>()!=null)
        {
            Debug.Log("LEvelUp");
            manager.LevelUp();
        }
    }
}
