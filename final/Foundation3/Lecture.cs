using System;

public class Lecture : Event {
    private string speakerName;
    private int capacity;

    public Lecture(string eventTitle, string eventDescription, DateTime eventDate, TimeSpan eventTime, Address eventAddress, string speakerName, int capacity)
        : base(eventTitle, eventDescription, eventDate, eventTime, eventAddress) {
        this.speakerName = speakerName;
        this.capacity = capacity;
    }

    public override string GetFullDetails() {
        return $"{base.GetFullDetails()}Speaker: {speakerName}\nCapacity: {capacity}\n";
    }
}