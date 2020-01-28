using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int wavePointIndex;

    private Enemy enemy;

    private void Start()
    {
        target = Waypoints.points[wavePointIndex];
        enemy = GetComponent<Enemy>();
    }
    
    private void Update()
    {
        Vector3 dir = target.position - transform.position;//directia in care mergem
        transform.Translate(enemy.speed * Time.deltaTime * dir.normalized, Space.World); // directia cu viteza

        if (Vector3.Distance(transform.position, target.position) <= enemy.minimumDistanceCollision)
        {
            GetNextWaypoint();
        }

        enemy.speed = enemy.startSpeed;
    }

    private void GetNextWaypoint()
    {
        if (wavePointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        wavePointIndex++;
        target = Waypoints.points[wavePointIndex];
    }

    void EndPath()
    {
        --PlayerStats.Lives;
        Destroy(gameObject);
    }
}
