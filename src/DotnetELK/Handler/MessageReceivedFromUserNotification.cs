﻿using MediatR;
namespace DotnetELK.Handler
{
    public class MessageReceivedFromUserNotification 
    {
        public DateTime SubmittedAt { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string Message { get; set; }
    }
}