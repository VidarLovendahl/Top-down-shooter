using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    int counter;
    public TMP_Text counterText;
    int scoring = 1;

    [SerializeField] Enemy enemy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        counter = 0;

        counterText = GameObject.FindWithTag("Score Counter").GetComponent<TMP_Text>();
        counterText.text = counter.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnEnemyDeath()
    {
            counter += scoring;
            counterText.text = counter.ToString();
    }
}
