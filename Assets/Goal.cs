using TMPro;
using UnityEngine;

public class Goal : MonoBehaviour
{
    int score = 0;
    [SerializeField] private TMP_Text scoreTxt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            score = score + (1 * 100);
            scoreTxt.text = score.ToString() + " EN";
            Destroy(other.gameObject);        
        }    
    }
}
