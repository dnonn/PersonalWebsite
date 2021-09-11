using BuildingBlocks.Application.Exceptions;
using BuildingBlocks.Application.Interfaces;
using BuildingBlocks.Infrastructure.Configuration;
using HashidsNet;

namespace BuildingBlocks.Infrastructure.Services
{
    public class HashIdService : IHashIdService
    {
        private readonly Hashids _hashIds;

        public HashIdService(HashIdConfiguration hashIdConfiguration)
        {
            _hashIds = new Hashids(hashIdConfiguration.Salt, hashIdConfiguration.Length);
        }

        public string Encode(int id)
        {
            return _hashIds.Encode(id);
        }

        public int Decode(string hashId)
        {
            var ids = _hashIds.Decode(hashId);
            if (ids.Length < 1)
            {
                throw new HashIdDecodingException(hashId);
            }

            return ids[0];
        }
    }
}
