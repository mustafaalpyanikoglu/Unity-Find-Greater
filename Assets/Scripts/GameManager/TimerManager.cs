using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    [SerializeField]
    private Text SureText;

    int kalanSure;

    bool sureSayisinmi=true;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        kalanSure = 90;

        sureSayisinmi = true;
    }

    public void SureyiBaslat()
    {
        StartCoroutine(SureTimerRoutine());
    }

    IEnumerator SureTimerRoutine()
    {
        yield return new WaitForSeconds(1f);
        gameManager.GeriSayim();
        while (sureSayisinmi)
        {
            yield return new WaitForSeconds(1f);

            if(kalanSure<10)
            {
                SureText.text = "0"+kalanSure.ToString();
            }
            else
            {
                SureText.text = kalanSure.ToString();
            }

            if(kalanSure<=0)
            {
                sureSayisinmi = false;
                SureText.text = "";

                gameManager.OyunuBitir();
            }
            kalanSure--;
        }
    }
}
