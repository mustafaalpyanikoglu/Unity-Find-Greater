using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePaneli;

    private void OnEnable()
    {
        Time.timeScale = 0f;
    }
    private void OnDisable()
    {
        Time.timeScale = 1f;
    }

    public void YenidenOyna()
    {
        pausePaneli.SetActive(false);
    }

    public void MenuyeDon()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OyundanCik()
    {
        Application.Quit();
    }
}
