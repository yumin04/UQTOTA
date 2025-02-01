
public class Cooldown
{
    public int cooldown;

    public void SetCooldown(int amount)
    {
        this.cooldown = amount;
    }

    public int GetCooldown()
    {
        return this.cooldown;
    }

    public void DecreaseCooldown(int amount)
    {
        this.cooldown -= amount;
    }

    public void IncreaseHP(int amount)
    {
        this.cooldown += amount;
    }

    public bool MoveIsReady()
    {
        return this.cooldown <= 0;
    }
}