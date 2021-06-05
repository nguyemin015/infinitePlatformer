using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public PlayerControl thePlayer;
    private Vector3 playerStartPoint;

    public GameObject thePlatform;

    private ScoreManager theScoreManager;

    public DeathScreen DeathMenu;

    // Start is called before the first frame update
    void Start()
    {
        platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;

        theScoreManager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame()
    {
        theScoreManager.scoreIncrease = false;
        thePlayer.gameObject.SetActive(false);

        DeathMenu.gameObject.SetActive(true);
        //StartCoroutine("RestartGameCo");
    }

    public void Reset()
    {
        DeathMenu.gameObject.SetActive(false);
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("platform");
        foreach (GameObject target in gameObjects) //deletes cloned platforms after restart is initiated
        {
            GameObject.Destroy(target);
        }
        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);

        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncrease = true;
    }

    /*public IEnumerator RestartGameCo()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("platform");
        foreach (GameObject target in gameObjects) //deletes cloned platforms after restart is initiated
        {
            GameObject.Destroy(target);
        }
        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);
    }*/
}
