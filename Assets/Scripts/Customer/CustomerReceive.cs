using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerReceive : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RECIVECREDITCARD")
        {
           StageManager.stageManager.Stage150();
           StageManager.stageManager.Stage490();
           StageManager.stageManager.Stage570();
        }
        if (other.gameObject.tag == "Money")
        {
           StageManager.stageManager.Stage298();
           Destroy(other.gameObject);

        }
    }
}
