using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    //publicにすることでHierarchyからでもクラスが見えるようにする
    public GameObject gameClearText;
    public GameObject gameOverText;
    public GameObject ball;
    public GameObject retryButton;


    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ブロックの取得
        GameObject[] blocks=GameObject.FindGameObjectsWithTag("Block");
        if (blocks.Length==0){
            gameClearText.SetActive(true);
            retryButton.SetActive(true);

        }

        if (ball.GetComponent<Ball>().isDead==true)
        {
            gameOverText.SetActive(true);
            retryButton.SetActive(true);

        }

        
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}