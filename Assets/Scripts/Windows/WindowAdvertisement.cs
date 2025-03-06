using System;

public class WindowAdvertisement : Window
{
    public event Action AdvertisementFinished;

    public void Play()
    {
        AdvertisementFinished?.Invoke();
    }
}
