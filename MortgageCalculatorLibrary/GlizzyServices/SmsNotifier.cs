using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using GlizzyServices;

public class SmsNotifier : INotifier
{
    private const string AccountSid = "ACd6043574f55bb1b7a2814331f826250a";
    private const string AuthToken = "82c009bd1051e88ea0899308105c9a8d"; //blah blah, environment variable, blah.
    private const string FromPhoneNumber = "+18557015642";

    static SmsNotifier()
    {
        TwilioClient.Init(AccountSid, AuthToken);
    }

    public async Task Notify(string addressFrom, string addressTo, string message)
    {
        var messageOptions = new CreateMessageOptions(new PhoneNumber(addressTo));
        messageOptions.From = new PhoneNumber(FromPhoneNumber);
        messageOptions.Body = message;

        var messageResource = await MessageResource.CreateAsync(messageOptions);

        Console.WriteLine(messageResource.Body);
    }
}
