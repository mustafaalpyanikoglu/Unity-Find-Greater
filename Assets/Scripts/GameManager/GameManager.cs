using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject puanSurePaneli,sonucPaneli;
    
    [SerializeField]
    private GameObject puaniKapYazisi,buyukOlanSayiSecYazisi;
    
    [SerializeField]
    private GameObject ustDikdortgen, altDikdortgen;

    [SerializeField]
    private Text ustText, altText,puanText;

    [SerializeField]
    private GameObject pausePaneli;

    TimerManager timerManager;
    DairelerManager dairelerManager;
    TrueFalseManager trueFalseManager;
    sonucManager sonucManager;


    int oyunSayac, kacinciOyun;

    int ustDeger, altDeger;

    int buyukDeger;

    int butonDegeri;

    int toplamPuan, artisPuani;

    int dogruAdet, yanlisAdet;

    private AudioSource audioSource;

    [SerializeField]
    private AudioClip baslangicSesi, dogruSesi, yanlisSesi, bitisSesi,geriSayimSesi;

    private void Awake()
    {
        timerManager = Object.FindObjectOfType<TimerManager>();

        dairelerManager = Object.FindObjectOfType<DairelerManager>();

        trueFalseManager = Object.FindObjectOfType<TrueFalseManager>();

        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        kacinciOyun = 0;
        oyunSayac = 0;

        ustText.text = "";
        altText.text = "";

        puanText.text = "0";
        toplamPuan = 0;

        SahneEkraniniGuncelle();
    }

    void SahneEkraniniGuncelle()
    {
        puanSurePaneli.GetComponent<CanvasGroup>().DOFade(1, 1f);
        puaniKapYazisi.GetComponent<CanvasGroup>().DOFade(1, 1f);
        
        ustDikdortgen.GetComponent<RectTransform>().DOLocalMoveX(0, 1.7f).SetEase(Ease.OutBack);
        altDikdortgen.GetComponent<RectTransform>().DOLocalMoveX(0, 1.7f).SetEase(Ease.OutBack);
        //OyunaBasla();

    }

    public void OyunaBasla()
    {
        audioSource.PlayOneShot(baslangicSesi);

        puaniKapYazisi.GetComponent<CanvasGroup>().DOFade(0, 1f);

        buyukOlanSayiSecYazisi.GetComponent<CanvasGroup>().DOFade(1, 1f);


        KacinciOyun();

        timerManager.SureyiBaslat();
    }

    void KacinciOyun()
    {
        if(oyunSayac<5)
        {
            kacinciOyun = 1;
            artisPuani = 25;
        }
        else if(oyunSayac>=5 && oyunSayac<10)
        {
            kacinciOyun = 2;
            artisPuani = 50;
        }
        else if(oyunSayac>=10 && oyunSayac<15)
        {
            kacinciOyun = 3;
            artisPuani = 100;
        }
        else if (oyunSayac >= 15 && oyunSayac < 20)
        {
            kacinciOyun = 4;
            artisPuani = 125;
        }
        else if (oyunSayac >= 20 && oyunSayac < 25)
        {
            kacinciOyun = 5;
            artisPuani = 150;
        }
        else
        {
            kacinciOyun = Random.Range(1, 6);
        }

        switch (kacinciOyun)
        {
            case 1:
                BirinciFonksiyon();
                break;
            case 2:
                IkinciFonksiyon();
                break;
            case 3:
                UcuncuFonksiyon();
                break;
            case 4:
                DorduncuFonksiyon();
                break;
            case 5:
                BesinciFonksiyon();
                break;
        }
    }

    void BirinciFonksiyon()
    {
        int rastgeleDeger = Random.Range(1, 50);
        
        if(rastgeleDeger<=25)
        {
            ustDeger = Random.Range(2, 50);
            altDeger = ustDeger + Random.Range(1, 10);
        }
        else
        {
            ustDeger = Random.Range(2, 50);
            altDeger = Mathf.Abs(ustDeger - Random.Range(1, 10));
        }

        if(ustDeger>altDeger)
        {
            buyukDeger = ustDeger;
        }
        else if(ustDeger < altDeger)
        {
            buyukDeger = altDeger;
        }
        else
        {
            BirinciFonksiyon();
            return;
        }

        ustText.text = ustDeger.ToString();
        altText.text = altDeger.ToString();

    } //karşılaştırma işlemi yaptırır

    void IkinciFonksiyon() //toplama işlemi yaptırır
    {
        int birinciSayi = Random.Range(1, 10);
        int ikinciSAyi = Random.Range(1, 20);

        int ucuncuSayi = Random.Range(1, 10);
        int dorduncuSayi = Random.Range(1, 20);

        ustDeger = birinciSayi + ikinciSAyi;
        altDeger = ucuncuSayi + dorduncuSayi;

        if(ustDeger>altDeger)
        {
            buyukDeger = ustDeger;
        }
        else if(ustDeger <altDeger)
        {
            buyukDeger = altDeger;
        }
        
        if(ustDeger==altDeger)
        {
            IkinciFonksiyon();
            return;
        }

        ustText.text = birinciSayi + " + " + ikinciSAyi;
        altText.text = ucuncuSayi + " + " + dorduncuSayi;
    }

    void UcuncuFonksiyon() //çıkartma işlemi yaptırır
    {
        int birinciSayi = Random.Range(11, 30);
        int ikinciSAyi = Random.Range(1, 11);

        int ucuncuSayi = Random.Range(11, 40);
        int dorduncuSayi = Random.Range(1, 11);

        ustDeger = birinciSayi - ikinciSAyi;
        altDeger = ucuncuSayi - dorduncuSayi;

        if (ustDeger > altDeger)
        {
            buyukDeger = ustDeger;
        }
        else if (ustDeger < altDeger)
        {
            buyukDeger = altDeger;
        }

        if (ustDeger == altDeger)
        {
            UcuncuFonksiyon();
            return;
        }

        ustText.text = birinciSayi + " - " + ikinciSAyi;
        altText.text = ucuncuSayi + " - " + dorduncuSayi;
    }

    void DorduncuFonksiyon() //çarpma işlemi yaptırır
    {
        int birinciSayi = Random.Range(1, 10);
        int ikinciSAyi = Random.Range(1, 10);

        int ucuncuSayi = Random.Range(1, 10);
        int dorduncuSayi = Random.Range(1, 10);

        ustDeger = birinciSayi * ikinciSAyi;
        altDeger = ucuncuSayi * dorduncuSayi;

        if (ustDeger > altDeger)
        {
            buyukDeger = ustDeger;
        }
        else if (ustDeger < altDeger)
        {
            buyukDeger = altDeger;
        }

        if (ustDeger == altDeger)
        {
            DorduncuFonksiyon();
            return;
        }

        ustText.text = birinciSayi + " x " + ikinciSAyi;
        altText.text = ucuncuSayi + " x " + dorduncuSayi;
    }

    void BesinciFonksiyon() //bölme işlemi yaptırır
    {
        int bolen1 = Random.Range(2, 10);
        ustDeger = Random.Range(2, 10);

        int bolunen1 = bolen1 * ustDeger;

        int bolen2 = Random.Range(2, 10);
        altDeger = Random.Range(2, 10);

        int bolunen2 = bolen2 * altDeger;

        if (ustDeger > altDeger)
        {
            buyukDeger = ustDeger;
        }
        else if (ustDeger < altDeger)
        {
            buyukDeger = altDeger;
        }

        if (ustDeger == altDeger)
        {
            BesinciFonksiyon();
            return;
        }

        ustText.text = bolunen1 + " / " + bolen1;
        altText.text = bolunen2 + " / " + bolen2;

    }
    public void ButonDegeriniBelirle(string butonAdi)
    {
        if(butonAdi =="ustButon")
        {
            butonDegeri = ustDeger;
        }
        else if(butonAdi=="altButon")
        {
            butonDegeri = altDeger;
        }

        if(butonDegeri==buyukDeger)
        {
            trueFalseManager.TrueFalseScaleAc(true);

            dairelerManager.DairelerinScaleAc(oyunSayac%5); //kalan 1 se 1. daire aç
            oyunSayac++;

            toplamPuan += artisPuani;
            puanText.text = toplamPuan.ToString();

            dogruAdet++;

            audioSource.PlayOneShot(dogruSesi);

            KacinciOyun();
        }
        else
        {
            trueFalseManager.TrueFalseScaleAc(false);
            HatayaGoreSayaciAzalt();

            yanlisAdet++;

            audioSource.PlayOneShot(yanlisSesi);

            KacinciOyun();
        }
    }

    void HatayaGoreSayaciAzalt()
    {
        oyunSayac -= (oyunSayac % 5 + 5);

        if(oyunSayac<0)
        {
            oyunSayac = 0;
        }

        dairelerManager.DairelerinScaleKapat();
    }
    
    public void PausePaneliniAc()
    {
        pausePaneli.SetActive(true);
    }

    public void OyunuBitir()
    {
        audioSource.PlayOneShot(bitisSesi);

        sonucPaneli.SetActive(true);

        sonucManager = Object.FindObjectOfType<sonucManager>(); //burda olmasının sebebi başta setactive false olduğu için görmüyor

        sonucManager.SonuclariGoster(dogruAdet, yanlisAdet, toplamPuan);
    }

    public void GeriSayim()
    {
        audioSource.PlayOneShot(geriSayimSesi);
    }

}
