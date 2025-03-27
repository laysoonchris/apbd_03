namespace apbd_03.Properties;

public interface IHazardNotifier
{
    void DangerousState(string message, string serialNumber);
}