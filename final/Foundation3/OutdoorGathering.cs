using System;

public class OutdoorGathering : Event 
{
    private string weatherStatement;

    public OutdoorGathering(string eventTitle, string eventDescription, DateTime eventDate, TimeSpan eventTime, Address eventAddress, string weatherStatement)
        : base(eventTitle, eventDescription, eventDate, eventTime, eventAddress) {
        this.weatherStatement = weatherStatement;
    }

    public override string GetFullDetails() {
        return $"{base.GetFullDetails()}Weather statement: {weatherStatement}\n";
    }
}