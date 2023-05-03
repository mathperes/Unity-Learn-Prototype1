using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowInside : MonoBehaviour
{
    
    public GameObject insidePlayer;
    
    Vector3 offset2 = new Vector3(0, 2.5f, 2);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = insidePlayer.transform.position + offset2;
        transform.rotation = insidePlayer.transform.rotation;
    }
}
