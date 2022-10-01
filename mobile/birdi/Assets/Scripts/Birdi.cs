using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Birdi : MonoBehaviour
{
    Vector3 offset;
    Vector3 bird_origin;
    [SerializeField] float max_distance;
    [SerializeField] float force_factor;
    Rigidbody2D rigidbody2D;
    private bool canShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    private void OnMouseDown()
    {
        if (canShoot)
        {
        bird_origin = transform.position;
        Vector3 mousedown_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousedown_position.z = transform.position.z;

        offset = mousedown_position - transform.position;
        }
    }

    private void OnMouseDrag()
    {
        if (canShoot)
        {
            float distance;
            float mouseDistance;

            Vector3 new_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            new_position.z = transform.position.z;

            //calculate distance between current position and origin
            distance = Vector3.Distance(new_position, bird_origin);

            Vector3 new_bird_position;
            new_bird_position = new_position - offset;

            if (distance < max_distance)
            {
                transform.position = new_bird_position;
            }
            
            

        }

    }

    private void OnMouseUp()
    {
        if (canShoot)
        {
            rigidbody2D.gravityScale = 1;
            Vector3 dragVector = transform.position - bird_origin;

            rigidbody2D.AddForce(new Vector2(-dragVector.x * force_factor, -dragVector.y * force_factor));

            StartCoroutine(Restart());
        }
    }

    IEnumerator Restart()
    {
        canShoot = false;
        yield return new WaitForSeconds(10f); 
        canShoot = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
