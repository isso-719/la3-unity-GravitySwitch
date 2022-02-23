using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCreator : MonoBehaviour
{
    float interval = 0;

    public GameObject player;
    public PlayerController playerController;

    public GameObject[] walls;
    public GameObject item;
    float wallPositionX = 5.0f;
    float wallPosition1Y = 8;
    float wallPosition2Y = -8;
    int createCount;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = -10; i <= 17; i++)
        {
            if (i % 2 == 0)
            {
                Instantiate(walls[0], new Vector3(i, wallPosition1Y, 0), transform.rotation);
                Instantiate(walls[0], new Vector3(i, wallPosition2Y, 0), transform.rotation);
            } else
            {
                Instantiate(walls[1], new Vector3(i, wallPosition1Y, 0), transform.rotation);
                Instantiate(walls[1], new Vector3(i, wallPosition2Y, 0), transform.rotation);
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.playStatus == "Playing")
        {
            interval += Time.deltaTime;
            if (interval > 0.15)
            {
                createCount++;
                if (createCount % 3 == 0)
                {
                    wallPosition1Y = Random.Range(7, 10);
                    wallPosition2Y = -Random.Range(7, 10);
                }

                if (createCount % 28 == 0)
                {
                    Instantiate(item, new Vector3(wallPositionX + 12, wallPosition1Y - 6.5f, 0), transform.rotation);
                }
                else if (createCount % 14 == 0)
                {
                    Instantiate(item, new Vector3(wallPositionX + 12, wallPosition2Y + 6.5f, 0), transform.rotation);
                }

                wallPositionX++;
                Instantiate(walls[createCount % 2], new Vector3(wallPositionX + 12, wallPosition1Y, 0), transform.rotation);
                Instantiate(walls[createCount % 2], new Vector3(wallPositionX + 12, wallPosition2Y, 0), transform.rotation);

                interval = 0;
            }
        }
    }
}
