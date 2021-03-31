namespace ChallengeSixRepo
{
    public interface IGasCar : ICar
    {
        double MPGCountry { get; set; }
        double MPGHighway { get; set; }
        int TankCapacity { get; set; }
    }
}