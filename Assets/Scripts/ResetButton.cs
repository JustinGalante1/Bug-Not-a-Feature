using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour
{
    bool activated;

    private void Update()
    {
        if(activated == false)
        {
            activated = this.transform.parent.GetChild(this.transform.GetSiblingIndex() + 1).gameObject.activeSelf;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player") && activated)
        {
            collision.collider.transform.position = new Vector3(2, 2, -9);
        }
    }
}
