using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowAdvertisement : Window
{
    public event Action AdvertisementFinished;

    public void Play()
    {
        AdvertisementFinished?.Invoke();
    }
}
