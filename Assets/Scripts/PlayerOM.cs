using System;

public static class PlayerOM
{
    public static event Action<int> OnCoinCollected;
    
    public static void NotifyCoinCollected(int totalCoins)
    {
        OnCoinCollected?.Invoke(totalCoins);
    }
}