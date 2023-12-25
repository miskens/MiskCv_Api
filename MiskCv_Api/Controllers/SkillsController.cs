﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiskCv_Api.Data;
using MiskCv_Api.Models;
using MiskCv_Api.Services.Repositories.SkillsRepository;

namespace MiskCv_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly MiskCvDbContext _context;
        private readonly ISkillRepository _skillRepository;

        public SkillsController(MiskCvDbContext context, ISkillRepository skillRepository)
        {
            _context = context;
            _skillRepository = skillRepository;
        }

        #region GET

        // GET: api/Skills
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Skill>>> GetSkill()
        {
            var skills = await _skillRepository.GetSkills();

            if (skills == null)
            {
                return NotFound();
            }

            return Ok(skills);
        }

        // GET: api/Skills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Skill>> GetSkill(int id)
        {
            var skill = await _skillRepository.GetSkill(id);

            if (skill == null)
            {
                return NotFound();
            }

            return skill;
        }

        #endregion

        #region PUT

        // PUT: api/Skills/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSkill(int id, Skill skill)
        {
            if (id != skill.Id)
            {
                return BadRequest();
            }

            var updatedSkill = await _skillRepository.UpdateSkill(id, skill);

            return NoContent();
        }

        #endregion

        #region POST

        // POST: api/Skills
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Skill>> PostSkill(Skill skill)
        {
          if (_context.Skill == null)
          {
              return Problem("Entity set 'MiskCvDbContext.Skill'  is null.");
          }
            _context.Skill.Add(skill);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSkill", new { id = skill.Id }, skill);
        }

        #endregion

        #region DELETE

        // DELETE: api/Skills/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkill(int id)
        {
            if (_context.Skill == null)
            {
                return NotFound();
            }
            var skill = await _context.Skill.FindAsync(id);
            if (skill == null)
            {
                return NotFound();
            }

            _context.Skill.Remove(skill);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion

        #region HELPERS

        private bool SkillExists(int id)
        {
            return (_context.Skill?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        #endregion
    }
}
