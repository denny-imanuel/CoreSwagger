using System.Collections.Generic;
using CoreApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace CoreApi.Controllers
{
    [ApiController]
    public class ItemController : ControllerBase
    {
        private List<Item> items;

        ItemController()
        {
            items = new List<Item>();
            items.Add(new Item("Air", 10));
            items.Add(new Item("Brush", 20));
            items.Add(new Item("Candy", 30));
        }
        
        [HttpGet]
        [Route("getitem")]
        public Item GetItem(int idx)
        {
            return items[idx];
        }

        [HttpPut]
        [Route("putitem")]
        public bool putItem(int idx, Item item)
        {
            if (idx < items.Count)
            {
                items[idx].Name = item.Name;
                items[idx].Quantity = item.Quantity;
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpPost]
        [Route("postitem")]
        public bool postItem(Item item)
        {
            items.Add(item);
            return true;
        }

        [HttpDelete]
        [Route("deleteitem")]
        public bool deleteItem(int idx)
        {
            if (idx < items.Count)
            {
                items.RemoveAt(idx);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}