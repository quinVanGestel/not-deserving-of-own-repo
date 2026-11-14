using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

public class Airplane
{
    private Seat[] seats = new Seat[100];
    private Passenger[] passengers = new Passenger[100];


    public void EntryPoint()
    {
        QTools.FillArray(seats);
        QTools.FillArray(passengers);
        Console.WriteLine(passengers.Length);
        Console.WriteLine(passengers[53].seated);
    }


}

public class Seat
{
    [AllowNull]
    public Passenger seatedPassenger;
    public bool occupied;
}

public class Passenger
{
    [Range(0, 100)]
    public int desiredSeat = -1;
    public bool seated;
}
