// 代码生成时间: 2025-09-14 09:26:31
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// RESTful API controller example using C# and Xamarin
[Route("api/[controller]/[action]"])
[ApiController]
public class SampleController : ControllerBase
{
    // This is a sample in-memory data store. In a real application, you should use a database.
    private static readonly List<string> _items = new List<string> { "Item1", "Item2", "Item3" };

    // GET: api/sample/getallitems
    [HttpGet]
    public ActionResult<List<string>> GetAllItems()
    {
        // Return all items from the in-memory data store.
        return Ok(_items);
    }

    // GET: api/sample/getitem/5
    [HttpGet("{id}")]
    public ActionResult<string> GetItem(int id)
    {
        // Find the item by id in the in-memory data store.
        var item = _items.Find(i => i == id.ToString());
        if (item == null)
        {
            // If the item is not found, return a NotFound result.
            return NotFound();
        }
        return Ok(item);
    }

    // POST: api/sample/additem
    [HttpPost]
    public async Task<ActionResult<string>> AddItem([FromBody] string item)
    {
        if (string.IsNullOrWhiteSpace(item))
        {
            // Return a BadRequest if the item is null or whitespace.
            return BadRequest("Item cannot be null or whitespace.");
        }
        _items.Add(item);
        // Return the newly added item with a CreatedAtRoute result.
        return CreatedAtRoute("GetItem", new { id = _items.IndexOf(item) }, item);
    }

    // PUT: api/sample/updateitem/5
    [HttpPut("{id}")]
    public ActionResult UpdateItem(int id, [FromBody] string item)
    {
        if (string.IsNullOrWhiteSpace(item))
        {
            // Return a BadRequest if the item is null or whitespace.
            return BadRequest("Item cannot be null or whitespace.");
        }
        var index = _items.FindIndex(i => i == id.ToString());
        if (index == -1)
        {
            // If the item is not found, return a NotFound result.
            return NotFound();
        }
        _items[index] = item;
        return Ok(item);
    }

    // DELETE: api/sample/deleteitem/5
    [HttpDelete("{id}")]
    public ActionResult DeleteItem(int id)
    {
        var item = _items.Find(i => i == id.ToString());
        if (item == null)
        {
            // If the item is not found, return a NotFound result.
            return NotFound();
        }
        _items.Remove(item);
        return Ok($"Item with id {id} has been deleted.");
    }
}
