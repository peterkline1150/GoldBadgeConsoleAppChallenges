namespace ChallengeSixRepo
{
    public interface IElectricCar : ICar
    {
        double BatteryCapacity { get; set; }
        double MPBCountry { get; set; }
        double MPBHighway { get; set; }
    }
}