namespace GildedRose.Console.Contracts
{
    public interface IChangeCoefStrategy
    {
        bool? IsIncrease { get; }

        int CalculateCoef(int sellIn);
    }
}
