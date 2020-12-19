using UnityEngine;

public class enemyController : MonoBehaviour
{
    public GameObject shot;
    private Transform enemyHolder;
    [SerializeField] private float fireRate;
    [SerializeField] private float speed;
    
    void Start()
    {
        switch(FindObjectOfType<SettingsMenu>().difficultyDropdown.value){
            case 0:
                fireRate = 0.002f;
                speed = 0.5f;
                break;
            case 1:
                fireRate = .004f;
                speed = 1f;
                break;
            case 2:
                fireRate = .02f;
                speed = 1.2f;
                break;
            case 3:
                fireRate = .05f;
                speed = 1.2f;
                break;
            default:
                fireRate = .004f;
                speed = 1f;
                break;
        }

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
                FindObjectOfType<AudioManager>().Play("enemyMove");
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
