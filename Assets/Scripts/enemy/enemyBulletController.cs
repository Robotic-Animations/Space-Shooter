using UnityEngine;

public class enemyBulletController : MonoBehaviour
{
    private Transform bullet;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Transform>();
    }

    void FixedUpdate(){
        bullet.position += Vector3.up * -speed;

        if(bullet.position.y <= -10)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player"){
            Destroy(other.gameObject);
            Destroy(gameObject);
            FindObjectOfType<gameManager>().GameOver();
        } else if(other.tag == "Base"){
            GameObject playerBase = other.gameObject;
            BaseHealth baseHealth = playerBase.GetComponent<BaseHealth>();
            baseHealth.health -= 1;
            Destroy(gameObject);
        }
    }
}
