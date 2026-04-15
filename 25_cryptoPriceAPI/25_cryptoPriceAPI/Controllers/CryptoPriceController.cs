using _25_cryptoPriceAPI;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class CryptoPricesController : ControllerBase
{
    private AppDbContext _context;

    // Konstruktor
    public CryptoPricesController(AppDbContext context)
    {
        _context = context;
    }

    // Alle Daten holen
    [HttpGet]
    public List<CryptoPrice> GetAll()
    {
        return _context.CryptoPrices.ToList();
    }

    // Letzte 20 Werte
    [HttpGet("Latest20")]
    public List<CryptoPrice> GetLatest20()
    {
        return _context.CryptoPrices
            .OrderByDescending(x => x.Timestamp)
            .Take(20)
            .ToList();
    }

    [HttpGet("{id}")]
    public CryptoPrice GetId(int id)
    {
        foreach (CryptoPrice c in _context.CryptoPrices.ToList())
        {
            if (c.Id == id)
                return c;
        }
        return null;
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, CryptoPrice newPrice)
    {
        CryptoPrice existing = null;
        foreach (CryptoPrice c in _context.CryptoPrices.ToList())
        {
            if (c.Id == id)
                existing = c;
        }
        

        if (existing == null)
            return NotFound();

        // Werte ändern
        existing.Price = newPrice.Price;
        existing.Timestamp = DateTime.Now;

        _context.SaveChanges();

        return Ok(existing);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        CryptoPrice existing = null;
        foreach (CryptoPrice c in _context.CryptoPrices.ToList())
        {
            if (c.Id == id)
                existing = c;
        }


        if (existing == null)
            return NotFound();

        _context.CryptoPrices.Remove(existing);       
        _context.SaveChanges();

        return Ok(existing);
    }

    // Anzahl der Einträge
    [HttpGet("count")]
    public int GetCount()
    {
        return _context.CryptoPrices.Count();
    }

    // Neuen Wert speichern
    [HttpPost]
    public IActionResult Create(CryptoPrice price)
    {
        _context.CryptoPrices.Add(price);
        _context.SaveChanges();

        return Ok(price);
    }
}