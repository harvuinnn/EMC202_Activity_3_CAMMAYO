using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public GameObject attackWavePrefab;
    public float attackDistance = 10f;
    public float attackDuration = 8f;

    public Transform attackSpawnPoint;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(DelayedAttack());
        }
    }

    IEnumerator DelayedAttack()
    {
        yield return new WaitForSeconds(0.4f);

        Quaternion rotation = Quaternion.Euler(90f, 180f, 0f);
        GameObject attackWave = Instantiate(attackWavePrefab, attackSpawnPoint.position, rotation);

        StartCoroutine(MoveForward(attackWave));
    }

    IEnumerator MoveForward(GameObject wave)
    {
        float startTime = Time.time;
        Vector3 startPosition = wave.transform.position;
        Vector3 targetPosition = startPosition + transform.forward * attackDistance;

        while (Time.time < startTime + attackDuration)
        {
            if (wave != null)
            {
                wave.transform.position = Vector3.Lerp(startPosition, targetPosition, (Time.time - startTime) / attackDuration);
            }
            yield return null;
        }

        if (wave != null)
        {
            Destroy(wave);
        }
    }

}
