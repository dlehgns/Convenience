using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardOnOff : MonoBehaviour
{
    void OnDisable()
    {
        transform.transform.position = new Vector3(-0.018f, 0.098f, -0.028f);
    }
}
