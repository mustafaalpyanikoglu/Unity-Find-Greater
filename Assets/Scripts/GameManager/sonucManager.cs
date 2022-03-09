using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sonucManager : MonoBehaviour
{
    [SerializeField]
    private Text dogruAdetTxt, yanlisAdetTxt, puanTxt;

    int puanSure = 10;
    bool sureBittimi = true;

    int toplamPuan, yazdirilacakPuan, artisPuan;

    private void Awake()
    {
        sureBittimi = true;
    }

    public void SonuclariGoster(int dogruAdet,int yanlisAdet,int puan)
    {
        dogruAdetTxt.text = dogruAdet.ToString();
        yanlisAdetTxt.text = yanlisAdet.ToString();
        puanTxt.text = puan.ToString();

        toplamPuan = puan;
        artisPuan = toplamPuan / 10;

        StartCoroutine(PuaniYazdirRoutine());
    }

    IEnumerator PuaniYazdirRoutine()
    {
        while(sureBittimi)
        {
            yield return new WaitForSeconds(0.1f);

            yazdirilacakPuan += artisPuan;

            if(yazdirilacakPuan>=toplamPuan)
            {
                yazdirilacakPuan = toplamPuan;
            }

            puanTxt.text = yazdirilacakPuan.ToString();

            if(puanSure<=0)
            {
                sureBittimi = false;
            }

            puanSure--;
        }
    }

    public void AnaMenuyeDon()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void TekrarOyna()
    {
        SceneManager.LoadScene("GameLevel");
    }
}
