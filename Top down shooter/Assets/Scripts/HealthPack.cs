using System;
using UnityEditor.Callbacks;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float healthAmount = 1f;
    [SerializeField] private Player player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
       if(player == null)
        {
            player = FindAnyObjectByType<Player>();
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseHealth(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            
        }
    }
}
