public interface IDamageable
{
    int EnemyHealth { get; set; }
    void TakeDamage(int damageAmount);
}
