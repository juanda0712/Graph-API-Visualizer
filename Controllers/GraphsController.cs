using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Graph_API_Visualizer.Models;
using Graph_API_Visualizer.Services;


namespace Graph_API_Visualizer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GraphsController : ControllerBase  
    {
        public GraphsController()
        {
        }

        [HttpPost]
        public IActionResult Create(Graph graph)
        {    
            GraphService.Add(graph);
            return CreatedAtAction(nameof(Create),new {id = graph.Id},graph);      
        }

        [HttpGet]
        public ActionResult<List<Graph>> GetAll() =>
            GraphService.GetAll();

        [HttpDelete]
        public IActionResult DeleteAll()
        {
            GraphService.DeleteAll();

            return NoContent();
        }

        [HttpGet("{id}")]
        public ActionResult<Graph> Get(int id)
        {
            var graph = GraphService.Get(id);

            if(graph == null )
                return NotFound();
            
            return graph;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingGraph = GraphService.Get(id);
            if(existingGraph is null)
                return NotFound();

            GraphService.Delete(id);

            return NoContent();
        }

        [HttpPost("{id}/nodes")]
        public IActionResult CreateNode(int id, Node node)
        {    
            var graph = GraphService.Get(id);
            graph.Nodes.Add(node);
            GraphService.Add(graph);
            return CreatedAtAction(nameof(CreateNode),new {id = graph.Id},graph);      
        }
    }
}