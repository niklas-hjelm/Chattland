﻿using Chattland.Api.DataAccess.Entities;
using Chattland.CommonInterfaces;
using Chattland.DataTransferContract.ChatContracts;

namespace Chattland.Api.DataAccess;

public interface IChatMessageRepository : IRepository<ChatMessageDocument, string>
{
    void SetCollectionName(string name);
    Task<IEnumerable<string>> GetRoomNames();
}