using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    public GameObject MenuSet;
    public GameObject player;
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
            MenuSet.SetActive(true);
    }
    public void OptionConfirm() // 옵션 종료하는 창
    {
        MenuSet.SetActive(false);
        Time.timeScale = 1;
    }
    public void GameSave()
    {
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        PlayerPrefs.Save();
        //player.x, player.y
        MenuSet.SetActive(false);
    }

    public void GameLoad()
    {
        float x = PlayerPrefs.GetFloat("playerX");
        float y = PlayerPrefs.GetFloat("PlayerY");

        player.transform.position = new Vector3(x, y, 0);

    }   
    
    public void ExitMap() // 스테이즈 나가기
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start");
    }
    
}
