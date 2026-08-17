using JeromotosWpfApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace JeromotosWpfApp.Repositories
{
    public class PersonaRepository
    {
        private static readonly string folder = "Data";
        private static readonly string filePath = Path.Combine(folder, "persona.json");

        private readonly JsonRepository<Persona> jsonRepository =
           new JsonRepository<Persona>(folder, filePath);

        public List<Persona> GetAll()
        {
            return jsonRepository
                .GetAll()
                .OrderBy(p => p.Nombre)
                .ToList();
        }

        public void Add(Persona persona)
        {
            List<Persona> lista = jsonRepository.GetAll();

            lista.Add(persona);

            jsonRepository.Save(lista);
        }

        public void Update(Persona newPersona, Guid id)
        {
            jsonRepository.Update(
                newPersona,
                persona => persona.Id == id
            );
        }

        public void Delete(Guid id)
        {
            jsonRepository.Delete(
                persona => persona.Id == id
            );
        }

        public Persona? Find(Guid id)
        {
            return jsonRepository.Find(
                persona => persona.Id == id
            );
        }

        public bool ExistsByDocument(string documento)
        {
            return jsonRepository
                .GetAll()
                .Any(p => p.Documento.Equals(
                    documento.Trim(),
                    StringComparison.OrdinalIgnoreCase
                ));
        }

        public bool ExistsByDocument(string documento, Guid excludeId)
        {
            return jsonRepository
                .GetAll()
                .Any(p =>
                    p.Id != excludeId &&
                    p.Documento.Equals(
                        documento.Trim(),
                        StringComparison.OrdinalIgnoreCase
                    )
                );
        }

    }
}
