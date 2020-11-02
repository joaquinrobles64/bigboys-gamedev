using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Violence : MonoBehaviour
{
    public GameObject hitbox;
    public GameObject rightClickPrefab;

    bool m_Started;

    private void Start()
    {
        hitbox.SetActive(false);
        m_Started = true;
    }

    // Update is called once per frame
    void Update()
    {
        LeftClickAttack();

        if (Input.GetMouseButtonDown(1))
        {
            RightClickSpawnObject();
        }
        
    }

    void LeftClickAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // hitbox active so it can interact with other objects
            hitbox.SetActive(true);

            // detect collision with objects
            Collider[] hitEnemies = Physics.OverlapBox(hitbox.transform.position, new Vector3(1,2,3), hitbox.transform.rotation);

            // damage detected enemies
            foreach (Collider enemy in hitEnemies)
            {
                if (enemy.CompareTag("Enemy"))
                {
                    enemy.GetComponent<Enemy>().health -= 1;
                }
                
            }

            // make hitbox inactive
            hitbox.SetActive(false);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
        if (m_Started)
            //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
            Gizmos.DrawWireCube(hitbox.transform.position, hitbox.transform.localScale);
    }

    void RightClickSpawnObject()
    {
        
        Vector3 worldPos;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000f))
        {
            worldPos = hit.point;
            worldPos.y = 1;
            Instantiate(rightClickPrefab, worldPos, Quaternion.identity);
        }
        
    }
}
