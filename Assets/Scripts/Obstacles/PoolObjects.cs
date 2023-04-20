using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PoolObjects : MonoBehaviour
{
    [SerializeField] private ObstaclesCountPool[] _obstaclesCounts;     
    [SerializeField] private Transform _conector = null;


    private List<List<Obstacle>> _obstacles = new List<List<Obstacle>>();
  
    void Start()
    {
        foreach(ObstaclesCountPool obstaclesCountPool in _obstaclesCounts)
        {
            _obstacles.Add(Spawn(obstaclesCountPool));
        }
        GlobalEventSystem.RestartGame.AddListener(Restart);
        GlobalEventSystem.ExitToMenu.AddListener(Restart);
    }

    private void Restart()
    {
        foreach(List<Obstacle> obstacles in _obstacles)
        {
            foreach(Obstacle obstacle in obstacles.Where(q => q.gameObject.activeSelf == true))
            {
                obstacle.gameObject.SetActive(false);
            }
        }
    }


    private List<Obstacle> Spawn(ObstaclesCountPool obstaclesCountPool)
    {
        List<Obstacle> gameObjects = new List<Obstacle>();

        for (int i = 0; i < obstaclesCountPool.NumberSpawn; i++)
        {
            Obstacle obstacle = Instantiate(obstaclesCountPool.ObstaclesPrefab, _conector);
          
            gameObjects.Add(obstacle);
            obstacle.gameObject.SetActive(false);
        }
       
        return gameObjects;
    }

    public bool TryGetDamageObject(ObstacleEnum ID , out Obstacle damageObject)
    {
        List<Obstacle> listObstacle = new List<Obstacle>();
        
        try
        {
            
            listObstacle = _obstacles.First(q => q[0].ObstacleEnum == ID);
           
            try
            {
                damageObject = listObstacle.First(q => q.gameObject.activeSelf == false);
            }
            catch
            {
                Debug.LogError("Нехватает обектов для спавена");
                damageObject = null;
            }
        }
        catch
        {
            Debug.LogError("Нет данного типаа обектов в пуле");
            damageObject = null;
        }
        return damageObject!=null;
    }    
}
