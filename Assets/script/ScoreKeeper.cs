using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] private int score = 0;

    public int getCurrentScore(){
        return score;
    }

    public void updateScoreByEnemyDamage(int updateValue){
        score += updateValue;
    }
    
    public void resetScore(){
        score = 0;
    }

    

}
