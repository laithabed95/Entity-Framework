using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace Order.Models
{
    public class Customer
    {
        public int CustomerID { get; set; } //primary key
        
        public string FirstName { get; set; }
         [MaxLength(30), Required]
        public string LastName { get; set; }
         [MaxLength(30), Required]
        public string Company { get; set; }
         [EmailAddress]
        public string Email { get; set; }


        [RegularExpression(@"^([0][7]+)([7,8,9]+)(\d{7})$", ErrorMessage = "only jordanian number")] 
        public string Phone { get; set; }

       // public int Rateing { get; set; }
        public DateTime Created { get; set; }

        public virtual ICollection<Address> Addresses { set; get; }
        public virtual ICollection<Order> Orders { set; get; }

    }
    public class Address 
    {
        public int AddressID { get; set; } //primary key
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { set; get; }
        public virtual ICollection<Customer> Customers { set; get; }

    }
    //3'ayrle esm el table mn order la orders 
    [Table("Orders")]//maping the table
    public class Order
    {
        public int OrderID { get; set; }//primary key
        public DateTime OrderDate { get; set; }
        public DateTime ShipDate { get; set; }
        public decimal TotalOrder { get; set; }
        public int PruductCount { get; set; }
        public int CustomerID { get; set; } //forign key
        //public int AddressID { get; set; } //forign key
        public virtual Customer Customer { set; get; }
        public virtual Address ShipToAddress { set; get; }
        public virtual Address BillToAdress { set; get; }

    }
    public class Shipper
    {
        public int ShipperID { get; set; }
        public string ShipperName { get; set; }
        
    }
    public class OrderingContext : DbContext 
    {
        public DbSet<Customer> Customers { set; get; }
        public DbSet<Order> Orders { set; get; }
        public DbSet<Address> Adresses { set; get; }
        public DbSet<Shipper> Shippers { set; get; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
          //3shan el S ele btkun bkul table bshelha
          //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();


        }
    
    }

    //public class Orderinginitilaizor :DropCreateDatabaseIfModelChanges<OrderingContext>
    //{
    //    protected override void Seed(OrderingContext context)
    //    { 
    //        List<Customer> customers=new List<Customer>
    //        {
    //            new Customer
    //            {
    //                FirstName="Laith",
    //                LastName="A'bed",
    //                Company="Askadnya",
    //                Email="L.aith@hotmail.com",
    //                Phone="0799293933",
    //                Created=DateTime.Now

    //            },
    //              new Customer
    //            {
    //                FirstName="Ahmad",
    //                LastName="Ali",
    //                Company="Abc",
    //                Email="abc@yahoo.com",
    //                Phone="0799999999",
    //                Created=DateTime.Now
    //            }
    //          };

    //            customers.ForEach(c => context.Customers.Add(c));
    //    }

   
}