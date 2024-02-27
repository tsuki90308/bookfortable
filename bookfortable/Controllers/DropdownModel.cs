using bookfortable.Models;

internal class DropdownModel
{
    private FinalContext db;

    public DropdownModel(FinalContext db)
    {
        this.db = db;
    }

    internal List<EvenType> GetEventTypeOptions()
    {
        //在這裡實現獲取EvenType選項的邏輯
        return db.EvenTypes.ToList();
    }
}