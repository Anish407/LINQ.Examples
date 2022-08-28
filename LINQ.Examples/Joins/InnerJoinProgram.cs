
var innerJoinWithGroup = from b in Buyer.Buyers
                join s in Supplier.Suppliers 
                on b.District equals s.District
                group s by s.District  into g
                select new {
                    g.Key,
                    data = g.Select(i=> new { 
                     i.SupplierName,
                     i.District,
                     i.SupplierAge,
                    })
                };

var innerJoin = from b in Buyer.Buyers
                         join s in Supplier.Suppliers
                         on b.District equals s.District
                         select new
                         {
                           b.District,
                           b.Name,
                           s.SupplierName,
                           s.SupplierAge
                         };

// join with more than 1 keys
var compositeJoin = from b in Buyer.Buyers
                    join s in Supplier.Suppliers
                    on new { b.Age, b.District } equals new { Age = s.SupplierAge, s.District }
                    select new 
                    {
                        b.Name,
                        supplierName= s.SupplierName,
                        b.Age,
                        b.District
                    };

// all suppliers for that buyer group inner join
var groupByJoin = from b in Buyer.Buyers
                  join s in Supplier.Suppliers
                  on b.District equals s.District into SuppliersGroup //Ienumerable<Suppliers>
                  select new
                  {
                      b.Name,
                      b.District,
                      // all suppliers for that buyer
                      //data= SuppliersGroup
                      data = from sg in SuppliersGroup
                             orderby sg.SupplierName descending
                             select sg
                  };

var leftJoin = from s in Supplier.Suppliers
               join b in Buyer.BuyersLeftJoin
               on s.District equals b.District into buyersGroup
               from bg in buyersGroup.DefaultIfEmpty()
               select new
               {
                   s.SupplierName,
                   s.District,
                   buyer= bg?.Name ?? "None"
               };

// find suppliers with no buyers
var leftJoin2 = from s in Supplier.Suppliers
               join b in Buyer.BuyersLeftJoin
               on s.District equals b.District into buyersGroup
               from bg in buyersGroup.DefaultIfEmpty()
               where bg == null
               select new
               {
                   s.SupplierName,
                   s.District,
                   buyer = buyersGroup
               };



foreach (var item in leftJoin2)
{
    Console.WriteLine($"SupplierName: {item.SupplierName}. District: {item.District}");
    foreach (var b in item.buyer)
    {
        Console.WriteLine(b.Name);
    }
}
               



Console.ReadLine();

