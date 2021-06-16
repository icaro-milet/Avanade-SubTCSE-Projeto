using System;

namespace Avanade.SubTCSE.Projeto.Domain.Aggregates.EmployeeRole.Entities
{
    public record EmployeeRole
    {
        public EmployeeRole(string id, string roleName)
        {
            Id = id;
            RoleName = roleName;
        }

        public string Id { get; private set; }

        public string RoleName { get; init; }

        public void AddRole(string roleName)
        {
            RoleName = roleName;
        }

    }
}
