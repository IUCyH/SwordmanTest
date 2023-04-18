using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FindMonsters : MonoBehaviour
{
    public List<GameObject> monsters;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Monster"))
        {
            monsters.Add(other.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Monster"))
        {
            monsters.Remove(other.gameObject);
            Debug.Log("HI");
        }
    }
}
