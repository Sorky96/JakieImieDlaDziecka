using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Models;

[ApiController]
[Route("api/[controller]")]
public class NameRecordsController : ControllerBase
{
    private readonly INameRepository _nameRepository;
    private readonly IMemoryCache _cache;

    public NameRecordsController(INameRepository nameRepository, IMemoryCache cache)
    {
        _nameRepository = nameRepository;
        _cache = cache;
    }

    // GET: api/NameRecords
    [HttpGet]
    public async Task<ActionResult<IEnumerable<NameRecord>>> GetNameRecords([FromQuery] int year)
    {
        string cacheKey = $"names-{year}";

        if (!_cache.TryGetValue(cacheKey, out List<NameRecord> nameRecords))
        {
            nameRecords = (await _nameRepository.GetNamesByYearAsync(year)).ToList();
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(30));

            _cache.Set(cacheKey, nameRecords, cacheEntryOptions);
        }

        return nameRecords;
    }

    // GET: api/NameRecords/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<NameRecord>> GetNameRecord(int id)
    {
        var nameRecord = await _nameRepository.GetNameByIdAsync(id);
        if (nameRecord == null)
        {
            return NotFound();
        }

        return nameRecord;
    }

    // POST: api/NameRecords
    [HttpPost]
    public async Task<ActionResult<NameRecord>> PostNameRecord(NameRecord nameRecord)
    {
        await _nameRepository.AddNameRecordAsync(nameRecord);

        // Invalidate cache
        _cache.Remove($"names-{nameRecord.Year}");

        return CreatedAtAction(nameof(GetNameRecord), new { id = nameRecord.Id }, nameRecord);
    }

    // PUT: api/NameRecords/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> PutNameRecord(int id, NameRecord nameRecord)
    {
        if (id != nameRecord.Id)
        {
            return BadRequest();
        }

        await _nameRepository.UpdateNameRecordAsync(nameRecord);

        // Invalidate cache
        _cache.Remove($"names-{nameRecord.Year}");

        return NoContent();
    }

    // DELETE: api/NameRecords/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNameRecord(int id)
    {
        await _nameRepository.DeleteNameRecordAsync(id);

        // Invalidate cache
        _cache.Remove($"names-{id}");

        return NoContent();
    }
}
