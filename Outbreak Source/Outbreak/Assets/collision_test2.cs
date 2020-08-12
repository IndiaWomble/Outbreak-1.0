using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision_test2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
            Debug.LogError("Col "+other.name);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
