using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLight : MonoBehaviour
{
   
    public float maxAngle = 90f;
    public float minAngle = 30f;
    public float rimit = 5f;
    Light lt;
    // Start is called before the first frame update
    void Start()
    {
        lt = GetComponent<Light>();
        lt.type = LightType.Spot;
        lt.spotAngle = maxAngle;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (lt.spotAngle > minAngle || lt.spotAngle < maxAngle)
        {
            float val = Input.GetAxis("Mouse ScrollWheel");
            if (val < 0.0f && lt.spotAngle > minAngle)
            {
                lt.spotAngle -= rimit;
            }
            if (val > 0.0f && lt.spotAngle < maxAngle)
            {
                lt.spotAngle += rimit;
            }
        }
    }
}
