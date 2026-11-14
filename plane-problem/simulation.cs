
using System.ComponentModel.DataAnnotations;

BeautifulAirplaneMathProblemSimulation reference = new();
reference.EntryPoint();

public class BeautifulAirplaneMathProblemSimulation
{
    private Seat[] seats = new Seat[100];
    private Passenger[] passengers = new Passenger[100];

    private void FillArray()
    {
        foreach (Seat seat in seats)
        {
            seat = new();
        }
    }

    public void EntryPoint()
    {
        Console.WriteLine(passengers.Length);
        Console.WriteLine(passengers[53].seated);
        // foreach(Passenger passenger in passengers)
        // {

        // }
    }


}

public class Seat
{
    public Passenger seatedPassenger;
    public bool occupied;
}

public class Passenger
{
    [RangeAttribute(0, 100)]
    public int desiredSeat = -1;
    public bool seated;
}
