using System;

public static class EventManager
{
    public static event Action<Enemy> EnemyHit;
    public static void OnEnemyHit(Enemy e) => EnemyHit?.Invoke(e);

    public static event Action<Enemy> EnemyDie;
    public static void OnEnemyDie(Enemy e) => EnemyDie?.Invoke(e);
}


