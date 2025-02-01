
public class HP
{
    private int HealthPoints;

    public void SetHP(int amount)
    {
        this.HealthPoints = amount;
    }

    public int GetHP()
    {
        return this.HealthPoints;
    }

    public void DecreaseHP(int amount)
    {
        this.HealthPoints -= amount;
    }

    public void IncreaseHP(int amount)
    {
        this.HealthPoints += amount;
    }
}