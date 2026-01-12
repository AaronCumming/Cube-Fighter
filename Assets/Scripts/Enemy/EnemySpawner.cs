using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy_object;
    public Transform player;

    public int inside_len;
    public int outside_len;


    public float duration = 3f;
    public float ramp_up_speed = .01f;
    public float minimum_threshold = .3f;

    public float first_slow_threshold = 1f;
    public float second_slow_threshold = .5f;
    public float third_slow_threshold = .4f;
    public int first_slow_decreaser = 2;
    public int second_slow_decreaser = 4;
    public int third_slow_decreaser = 8;


    private bool pause = false;

    private int spawnPointX;
    private int spawnPointZ;


    void Update()
    {
        if (pause) return;


        int quadrant = Random.Range(1,5);

        if (quadrant == 1) {
            spawnPointX = Random.Range(-outside_len, outside_len);
            spawnPointZ = Random.Range(inside_len, outside_len);
        }
        else if (quadrant == 2) {
            spawnPointX = Random.Range(inside_len, outside_len);
            spawnPointZ = Random.Range(-inside_len, inside_len);
        }
        else if (quadrant == 3) {
            spawnPointX = Random.Range(-inside_len, -outside_len);
            spawnPointZ = Random.Range(-inside_len, inside_len);     
        }
        else if (quadrant == 4) {
            spawnPointX = Random.Range(-outside_len, outside_len);
            spawnPointZ = Random.Range(-inside_len, -outside_len);
        }

        Vector3 spawnPosition = new Vector3(player.position.x + spawnPointX, 1, player.position.z + spawnPointZ);
        Instantiate(enemy_object, spawnPosition, Quaternion.identity);
        
        StartCoroutine(PauseUpdate());
          
    } 
    private IEnumerator PauseUpdate()
    {
        pause = true;

        if (duration >= minimum_threshold) 
        { 
            if (duration <= third_slow_threshold)
            {
                duration = duration - (ramp_up_speed/third_slow_decreaser);
            }
            else if (duration <= second_slow_threshold)
            {
                duration = duration - (ramp_up_speed/second_slow_decreaser);
            }
            else if (duration <= first_slow_threshold)
            {
                duration = duration - (ramp_up_speed/first_slow_decreaser);
            }
            else
            {
                duration = duration - ramp_up_speed;
            }
        }
        else if (duration < minimum_threshold) 
        {
            duration = minimum_threshold;
        }


        yield return new WaitForSeconds(duration);
        pause = false;
    }

}