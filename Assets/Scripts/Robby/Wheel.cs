using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(200 * Time.deltaTime, 0 , 0));
    }
}
