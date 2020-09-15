using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{


    public Image fill;
    
    public float minimum = 0;
    public float current;
    public float damage;
    public float Maximum = 100f;
    public float currentPercent;


    // Start is called before the first frame update
    void Start()
    {
        current = 100f;
        Health();
        
    }

    public void Health()
    {
        current -= damage;
        currentPercent = current / Maximum;
    }

    public void Update()
    {
        fill.fillAmount = currentPercent;
    }




}
