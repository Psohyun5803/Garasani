[System.Serializable]
public struct InventorySlot
{
    public int itemIndex;
    public int count;

    public InventorySlot(int itemIndex, int count)
    {
        this.itemIndex = itemIndex;
        this.count = count;
    }
}