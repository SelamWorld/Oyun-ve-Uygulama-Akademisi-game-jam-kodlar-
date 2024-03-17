using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class hedefC : MonoBehaviour
{
    public int can= 3;

    private Collider2D En;
    private SpriteRenderer sp;

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            print("l basýldý");
            print(Input.GetKeyUp(KeyCode.L));
        }
    }
    void Start() {
        En = GetComponent<Collider2D>();
    }
    void OnTriggerStay2D(Collider2D col) {
    if (col.gameObject.tag == "Zombie" )
    {
            if (Input.GetKeyUp(KeyCode.L)) {
                can -= 1;
                print(can);
                if (can == 0)
                {
                    Destroy(col.gameObject);
                }
            
            }
                
    }

}
}