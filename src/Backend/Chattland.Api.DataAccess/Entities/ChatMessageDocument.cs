﻿using Chattland.CommonInterfaces;
using Chattland.DataTransferContract.ChatContracts;
using Chattland.DataTransferContract.DataTransferTypes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Chattland.Api.DataAccess.Entities;

public class ChatMessageDocument : BaseDocument, IChatMessage
{
    public MessageSender Sender { get; set; }
    public string Message { get; set; }
    public DateTime CreatedAt { get; set; }
}