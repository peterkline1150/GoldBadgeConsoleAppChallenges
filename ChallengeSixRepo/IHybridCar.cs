namespace ChallengeSixRepo
{
    public interface IHybridCar : ICar
    {
        double BatteryCapacity { get; set; }
        double MPGCountry { get; set; }
        double MPGHighway { get; set; }
        int TankCapacity { get; set; }
    }
}