
# OrderManagerMvc — Group Assignment Starter

This is a minimal ASP.NET Core **MVC** starter using **EF Core (SQL Server)** with **four entities**:
- `Customer`
- `Product`
- `Order`
- `OrderItem`

## Quick Start
1. Ensure **SQL Server** or **LocalDB** is installed.
2. Open the solution folder in **Visual Studio** or run via CLI:
   ```bash
   dotnet restore
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   dotnet run
   ```

3. If needed, change the connection string in `appsettings.json` (`DefaultConnection`).
   - For full SQL Server: `Server=localhost;Database=OrderManagerMvc;Trusted_Connection=True;TrustServerCertificate=True`
   - For Azure SQL: `Server=tcp:<server>.database.windows.net,1433;Initial Catalog=OrderManagerMvc;User ID=<user>;Password=<pwd>;Encrypt=True;`

## Scaffold CRUD (Visual Studio)
Right-click the project → **Add** → **New Scaffolded Item** → **MVC Controller with views, using EF**.
Generate for each entity:
- `CustomersController` (DbContext: `AppDbContext`)
- `ProductsController`
- `OrdersController`
- `OrderItemsController`

> Tip: For `OrderItems`, show dropdowns for `Order` and `Product`, and capture `UnitPrice` as a snapshot from `Product` when creating an item.

## Group Tasks
- **DB Lead**: Define relationships, precision (money fields), seed data, and create migrations.
- **Backend Lead**: Business logic (setting `OrderItem.UnitPrice` from `Product.UnitPrice`), validation, computed totals.
- **UI Lead**: Styling, list/detail forms, search/filter on lists.
- **QA Lead**: Smoke tests, data validation, basic integration tests.

## Acceptance Criteria
- CRUD works for all four entities.
- `OrderItem.UnitPrice` defaults to selected `Product.UnitPrice` on create.
- `Order` details page shows itemized lines and the computed total.
- Deleting a `Customer` with `Orders` is prevented (or handled) — document your choice.
- All money values use two decimals.
- Seed data loads and app boots with `/` showing Home page.

## Useful EF CLI
```bash
dotnet tool install --global dotnet-ef
dotnet ef migrations add <Name>
dotnet ef database update
dotnet ef database drop
```
