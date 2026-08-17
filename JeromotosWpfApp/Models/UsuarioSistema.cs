using JeromotosWpfApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace JeromotosWpfApp.Models
{
    public class UsuarioSistema
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid PersonaId { get; set; }

        public string Usuario { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public RolUsuario Rol { get; set; }

        public bool Activo { get; set; } = true;

        [JsonIgnore]
        public string Estado
        {
            get
            {
                return Activo ? "Activo" : "Inactivo";
            }
        }

        [JsonConstructor]
        public UsuarioSistema(
            Guid id,
            Guid personaId,
            string usuario,
            string passwordHash,
            RolUsuario rol,
            bool activo = true)
        {
            Id = id;
            PersonaId = personaId;
            Usuario = usuario;
            PasswordHash = passwordHash;
            Rol = rol;
            Activo = activo;
        }

        public UsuarioSistema()
        {
        }
    }
}
