using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour //VR이 아닌 일반에서 VR 처럼 물체를 이동시키기 위해 존재
{

    private float distance = 1.1f;
    private Rigidbody rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x,Input.mousePosition.y, distance);
        this.transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
        this.rigid.velocity = Vector3.zero;
    }

}
