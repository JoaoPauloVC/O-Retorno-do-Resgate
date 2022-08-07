using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterMovement : MonoBehaviour
{
    public float speed; //define monster speed
    public Vector2 direction; // movemente direction of the monster
    
    Rigidbody2D rb; // reference to the monster
    float startSpeed; //TODO: After some time, monster inscrease speed
    
    
    void Start()
    {
        direction = new Vector2(-1, 0);
        direction.Normalize();
        startSpeed = speed;
        rb = GetComponent<Rigidbody2D>();

        ResetSpeed();
    }

    void FixedUpdate()
    {
        float yVelocity = rb.velocity.y;

        rb.velocity = direction * speed; //TODO: Define how Speed increases over Time.
    
        if (yVelocity != 0)
        {
            direction = new Vector2(0, -20);
            direction.Normalize();
            rb.velocity = direction * speed;
            direction = new Vector2(-1, 0);
        }
    }


    public void ResetSpeed() // If Player goes to Escape Phase (Fase de Fuga), Reset Wargal StartSpeed
    {
        speed = startSpeed;
    }
}
