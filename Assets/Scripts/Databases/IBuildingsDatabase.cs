using Models;

namespace Databases
{
    public interface IBuildingsDatabase
    {
        BuildingVo[] Buildings { get; }
    }
}