using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    public GameObject a;
    public GameObject b;    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ObjectRotateTowards(a, b);
    }

    void ObjectRotateTowards(GameObject a, GameObject b)
    {
        Vector3 relativePos = b.transform.position - a.transform.position;
        float angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;
        a.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
