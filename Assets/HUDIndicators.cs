using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDIndicators : MonoBehaviour {


    [SerializeField]
    float PH;
    int Stocks;
    int Souls;
    public Image HealthBar;
    public Text StockN;
    public Text SoulN;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        PH = GameObject.FindGameObjectWithTag("Player").GetComponent<PStats>().Playerhealth;
        Stocks = GameObject.FindGameObjectWithTag("Player").GetComponent<PStats>().PStocks;
        Souls = GameObject.FindGameObjectWithTag("Player").GetComponent<PStats>().PSouls;
        StatsUpdate();
	}

    private void StatsUpdate()
    {
        HealthBar.fillAmount = PH * 0.01f;

        StockN.text = "x" + Stocks.ToString();

        SoulN.text = "x" + Souls.ToString();
    }
    
}
