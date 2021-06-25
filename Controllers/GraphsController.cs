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

        [HttpPost("{id}/nodes")]  //aca
        public IActionResult CreateNode(int id, Node node)
        {    
            GraphService.AddNode(id,node);
            return CreatedAtAction(nameof(CreateNode),new {id = node.Id},node);      
        }

        
        [HttpGet("{id}/nodes")]
        public ActionResult<List<Node>> GetNode(int id) =>
            GraphService.Get(id).Nodes;

        
        [HttpPut("{id}/nodes/{id2}")]
        public IActionResult Update(int id, object entity)
        {
            try
            {
                GraphService.UpdateNode(id,entity);
                return NoContent();
            }catch
            {
                return StatusCode(500);
            }
        }
        


         [HttpDelete("{id}/nodes/{id2}")]
         public IActionResult DeleteNode(int id, int id2)
         {
             var existingGraph=GraphService.Get(id);

             if(existingGraph == null)
             {
                 return NotFound();
             }
             else
             {  
                 try
                 {
                    GraphService.DeleteNode(id,id2);
                    return StatusCode(200);
                 }
                 catch
                 {
                     return StatusCode(500);
                 }
             }
         }
         
         [HttpDelete("{id}/nodes")]

         public IActionResult DeleteAllNodes(int id)
         {
             try
             {
                GraphService.DeleteAllNode(id);
                return StatusCode(200);
             }catch
             {
                 return StatusCode (500);
             }
         }
         

         [HttpGet("{id}/edges")]
         public ActionResult<List<Edges>> GetEdges(int id) =>
            GraphService.Get(id).Edges;


        [HttpDelete ("{id}/edges")]
        public IActionResult DeleteAllEdges(int id)
        {   
            try
            {
                if (GraphService.GetEdges(id)==null)
                {
                    return NotFound();
                }
                else
                {
                    GraphService.DeleteAllEdges(id);
                    return StatusCode(200);
                }
            }catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost ("{id}/edges")]
        public IActionResult CreateEdge(int id, Edges edge)
        {    
            GraphService.AddEdge(id,edge);
            return CreatedAtAction(nameof(CreateEdge),new {id = edge.Id},edge);      
        }

        [HttpPut("{id}/edges/{id2}")]
        public IActionResult UpdateEdges(int id, int start, int end, int weight)
        {
            try
            {
                if (GraphService.GetEdges(id)==null)
                {
                    return NotFound();
                }
                else
                {
                    GraphService.UpdateEdges(id, start, end, weight);
                    return NoContent();
                }
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
