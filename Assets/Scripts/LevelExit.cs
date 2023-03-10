using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    float levelLoadDelay = 0.5f;
    GameObject player;
    bool isAlive;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        player = GameObject.Find("Player");
        isAlive = player.GetComponent<PlayerMovement>().isAlive;
        //Debug.Log(player.GetComponent<PlayerMovement>().isAlive);
        //ensure that the player is alive before allowing them to move to the next level
        if(isAlive && other.tag == "Player")
        {
            StartCoroutine(LoadNextLevel());
        }
         // built in delay between levels
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex == SceneManager.sceneCount)
        {
            nextSceneIndex = 0;
        }
        //goed back to level one for now.
        FindObjectOfType<ScenePersist>().DeleteScenePersist();
        SceneManager.LoadScene(nextSceneIndex);
    }
}
