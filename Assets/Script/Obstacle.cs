using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public bool duckCrate;

    void Start()
    {

        ParticleManager.main.SmokeBurst(transform.position);

    }

    public void OnBreak(float otherVelocity)
    {

        ParticleManager.main.BreakCrate(transform.position);
        SoundManager.main.SmashCrate();

        ShockWave.Blast(transform.position.Vec2(), 2f, otherVelocity / 4f);

        ScoreManager.main.BreakBox(transform.position);

        if (duckCrate)
        {
            SoundManager.PlaySound(0);
            DuckManager.main.AddDuck(transform.position.Vec2());
            ObstacleGenerator.main.ScaleCooldown(DuckManager.main.duckList.Count);
            SaveManager.main.Save();
        }
    }
}
