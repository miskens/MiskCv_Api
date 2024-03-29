﻿namespace MiskCv_Api.Data.Repositories.SkillsRepository;

public class SkillRepository : ISkillRepository
{
    private readonly MiskCvDbContext _context;

    public SkillRepository(
            MiskCvDbContext context)
    {
        _context = context;
    }

    #region GET
    public async Task<IEnumerable<Skill>?> GetSkills(CancellationToken cancellationToken)
    {
        if (_context.Skill == null)
        {
            return null;
        }

        var skills = await _context.Skill.ToListAsync(cancellationToken);

        if (skills.Count < 0 || skills == null)
        {
            return null;
        }

        return skills;
    }

    public async Task<Skill?> GetSkill(int id, CancellationToken cancellationToken)
    {
        if (_context.Skill == null)
        {
            return null;
        }

        var skill = await _context.Skill.FindAsync(id, cancellationToken);

        if (skill == null)
        {
            return null;
        }

        return skill;
    }

    #endregion

    #region PUT

    public async Task<Skill?> UpdateSkill(int id, Skill skill, CancellationToken cancellationToken)
    {
        if (_context.Skill == null)
        {
            return null;
        }

        _context.Entry(skill).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EntityExists(id))
            {
                return null;
            }
            else
            {
                throw;
            }
        }

        return skill;
    }

    #endregion

    #region POST

    public async Task<Skill?> CreateSkill(Skill skill, CancellationToken cancellationToken, int companyId = 0)
    {
        if (_context.Skill == null || _context.Company == null) { return null; }

        if (companyId > 0)
        {
            var company = await _context.Company.FindAsync(companyId, cancellationToken);

            if (company != null)
                skill.Company.Add(company);
        }

        _context.Skill.Add(skill);
        await _context.SaveChangesAsync(cancellationToken);

        return skill;
    }

    #endregion

    #region DELETE

    public async Task<bool> DeleteSkill(int id, CancellationToken cancellationToken)
    {
        if (_context.Skill == null) { return false; }

        var skill = await _context.Skill.FindAsync(id, cancellationToken);
        if (skill == null) { return false; };

        _context.Skill.Remove(skill);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }

    #endregion

    #region HELPERS
    private bool EntityExists(int id)
    {
        return (_context.Skill?.Any(e => e.Id == id)).GetValueOrDefault();
    }

    #endregion
}
