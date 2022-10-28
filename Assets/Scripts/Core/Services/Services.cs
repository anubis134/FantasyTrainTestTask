using UnityEngine;
using Utils;

public class Services : MonoBehaviour
{
    internal static Services Singletone; 
    internal WayGenerator WayGenerator;
    internal Economy Economy;


    private void Awake()
    {
        Singletone = this;
        InitServices();
    }

    private void InitServices()
    {
        WayGenerator = this.FindOrException<WayGenerator>();
        Economy = this.FindOrException<Economy>();
    }
}
