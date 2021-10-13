using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour //바닥에 떨어지는 물체 원위치
{
    public Transform productposition;
    public Transform cardPosition;
    public Transform cardLeaderPosition;
    public Transform bacodPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CREDITCARD"))
        {
            other.transform.position = cardPosition.position;
        }
        if (other.CompareTag("TempProduct"))
        {
            other.transform.position = productposition.position;
        }
        if (other.CompareTag("RECIVECREDITCARD"))
        {
            other.transform.position = cardLeaderPosition.position;
        }
        if (other.CompareTag("Bacod"))
        {
            other.transform.position = bacodPosition.position;
        }
    }
}
