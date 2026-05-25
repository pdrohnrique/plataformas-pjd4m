using System;

public static class PlayerOm
{
    public static event Action<int> OnCoinCollected;
    
    public static void NotifyCoinCollected(int totalCoins)
    {
        OnCoinCollected?.Invoke(totalCoins);
    }
}