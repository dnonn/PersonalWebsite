﻿namespace BuildingBlocks.Application.Interfaces
{
    public interface IHashIdService
    {
        string Encode(int id);

        int Decode(string hashId);
    }
}
