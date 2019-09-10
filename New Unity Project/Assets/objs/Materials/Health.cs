using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image health;
    private float timeLeft = 90f; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        health.fillAmount -= 1.0f / timeLeft * Time.deltaTime; ; 


    }
}
