using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carkManager : MonoBehaviour
{
    public int speed = 30;
    void Update()
    {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
    }
}
