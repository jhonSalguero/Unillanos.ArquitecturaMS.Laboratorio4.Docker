using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using System.Text.Json;
using Newtonsoft.Json;

namespace Unillanos.ArquitecturaMS.Usuarios.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        [HttpGet]
        [Route("LeerUsuario")]

        public string Get()
        {
            string path = @"dbUsers.json";
            // Reader the file if it exists.
            if (System.IO.File.Exists(path))
            {
                StreamReader r = new StreamReader(path);
                string reader = r.ReadToEnd();
                r.Close();
                UsuariosDto info = JsonConvert.DeserializeObject<UsuariosDto>(reader);

                return reader + "\n Reader OK";
            }
            else
            {
                return "No existe";
            }
        }

        [HttpPost]
        [Route("InsertUsuario")]
        public string Post(UsuariosDto usuario)
        {
            //string path = @"C:\Windows\Temp\dbUsers.js
            string path = @"dbUsers.json";

            // Delete the file if it exists.
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            string jsonString = System.Text.Json.JsonSerializer.Serialize(usuario);
            System.IO.File.WriteAllText(path, jsonString);

            return jsonString + "\n Insert OK";
        }

        [HttpPut]
        [Route("UpdateUsuario/{nombre}/{apellido}/{sexo}/{correo}/{telefono}/{edad}")]
        public string Put(UsuariosDto user, String nombre, String apellido, String sexo, String correo, String telefono, String edad)
        {
            string path = @"dbUsers.json";
            // Update the file if it exists.
            if (System.IO.File.Exists(path))
            {
                StreamReader r = new StreamReader(path);
                string update = r.ReadToEnd();
                r.Close();
                UsuariosDto info = JsonConvert.DeserializeObject<UsuariosDto>(update);
                info.Nombre = nombre;
                info.Apellido = apellido;
                info.Sexo = sexo;
                info.Correo = correo;
                info.Telefono = telefono;
                info.Edad = edad;
                string jsonString = System.Text.Json.JsonSerializer.Serialize(info);
                System.IO.File.WriteAllText(path, jsonString);

                return jsonString + "\n Update OK";
            }
            else
            {
                return "Error";
            }
        }

        [HttpDelete]
        [Route("DeleteUsuario")]
        public string Delete()
        {
            string path = @"dbUsers.json";
            // Delete the file if it exists.
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            return "Delete Ok";
        }

        public class UsuariosDto
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Sexo { get; set; }
            public string Correo { get; set; }
            public string Telefono { get; set; }
            public string Edad { get; set; }
        }
    }
}
