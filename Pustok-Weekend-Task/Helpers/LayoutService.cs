using Pustok_Weekend_Task.Contexts;
using Pustok_Weekend_Task.Models;

namespace Pustok_Weekend_Task.Helpers;

public class LayoutService
{
    PustokDbContext _context { get; }

    public LayoutService(PustokDbContext context)
    {
        _context = context;
    }

    public async Task<Setting> GetSettingsAsync()
        => await _context.Settings.FindAsync(1);
}