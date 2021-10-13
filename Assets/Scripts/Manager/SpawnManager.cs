using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject products;
    public GameObject[] moneys;
    public GameObject trafficCard1;
    public GameObject creditCard2;
    public GameObject trafficCard2;

    public Transform productsPosition;
    public Transform CardPosition;
    public Transform cardLeader;

    public void productsSpawn()
    {
        Instantiate(products, productsPosition.transform.position, products.transform.rotation);
    }
    
    public void CreditCard()
    {
        Instantiate(creditCard2, cardLeader.position, creditCard2.transform.rotation);
    }
    public void ResetTrafficCard()
    {
        Instantiate(trafficCard1, CardPosition.position, trafficCard1.transform.rotation);
    }
    public void TrafficCard()
    {
        Instantiate(trafficCard2, cardLeader.position, trafficCard2.transform.rotation);
    }

}
