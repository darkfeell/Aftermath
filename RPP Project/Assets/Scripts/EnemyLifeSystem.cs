using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeSystem : MonoBehaviour
{
    public int EnemyLife;
    public GameObject gameObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if(EnemyLife <= 0)
        {
            Destroy(gameObject);
        }
        
    }

      private void OnCollisionEnter2D(Collision2D collider)
    {

        if (collider.gameObject.tag == "pbullet")
        {
            EnemyLife--;
            gameObj.GetComponent<Renderer>().material.color = new Color(0, 2,2);

        }

    }


}
