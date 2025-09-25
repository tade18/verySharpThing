using OopExamples.Interfaces;
using OopExamples.Interfaces.Exceptions;

namespace OopExamples.Implementations;

public class GPU : IGPU
{
    private IMonitor _monitor;
    public string Name { get; set; }
    public GPUConnector[] Connectors { get; }
    public IComputer? Computer { get; set; }
    public GPUConnector[] AvailableConnectors { get; }
    public IMonitor[] ConnectedMonitors { get; }
    public bool IsUsed { get; set; }

    public void Connect(IComputer computer)
    {
        if (IsUsed)
        {
            throw new Exception("Already connected");
        }
        
    }

    public void Disconnect()
    {
        if (!IsUsed)
        {
            throw new Exception("Not connected");
        }
    }

    public void ConnectMonitor(IMonitor monitor)
    {
        if (ConnectedMonitors.Contains(monitor))
        {
            throw new Exception("Already connected");
        }
        else if (AvailableConnectors.Contains != null)
        {
            throw new InvalidConnectorException();
        }
        else if (ConnectedMonitors.Contains(monitor))
        {
            _monitor = monitor;
        }
    }

    public void DisconnectMonitor(IMonitor monitor)
    {
        if (ConnectedMonitors.Contains(monitor))
        {
            _monitor = null;
        }
    }
}