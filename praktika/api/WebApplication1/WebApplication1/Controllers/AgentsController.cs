using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication1.Entities;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AgentsController : ApiController
    {
        private PraktikaEntities db = new PraktikaEntities();

        // GET: api/Agents
        [ResponseType(typeof(List<Class1>))]
        public IHttpActionResult GetAgents()
        {
            return Ok(db.Agents.ToList().ConvertAll(P => new Class1(P)));
        }

        // GET: api/Agents/5
        [ResponseType(typeof(Agent))]
        public IHttpActionResult GetAgent(int id)
        {
            Agent agent = db.Agents.Find(id);
            if (agent == null)
            {
                return NotFound();
            }

            return Ok(agent);
        }

        // PUT: api/Agents/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAgent(int id, Agent agent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != agent.ID)
            {
                return BadRequest();
            }

            db.Entry(agent).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Agents
        [ResponseType(typeof(Agent))]
        public IHttpActionResult PostAgent(Agent agent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Agents.Add(agent);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = agent.ID }, agent);
        }

        // DELETE: api/Agents/5
        [ResponseType(typeof(Agent))]
        public IHttpActionResult DeleteAgent(int id)
        {
            Agent agent = db.Agents.Find(id);
            if (agent == null)
            {
                return NotFound();
            }

            db.Agents.Remove(agent);
            db.SaveChanges();

            return Ok(agent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AgentExists(int id)
        {
            return db.Agents.Count(e => e.ID == id) > 0;
        }
    }
}