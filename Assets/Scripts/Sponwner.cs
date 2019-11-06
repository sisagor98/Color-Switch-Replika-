using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sponwner : MonoBehaviour
{
    public GameObject cyclePrefabs;
    public GameObject colorSwitch;

    public int _positionY = 6;

    Vector3 pos;

    public void Spawn()
    {
        _positionY += 6;
         pos = new Vector3(0, _positionY);
        Instantiate(cyclePrefabs,pos,transform.rotation);
        
    }

    public void SpawnColorSwitch()
    {
        Instantiate(colorSwitch, new Vector3(
            pos.x,pos.y + 3,0
            ), transform.rotation);
    }
}
