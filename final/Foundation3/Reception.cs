using System;

public class Reception : Event {
    private string rsvpEmail;

    public Reception(string eventTitle, string eventDescription, DateTime eventDate, TimeSpan eventTime, Address eventAddress, string rsvpEmail)
        : base(eventTitle, eventDescription, eventDate, eventTime, eventAddress) {
        this.rsvpEmail = rsvpEmail;
    }

    public override string GetFullDetails() {
        return $"{base.GetFullDetails()}RSVP email: {rsvpEmail}\n";
    }
}