using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public float chainDelay = 0.5f;
    private Target _target;

    private GameManager _manager;
    // Start is called before the first frame update
    void Start()
    {
        _target = GetComponent<Target>();
        _manager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_target.health <= 0f) StartCoroutine(Explode());
    }

    public IEnumerator Explode()
    {
        Debug.Log("exploding " + gameObject.name);
        yield return new WaitForSeconds(chainDelay);
        if(_manager.isPlaying) _manager.OnLose();

        Destroy(gameObject);
    }
    
    
}