using Daedalus_Orbis.Map;

public class UXEvents
{
    public static UXEvents current;

    public event Action? OnZoomIn;
    public void ZoomIn()
    {
        OnZoomIn?.Invoke();
    }

    public event Action? OnZoomOut;
    public void ZoomOut()
    {
        OnZoomOut?.Invoke();
    }

    public event Action<ToolType>? OnNewTool;
    public void NewTool(ToolType tt)
    {
        OnNewTool?.Invoke(tt);
    }

    public event Action<TerrainType>? OnNewTerrain;
    public void NewTerrain(TerrainType tt)
    {
        OnNewTerrain?.Invoke(tt);
    }

    public event Action<TileComponentData>? OnNewTileSelected;
    public void NewTileSelected(TileComponentData data)
    {
        OnNewTileSelected?.Invoke(data);
    }

    public event Action<TileComponentData>? OnNewTileSelectedClient;
    public void NewTileSelectedClient(TileComponentData data)
    {
        OnNewTileSelectedClient?.Invoke(data);
    }

}

