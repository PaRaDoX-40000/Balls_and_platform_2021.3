using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class SpawnPosition
{
    [SerializeField] private Transform _position;
    [Range(0, 3)]
    [SerializeField] private float _randomOffsetX;
    [Range(0, 3)]
    [SerializeField] private float _randomOffsetY;
    [SerializeField] private ObstacleParameters[] _obstacleParameters;
    public UnityAction SpawnIsFinished;


    public IEnumerator StartSpavn(PoolObjects poolObjects)
    {
        foreach (ObstacleParameters obstacleParameters in _obstacleParameters)
        {
            yield return new WaitForSeconds(obstacleParameters.GetTime());
            if (poolObjects.TryGetDamageObject(obstacleParameters.SpavnObect, out Obstacle DamageObject))
            {
                float randomOffsetX = Random.Range(-_randomOffsetX, _randomOffsetX);
                float randomOffsetY = Random.Range(-_randomOffsetY, _randomOffsetY);
                Vector3 randomPosition = _position.position + new Vector3(randomOffsetX, randomOffsetY, 0);
                DamageObject.transform.position = randomPosition;
                DamageObject.transform.eulerAngles = obstacleParameters.Rotation;
                DamageObject.gameObject.SetActive(true);
                DamageObject.SetSpeed(obstacleParameters.Speed);
            }
        }
        SpawnIsFinished?.Invoke();
    }
}
