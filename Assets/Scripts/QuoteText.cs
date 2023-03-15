using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuoteText: MonoBehaviour
{
    //[SerializeField] private TextMeshProUGUI _Quotes;

    [SerializeField] private TextMeshProUGUI RandomQuote;

    [SerializeField] private string[] Quotes;

    

    private void Start()
    {
        RandomQuote.text = Quotes[Random.Range(0, Quotes.Length)];
    }

    public void GetQuote()
    {
        RandomQuote.text = Quotes[Random.Range(0, Quotes.Length)];
    }
}


