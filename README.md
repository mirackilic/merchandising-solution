# merchandising-solution

.Net 6 N-Tier Project

Project only contains "CRUD" services for "Product" Entity.

- API, Application and Domain layers added.
- EntityFramework.
- PostgreSQL.
- Data Annotation.
- Fluent Validation

GET ​/Product => Returns All live Products

POST ​/Product => Adds new Product and Category 

PUT ​/Product => Updates Product and Category depends on your json request.

GET ​/Product​/filter = By "Search" parameter filters data on Title, Description and Category Name columns. Also "MinStockQuantity" and "MaxStockQuantity" parameters can be used to filter data on StockQuantity column.

GET ​/Product​/{id} => Returns only a data which has given id

DELETE ​/Product​/{id} => Deletes data depends on given id

