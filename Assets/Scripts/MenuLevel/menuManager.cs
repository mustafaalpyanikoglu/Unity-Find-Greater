using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{
    [SerializeField]
    private Transform kafa;
    [SerializeField]
    private Transform startBtn;

    void Start()
    {
        kafa.transform.GetComponent<RectTransform>().DOLocalMoveX(0f, 1.7f).SetEase(Ease.OutBack);
        startBtn.transform.GetComponent<RectTransform>().DOLocalMoveY(-270f, 1.7f).SetEase(Ease.OutBack);
    }

    public void OyunaBasla()
    {
        SceneManager.LoadScene("GameLevel");
    }
}
