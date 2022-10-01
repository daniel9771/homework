using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Piggy : MonoBehaviour
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
            StartCoroutine(NextLevel());
            SpriteRenderer1.color = Color.red;
        }
    }
    IEnumerator NextLevel()
    {

        yield return new WaitForSeconds(1f);
        if (scene.name == "birdy 1")
        {
            SceneManager.LoadScene("birdy 2");
        }
        if (scene.name == "birdy 2")
        {
            SceneManager.LoadScene("birdy 3");
        }
        if (scene.name == "birdy 3")
        {
            SceneManager.LoadScene("birdy 5");
        }


    }
}
