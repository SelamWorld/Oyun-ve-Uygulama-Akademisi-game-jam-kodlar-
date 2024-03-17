using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    [SerializeField] private Transform DEDE;
    private void Update()
    {
        transform.position = new Vector3(DEDE.position.x, DEDE.position.y, transform.position.z);

    }
}
