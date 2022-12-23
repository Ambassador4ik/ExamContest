using System.Linq;

internal class Battlefield
{
    private readonly Ship[,] ships;

    public Battlefield(Ship[,] ships)
    {
        this.ships = ships;
    }

    public string this[int i, int j]
    {
        get
        {
            var ship = ships[i, j];
            if (ship != null)
            {
                if (!ship.Hit.ToList().TrueForAll(h => h))
                {
                    if (ship.IsHorizontal)
                    {
                        if (ship.Hit[j - ship.BowColumn])
                        {
                            return $"this {ships[i, j].ShipType} has already shot";
                        }

                        ship.Hit[j - ship.BowColumn] = true;
                    }
                    else
                    {
                        if (ship.Hit[i - ship.BowRow])
                        {
                            return $"this {ships[i, j].ShipType} has already shot";
                        }

                        ship.Hit[i - ship.BowRow] = true;
                    }

                    return ship.Hit.ToList().TrueForAll(h => h)
                        ? $"{ships[i, j].ShipType} sunk"
                        : $"{ships[i, j].ShipType} shot";
                }

                return $"this {ships[i, j].ShipType} has already sunk";
            }

            return "miss";
        }
    }
}