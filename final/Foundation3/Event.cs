using System;

public class Event {
    private string eventTitle;
    private string eventDescription;
    private DateTime eventDate;
    private TimeSpan eventTime;
    private Address eventAddress;

    public Event(string eventTitle, string eventDescription, DateTime eventDate, TimeSpan eventTime, Address eventAddress) {
        this.eventTitle = eventTitle;
        this.eventDescription = eventDescription;
        this.eventDate = eventDate;
        this.eventTime = eventTime;
        this.eventAddress = eventAddress;
    }

    public string GetStandardDetails() {
        return $"{eventTitle}\n{eventDescription}\n{eventDate.ToShortDateString()} at {eventTime}\n{eventAddress}\n";
    }

    public virtual string GetFullDetails() {
        return GetStandardDetails();
    }

    public virtual string GetShortDescription() {
        return $"{GetType().Name} - {eventTitle} on {eventDate.ToShortDateString()}";
    }
}