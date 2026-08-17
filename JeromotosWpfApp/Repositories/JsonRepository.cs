using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace JeromotosWpfApp.Repositories
{
    public class JsonRepository<T> where T : class
    {
        private readonly string filePath;
        private readonly string folder;

        public JsonRepository(string folder, string filePath)
        {
            this.folder = folder;
            this.filePath = filePath;
        }

       
        public List<T> GetAll()
        {
            List<T> list = new List<T>();

            try
            {
                if (File.Exists(filePath))
                {
                    using (StreamReader sr = new StreamReader(filePath))
                    {
                        string json =
                            sr.ReadToEnd();

                        if (json != string.Empty)
                        {
                            list = JsonSerializer.Deserialize<List<T>>(json) ?? list;
                        }
                    }
                }
                else
                {
                    Directory.CreateDirectory(folder);

                    File.WriteAllText(filePath, "[]");
                }

                return list;
            }
            catch (JsonException ex)
            {
                throw new Exception("El archivo JSON está corrupto.", ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new Exception("No tienes permisos para acceder al archivo.", ex);
            }
            catch (IOException ex)
            {
                throw new Exception("Error de lectura o escritura del archivo.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al cargar los datos.", ex);
            }
        }


        public void Save(List<T> list)
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            using (StreamWriter sw =
                new StreamWriter(filePath))
            {
                string json = JsonSerializer.Serialize(list, options);
                sw.Write(json);
            }
        }

        public void Update(T newItem, Func<T, bool> predicate)
        {
            List<T> list = GetAll();

            int index = list.FindIndex(item => predicate(item));

            if (index != -1)
            {
                list[index] = newItem;

                Save(list);
            }
        }

        public void Delete(Func<T, bool> predicate)
        {
            List<T> list = GetAll();

            list.RemoveAll(item => predicate(item));

            Save(list);
        }
       
        public T? Find(Func<T, bool> predicate)
        {
            List<T> list = GetAll();

            return list.FirstOrDefault(item =>
                predicate(item));
        }

    }
}
