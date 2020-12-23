using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;
    private Transform bullet;

    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Transform>();
    }

    void FixedUpdate(){
        bullet.position += Vector3.up * speed;

        if(bullet.position.y >= 10)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy"){
            Destroy(other.gameObject);
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().Play("enemyExplosion");
            PlayerScore.playerScore += 5 * PlayerScore.scoreMultiplier;
        } else if(other.tag == "Base")
            Destroy(gameObject);
    }
}
