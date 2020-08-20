using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LateActivate : MonoBehaviour
{
    public float spawnDelay;

    public GameObject target;

    private bool done;

    private void Start()
    {
        if (target.activeInHierarchy)
        {
            target.SetActive(false);
        }
    }

    public void startTimer()
    { 
        if(done == false)
        {
            done = true;
            StartCoroutine(lateStart());
        }
    }

    IEnumerator lateStart()
    {
        yield return new WaitForSeconds(spawnDelay);
        SoundManager.playSound("powerup");
        target.SetActive(true);
    }
}
