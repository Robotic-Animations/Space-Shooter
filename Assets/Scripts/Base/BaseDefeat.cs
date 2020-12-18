using UnityEngine;

public class BaseDefeat : MonoBehaviour
{
    private Transform playerBase;

    // Start is called before the first frame update
    void Start()
    {
        playerBase = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(playerBase.childCount == 0)
            FindObjectOfType<gameManager>().GameOver();
    }
}
