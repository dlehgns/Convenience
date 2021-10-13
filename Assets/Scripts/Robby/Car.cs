using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [Header("차 본체 관련")]
    public float carSpeed; //차량 속도
    public float rotationSpeed; // 차량 회전 속도
    
    [Header("이동 목표 관련")]
    int wavepointIndex = 0; // 이동 순서
    Transform target; // 이동할 목표물
    public Transform[] points; // 이동할 위치

    void Start()
    {
        target = points[0]; //맨 처음 이동
    }

    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, points[wavepointIndex].rotation, Time.deltaTime * rotationSpeed); //차 회전

        Vector3 dir = target.position - transform.position; //이동 방향 구하기
        transform.Translate(dir.normalized * carSpeed * Time.deltaTime, Space.World); //차 이동


        if (Vector3.Distance(transform.position, target.position) <= 0.4f) // 목표로 오면 다음 목표로 이동 
        {
            GetNextwaypoint();
        }
    }

    void GetNextwaypoint()
    {
        if (wavepointIndex >= points.Length - 1) // 마지막 목표로 가면 처음 목표로 가도록
        {
            wavepointIndex = 0; //처음 목표로 재설정
            target = points[wavepointIndex];
            return; // 바로 빠져나오기
        }
        wavepointIndex++; // 목표 변경
        target = points[wavepointIndex]; //타겟에 목표 지정
    }
}
