using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluacionNro2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {

            using (Models.Models.EvaluacionNro2Context db = new Models.Models.EvaluacionNro2Context())
            {
                var lst = (from d in db.Estudiantes select d).ToList();
                return Ok(lst);
            }
        }

        [HttpPost]

        public ActionResult Post([FromBody] Models.Request.estudiantesRequest model)
        {
            using (Models.Models.EvaluacionNro2Context db = new Models.Models.EvaluacionNro2Context())
            {
                Models.Models.Estudiante oEstudiante = new Models.Models.Estudiante();
                oEstudiante.Nombre = model.nombre;
                oEstudiante.Edad = model.edad;
                oEstudiante.Correo = model.correo;
                db.Estudiantes.Add(oEstudiante);
                db.SaveChanges();
            }
            return Ok();
        }

        [HttpPut]
        public ActionResult Put([FromBody] Models.Request.estudiantesRequest model)
        {
            using (Models.Models.EvaluacionNro2Context db = new Models.Models.EvaluacionNro2Context())
            {
                Models.Models.Estudiante oEstudiante = db.Estudiantes.Find(model.id);
                oEstudiante.Nombre = model.nombre;
                oEstudiante.Edad = model.edad;
                oEstudiante.Correo = model.correo;
                db.Entry(oEstudiante).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            return Ok();
        }

        [HttpDelete]

        public ActionResult Delete([FromBody] Models.Request.estudiantesRequest model)
        {
            using (Models.Models.EvaluacionNro2Context db = new Models.Models.EvaluacionNro2Context())
            {
                Models.Models.Estudiante oEstudiante = db.Estudiantes.Find(model.id);
                db.Estudiantes.Remove(oEstudiante);
                db.SaveChanges();
            }
            return Ok();
        }

    }
}




