using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProjectileBehavior : MonoBehaviour
{

    public Rigidbody2D rb;
    public Rigidbody2D hook;
    public GameObject nextProjectile;

    public float releaseTime = .15f;
    public float maxDragDistance = 2.2f;

    private bool isPressed = false;


    private void Update()
    {
        if (isPressed)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Vector3.Distance(mousePos, hook.position) > maxDragDistance)
                rb.position = hook.position + (mousePos - hook.position).normalized * maxDragDistance;
            else
                rb.position = mousePos;  
        }
    }

    private void OnMouseDown()
    {
        isPressed = true;
        rb.isKinematic = true;
    }

    private void OnMouseUp()
    {
        isPressed = false;
        rb.isKinematic = false;

        StartCoroutine(Release());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.collider.GetComponent<MonsterHP>();
        if (enemy)
        {
            enemy.TakeHit(1);
            Destroy(gameObject);
        }


    }

    IEnumerator Release ()
    {
        yield return new WaitForSeconds(releaseTime);

        GetComponent<SpringJoint2D>().enabled = false;
        this.enabled = false;

        yield return new WaitForSeconds(.1f);

        if(nextProjectile == null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            //TODO: LoadScene(GameLost)
            nextProjectile.SetActive(true);
        }
    }



}
