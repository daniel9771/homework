using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartGame : MonoBehaviour
{
    private Scene scene;
    private void Start()
    {
        scene = SceneManager.GetActiveScene();
    }
    public SpriteRenderer SpriteRenderer1;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SpriteRenderer1.color = Color.green;
            StartCoroutine(NextLevel());
        }
    }
    IEnumerator NextLevel()
    {

        yield return new WaitForSeconds(1f);
        if (scene.name == "birdy 4")
        {
            SceneManager.LoadScene("birdy 1");
        }
        if (scene.name == "birdy 5")
        {
            SceneManager.LoadScene("birdy 1");
        }
        

    }
}
