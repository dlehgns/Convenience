using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildAI : MonoBehaviour //아이 행동에 관한것
{
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void PickUp()
    {
        anim.SetTrigger("isPickUp");
    }
}
