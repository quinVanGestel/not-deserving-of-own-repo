using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

public class Airplane
{
    private Passenger[] passengers = new Passenger[100];
    private Seat[] seats = new Seat[100];
    private Random random = new();
    int amountOfTrialsToRun = 1000000;
    int currentIteration = 0;

    int successes;
    int failures;

    public void EntryPoint()
    {
        Stopwatch watch = Stopwatch.StartNew();
        while (currentIteration < amountOfTrialsToRun)
        {
            bool lastPassengerIsInLastSeat = RunSimulation();
            if (lastPassengerIsInLastSeat)
            {
                successes++;
            }
            else
            {
                failures++;
            }
        }

        float endResult = (float)successes / ((float)successes + (float)failures);
        Console.WriteLine("Final result after " + currentIteration + " trials: " + endResult);
        Console.WriteLine("Code completed after " + watch.ElapsedMilliseconds + " ms");
    }

    private bool RunSimulation()
    {
        currentIteration++;

        QTools.FillArray(seats);
        QTools.FillArray(passengers);

        for (int i = 0; i < passengers.Length; i++)
        {
            Seat seat;
            seat = seats[i];
            if (i == 0)
            {
                seat = getRandomUnoccupiedSeat();
            }

            if (seat.occupied)
            {
                seat = getRandomUnoccupiedSeat();
            }

            seat.occupied = true;
            seat.seatedPassenger = passengers[i];
            // Console.WriteLine("passenger " + i + " has occupied seat number " + QTools.findIndex(seat, seats));
        }

        bool lastPassengerIsInLastSeat = passengers[passengers.Length - 1].Equals(seats[passengers.Length - 1].seatedPassenger);
        // Console.WriteLine("Trial " + currentIteration + " returned " + lastPassengerIsInLastSeat);
        return lastPassengerIsInLastSeat;
    }

    private Seat getRandomUnoccupiedSeat()
    {
        Seat seat = getRandomSeat();
        if (seat.occupied)
        {
            seat = getRandomUnoccupiedSeat();
        }
        return seat;
    }

    private Seat getRandomSeat()
    {
        int r = random.Next(0, passengers.Length);
        return seats[r];
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

}
