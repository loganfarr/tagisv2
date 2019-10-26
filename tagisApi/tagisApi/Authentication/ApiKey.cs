using System;
using System.Collections.Generic;

namespace tagisApi.Authentication
{
    public class ApiKey
    {
        public int Id { get; }
        public string Owner { get; }
        public string Key { get; }
        public DateTime Created { get; }
        public IReadOnlyCollection<string> Roles { get; }

        public ApiKey(int id, string owner, string key, DateTime created, IReadOnlyCollection<string> roles)
        {
            Id = id;
            Owner = owner;
            Key = key;
            Created = created;
            Roles = roles;
        }
    }
}