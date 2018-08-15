using DemoConsoleDotnetEF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsoleDotnetEF.Configurations
{
    public class OrderDetailConfiguration : EntityTypeConfiguration<OrderDetail>
    {
        public OrderDetailConfiguration()
        {

            this.ToTable("orders_details");

            this.HasKey<int>(s => s.OrderDetailsId);

              
            this.Property(p => p.ItemName)
                         .HasMaxLength(800);


            //this.HasOptional(x => x.Orden)      
            //     .WithMany()                         
            //     .HasForeignKey(x => x.OrderId);




        }

    }
}
