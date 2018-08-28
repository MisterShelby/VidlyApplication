using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using VidlyApplication.Models;
using VidlyApplication.Dtos;
using AutoMapper;

namespace VidlyApplication.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _contex;
        public CustomersController()
        {
            _contex = new ApplicationDbContext();
        }

        // GET api/customers/   
        public IHttpActionResult GetCustomers(string query= null)
        {


            var customersQuery = _contex.Customers
                .Include(c => c.MembershipType);

            if (!String.IsNullOrWhiteSpace(query))
            {
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));
            }

            var customerDtos=customersQuery
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customerDtos);
        }

        // GET api/customers/1
        public IHttpActionResult GetCustomer(int Id)
        {
            var customer = _contex.Customers.SingleOrDefault(c => c.Id == Id);

            if (customer==null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Customer,CustomerDto>(customer));
        }

        // POST api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer (CustomerDto customerDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _contex.Customers.Add(customer);
            _contex.SaveChanges();
            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        //Put api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id,CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var customerInDb = _contex.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb==null)
            {
                return NotFound();
            }
            Mapper.Map(customerDto, customerInDb);
            _contex.SaveChanges();
            return Ok();

        }
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int Id)
        {
            var customer = _contex.Customers.SingleOrDefault(c => c.Id == Id);
            if (customer ==null)
            {
                return NotFound();
            }

            _contex.Customers.Remove(customer);
            _contex.SaveChanges();
            return Ok();
        }

        
    }
}
