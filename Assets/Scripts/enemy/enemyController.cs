using UnityEngine;

public class enemyController : MonoBehaviour
{
    public GameObject shot;
    private Transform enemyHolder;
    public float fireRate = 0.004f;
    public float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MoveEnemy", 0.1f, 0.3f);
        enemyHolder = GetComponent<Transform>();
    }

    void MoveEnemy()
    {
        enemyHolder.position += Vector3.right * speed;

        foreach(Transform enemy in enemyHolder){
            if (enemy.position.x > 10.5 || enemy.position.x < -10.5){
                speed = -speed;
                enemyHolder.position += Vector3.down * 0.5f;
                return;
            }

            if(Random.value < fireRate){
                Instantiate(shot, enemy.position, enemy.rotation);
            }

            if(enemy.position.y <= -4){
                Time.timeScale = 0;
                FindObjectOfType<gameManager>().GameOver();
            }
        }

        if(enemyHolder.childCount == 1){
            CancelInvoke();
            InvokeRepeating("MoveEnemy", 0.1f, 0.25f);
        }

        if(enemyHolder.childCount == 0){
            FindObjectOfType<gameManager>().Win();
        }
    }
}
