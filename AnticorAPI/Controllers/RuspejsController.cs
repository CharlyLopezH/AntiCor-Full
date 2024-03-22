using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnticorAPI;
using AnticorAPI.Entidades;
using AutoMapper;
using AnticorAPI.DTOs;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using AnticorAPI.Utils;
using System.Drawing;
using Azure;

namespace AnticorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RuspejsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper mapper;



        public RuspejsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }


        //funcional...antes de paginar
        //[HttpGet("check-curp-exists/{curp}")]
        //public IActionResult CheckCurpExists(string curp)
        //{
        //    // Realiza la lógica para verificar si la CURP existe en la otra tabla
        //    //bool curpExists = _yourService.CheckCurpExistsInSepifape(curp);
        //    bool curpExists = false; //_yourService.CheckCurpExistsInSepifape(curp);

        //    // Devuelve un resultado
        //    return Ok(curpExists);
        //}



        //GET: api/Ruspejs* original*
        [HttpGet("complete")]
        public async Task<ActionResult<IEnumerable<RuspejDTO>>> GetRuspej_DT()
        {
            //     //Sin Mapear DTO
            //     //return await _context.Ruspej_DT.ToListAsync();

            //Modificada para usar el DTO (mapper)
            var ListaRuspejs = await _context.Ruspej_DT
           .OrderBy(r => r.Id).ToListAsync();
            return mapper.Map<List<RuspejDTO>>(ListaRuspejs);
        }

        //GET: api/Ruspejs *original*
        //[HttpGet]
        // public async Task<ActionResult<IEnumerable<RuspejDTO>>> GetRuspej_DT()
        //{
        ////     //Sin Mapear DTO
        ////     //return await _context.Ruspej_DT.ToListAsync();

        //     //Modificada para usar el DTO (mapper)
        //     var ListaRuspejs = await _context.Ruspej_DT                                
        //    .OrderBy(r => r.Id).ToListAsync();
        //    return mapper.Map<List<RuspejDTO>>(ListaRuspejs);
        //}


        //GET: api/Ruspejs
        [HttpGet]
        //Controlador ok con paginación desde query;  

        public async Task<ActionResult<IEnumerable<RuspejDTO>>> GetRuspej_DT([FromQuery] PaginacionDTO paginacionDTO)
        {
            var queryable = _context.Ruspej_DT.AsQueryable();
            await HttpContext.InsertarParametrosPaginacionEnCabecera(queryable);

            var sepifapeData = await _context.Sepifape_DT                
               .Select(s => s.CURP)
               .ToListAsync();

            var ListaRuspejs = await _context.Ruspej_DT

            .OrderBy(r => r.CURP)
            .Select(r =>
            new RuspejDTO
            {

                Id = r.Id,
                CURP = r.CURP,
                Nombres = r.Nombres,
                Email = r.Email,
                //Icono = "Ok"                
                Icono = sepifapeData.Contains(r.CURP) ? "Ok" : string.Empty
                // Agrega otras propiedades según sea necesario
            })
        .Paginar(paginacionDTO)
        .ToListAsync();
            return mapper.Map<List<RuspejDTO>>(ListaRuspejs);
        }

        private AppDbContext Get_context()
        {
            return _context;
        }






        // GET: api/Ruspejs Sin Paginar
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<RuspejDTO>>> GetRuspej_DT()
        //{
        //    var ruspejData = await _context.Ruspej_DT
        //        .OrderBy(r => r.CURP)
        //        .ToListAsync();

        //    var sepifapeData = await _context.Sepifape_DT
        //        .Select(s => s.CURP)
        //        .ToListAsync();

        //    var ruspejDtoData = ruspejData.Select(r =>
        //    {
        //        //var curpExists = sepifapeData.Contains(r.CURP);
        //        //var curpExists = sepifapeData.Any(c=> string.Equals(c, r.CURP, StringComparison.OrdinalIgnoreCase));
        //        var curpExists = sepifapeData.Any(c => string.Equals(c.Trim(), r.CURP.Trim(), StringComparison.OrdinalIgnoreCase));

        //        var ruspejDto = new RuspejDTO
        //        {
        //            Id = r.Id,
        //            CURP = r.CURP,
        //            Nombres = r.Nombres,
        //            Icono = curpExists ? "Ok" : string.Empty
        //            // Agrega otros campos necesarios
        //        };

        //        return ruspejDto;
        //    }).ToList();

        //    var mappedData = mapper.Map<List<RuspejDTO>>(ruspejDtoData);

        //    return Ok(mappedData);
        //}


        // GET: api/Ruspejs para/con paginación
        //[HttpGet]
        //public async Task<ActionResult<List<RuspejDTO>>> Get([FromQuery] PaginacionDTO paginacionDTO)
        //{
        //    var ruspejData = await _context.Ruspej_DT
        //        .OrderBy(r => r.CURP)
        //        .ToListAsync();

        //    var sepifapeData = await _context.Sepifape_DT
        //        .Select(s => s.CURP)
        //        .ToListAsync();

        //    var ruspejDtoData = ruspejData.Select(r =>
        //    {
        //        var curpExists = sepifapeData.Any(c => string.Equals(c.Trim(), r.CURP.Trim(), StringComparison.OrdinalIgnoreCase));
        //        var ruspejDto = new RuspejDTO
        //        {
        //            Id = r.Id,
        //            CURP = r.CURP,
        //            Nombres = r.Nombres,
        //            Icono = curpExists ? "Ok" : string.Empty
        //            // Agrega otros campos necesarios
        //        };

        //        return ruspejDto;
        //    }).ToList();

        //    var mappedData = mapper.Map<List<RuspejDTO>>(ruspejDtoData);

        //    return Ok(mappedData);
        //}



        // GET: api/Ruspejs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ruspej>> GetRuspej(int id)
        {
            var ruspej = await _context.Ruspej_DT.FindAsync(id);

            if (ruspej == null)
            {
                return NotFound();
            }

            return ruspej;
        }

        // PUT: api/Ruspejs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRuspej(int id, Ruspej ruspej)
        {
            if (id != ruspej.Id)
            {
                return BadRequest();
            }

            _context.Entry(ruspej).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RuspejExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Ruspejs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ruspej>> PostRuspej(RuspejCreacionDTO ruspejCreacionDTO)
        {
            var ruspej = mapper.Map<Ruspej>(ruspejCreacionDTO);
            _context.Ruspej_DT.Add(ruspej);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRuspej", new { id = ruspej.Id }, ruspej);
        }

        // DELETE: api/Ruspejs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRuspej(int id)
        {
            var ruspej = await _context.Ruspej_DT.FindAsync(id);
            if (ruspej == null)
            {
                return NotFound();
            }

            _context.Ruspej_DT.Remove(ruspej);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RuspejExists(int id)
        {
            return _context.Ruspej_DT.Any(e => e.Id == id);
        }
    }
}
