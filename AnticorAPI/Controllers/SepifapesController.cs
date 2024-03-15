
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnticorAPI;
using AnticorAPI.Entidades;
using AutoMapper;
using AnticorAPI.DTOs;

namespace AnticorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SepifapesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper mapper;

        public SepifapesController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        [HttpGet("check-curp-exists/{curp}")]
        public IActionResult CheckCurpExists(string curp)
        {
            // Realiza la lógica para verificar si la CURP existe en la otra tabla
            //bool curpExists = _yourService.CheckCurpExistsInSepifape(curp);
            bool curpExists = _context.Sepifape_DT.Any(s => s.CURP == curp);

            // Devuelve un resultado
            return Ok(curpExists);
        }

        // GET: api/Sepifapes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RuspejDTO>>> GetRuspej_DT()
        {
            //Sin DTO
            //return await _context.Ruspej_DT.ToListAsync();

            var ListRuspej = await _context.Ruspej_DT.ToListAsync();
            return mapper.Map<List<RuspejDTO>>(ListRuspej);
        }

        // GET: api/Sepifapes/5
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

        // PUT: api/Sepifapes/5
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

        // POST: api/Sepifapes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ruspej>> PostRuspej(RuspejCreacionDTO ruspejCreacionDTO)
        {
            var ruspej = mapper.Map<Ruspej>(ruspejCreacionDTO);
            _context.Ruspej_DT.Add(ruspej);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRuspej", new { id = ruspej.Id }, ruspej);
        }

        // DELETE: api/Sepifapes/5
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
