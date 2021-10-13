using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowColor : MonoBehaviour // 화살표 색 변하는것
{
    [SerializeField]
    GameObject arrow;
    [SerializeField]
    Renderer render;
    Color startColor = Color.yellow;
    Color endColor = Color.white;
    float speed = 1.0f;

    void Start()
    {
        arrow.SetActive(false);
    }

    private void OnEnable()
    {
        StartCoroutine(ChangeEngineColour());
    }

    private IEnumerator ChangeEngineColour()
    {
        float tick = 0f;
        
        while (render.material.color != endColor)
        {
            if (gameObject.activeSelf == true)
            {
                tick += Time.deltaTime * speed;
                render.material.color = Color.Lerp(startColor, endColor, tick);
                yield return null;
            }
            else
            {
                break;
            }
        }

        StartCoroutine(ChangeEngineColour1());
    }

    private IEnumerator ChangeEngineColour1()
    {
        float tick = 0f;
        while (render.material.color != startColor)
        {
            if (gameObject.activeSelf == true)
            {
                tick += Time.deltaTime * speed;
                render.material.color = Color.Lerp(endColor, startColor, tick);
                yield return null;
            }
            else
            {
                break;
            }
        }

        StartCoroutine(ChangeEngineColour());
    }
}
