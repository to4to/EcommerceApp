# 🛒 E-commerce Backend API

A fully functional e-commerce backend built with **ASP.NET Core 9.0**, featuring user authentication, product management, shopping cart functionality, and order processing.

## 🚀 Features

- **🔐 User Authentication & Authorization**
  - JWT-based authentication
  - User registration and login
  - Password hashing with BCrypt
  - Protected API endpoints

- **📦 Product Management**
  - CRUD operations for products
  - Product search and filtering
  - Category-based product browsing
  - Stock quantity management

- **🛍️ Shopping Cart**
  - Add/remove items from cart
  - Update item quantities
  - Clear entire cart
  - Persistent cart storage

- **📋 Order Management**
  - Create orders from cart items
  - Order status tracking
  - Order history for users
  - Admin order management

- **🗄️ Database**
  - SQLite database with Entity Framework Core
  - Automatic database creation and seeding
  - Sample product data included

## 🛠️ Technology Stack

- **.NET 9.0** - Latest .NET framework
- **ASP.NET Core Web API** - RESTful API framework
- **Entity Framework Core** - ORM for database operations
- **SQLite** - Lightweight database for development
- **JWT Authentication** - Secure token-based authentication
- **BCrypt** - Password hashing
- **OpenAPI/Swagger** - API documentation

## 📋 Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- Visual Studio Code, Visual Studio, or JetBrains Rider
- Git (for version control)

## 🚀 Getting Started

### 1. Clone the Repository

```bash
git clone <your-repository-url>
cd EcommerceApp
```

### 2. Restore Dependencies

```bash
dotnet restore
```

### 3. Build the Project

```bash
dotnet build
```

### 4. Run the Application

```bash
dotnet run
```

The API will be available at:
- **HTTP**: `http://localhost:5218`
- **HTTPS**: `https://localhost:7181`

### 5. View API Documentation

Once the application is running, you can access the OpenAPI documentation at:
- `http://localhost:5218/openapi/v1.json`

## 📚 API Endpoints

### 🔐 Authentication (`/api/auth`)

#### Register a new user
```http
POST /api/auth/register
Content-Type: application/json

{
  "email": "user@example.com",
  "password": "password123",
  "firstName": "John",
  "lastName": "Doe",
  "phoneNumber": "+1234567890"
}
```

**Response:**
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "user": {
    "id": 1,
    "email": "user@example.com",
    "firstName": "John",
    "lastName": "Doe",
    "phoneNumber": "+1234567890",
    "createdAt": "2024-01-15T10:30:00Z"
  }
}
```

#### Login user
```http
POST /api/auth/login
Content-Type: application/json

{
  "email": "user@example.com",
  "password": "password123"
}
```

**Response:**
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "user": {
    "id": 1,
    "email": "user@example.com",
    "firstName": "John",
    "lastName": "Doe",
    "phoneNumber": "+1234567890",
    "createdAt": "2024-01-15T10:30:00Z"
  }
}
```

#### Get current user info
```http
GET /api/auth/me
Authorization: Bearer YOUR_JWT_TOKEN
```

**Response:**
```json
{
  "id": 1,
  "email": "user@example.com",
  "firstName": "John",
  "lastName": "Doe",
  "phoneNumber": "+1234567890",
  "createdAt": "2024-01-15T10:30:00Z"
}
```

### 📦 Products (`/api/products`)

#### Get all products
```http
GET /api/products
```

**Response:**
```json
[
  {
    "id": 1,
    "name": "Wireless Bluetooth Headphones",
    "description": "High-quality wireless headphones with noise cancellation and 30-hour battery life.",
    "price": 199.99,
    "stockQuantity": 50,
    "imageUrl": "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?w=500",
    "category": "Electronics",
    "createdAt": "2024-01-15T10:30:00Z",
    "updatedAt": "2024-01-15T10:30:00Z"
  }
]
```

#### Get product by ID
```http
GET /api/products/1
```

#### Search products
```http
GET /api/products/search?q=headphones
```

#### Get products by category
```http
GET /api/products/category/Electronics
```

#### Create new product (Admin)
```http
POST /api/products
Content-Type: application/json

{
  "name": "New Product",
  "description": "Product description",
  "price": 99.99,
  "stockQuantity": 50,
  "category": "Electronics",
  "imageUrl": "https://example.com/image.jpg"
}
```

#### Update product (Admin)
```http
PUT /api/products/1
Content-Type: application/json

{
  "name": "Updated Product Name",
  "description": "Updated description",
  "price": 129.99,
  "stockQuantity": 75,
  "category": "Electronics",
  "imageUrl": "https://example.com/updated-image.jpg"
}
```

#### Delete product (Admin)
```http
DELETE /api/products/1
```

### 🛍️ Shopping Cart (`/api/cart`)

> **Note:** All cart endpoints require authentication. Include `Authorization: Bearer YOUR_JWT_TOKEN` header.

#### Get user's cart
```http
GET /api/cart
Authorization: Bearer YOUR_JWT_TOKEN
```

**Response:**
```json
{
  "items": [
    {
      "id": 1,
      "productId": 1,
      "productName": "Wireless Bluetooth Headphones",
      "productPrice": 199.99,
      "productImageUrl": "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?w=500",
      "quantity": 2,
      "totalPrice": 399.98,
      "addedAt": "2024-01-15T10:30:00Z"
    }
  ],
  "totalAmount": 399.98,
  "totalItems": 2
}
```

#### Add item to cart
```http
POST /api/cart/items
Authorization: Bearer YOUR_JWT_TOKEN
Content-Type: application/json

{
  "productId": 1,
  "quantity": 2
}
```

**Response:**
```json
{
  "id": 1,
  "productId": 1,
  "productName": "Wireless Bluetooth Headphones",
  "productPrice": 199.99,
  "productImageUrl": "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?w=500",
  "quantity": 2,
  "totalPrice": 399.98,
  "addedAt": "2024-01-15T10:30:00Z"
}
```

#### Update cart item quantity
```http
PUT /api/cart/items/1
Authorization: Bearer YOUR_JWT_TOKEN
Content-Type: application/json

3
```

#### Remove item from cart
```http
DELETE /api/cart/items/1
Authorization: Bearer YOUR_JWT_TOKEN
```

#### Clear entire cart
```http
DELETE /api/cart
Authorization: Bearer YOUR_JWT_TOKEN
```

### 📋 Orders (`/api/orders`)

> **Note:** All order endpoints require authentication. Include `Authorization: Bearer YOUR_JWT_TOKEN` header.

#### Create order from cart
```http
POST /api/orders
Authorization: Bearer YOUR_JWT_TOKEN
Content-Type: application/json

{
  "shippingAddress": "123 Main St, City, State 12345",
  "billingAddress": "123 Main St, City, State 12345",
  "notes": "Please deliver during business hours"
}
```

**Response:**
```json
{
  "id": 1,
  "userId": 1,
  "orderDate": "2024-01-15T10:30:00Z",
  "status": "Pending",
  "totalAmount": 399.98,
  "shippingAddress": "123 Main St, City, State 12345",
  "billingAddress": "123 Main St, City, State 12345",
  "notes": "Please deliver during business hours",
  "orderItems": [
    {
      "id": 1,
      "productId": 1,
      "productName": "Wireless Bluetooth Headphones",
      "quantity": 2,
      "unitPrice": 199.99,
      "totalPrice": 399.98
    }
  ]
}
```

#### Get user's orders
```http
GET /api/orders
Authorization: Bearer YOUR_JWT_TOKEN
```

#### Get order by ID
```http
GET /api/orders/1
Authorization: Bearer YOUR_JWT_TOKEN
```

#### Update order status (Admin)
```http
PUT /api/orders/1/status
Authorization: Bearer YOUR_JWT_TOKEN
Content-Type: application/json

"Processing"
```

#### Get all orders (Admin)
```http
GET /api/orders/admin/all
Authorization: Bearer YOUR_JWT_TOKEN
```

## 🧪 Testing with cURL

### 1. Register a User
```bash
curl -X POST http://localhost:5218/api/auth/register \
  -H "Content-Type: application/json" \
  -d '{
    "email": "user@example.com",
    "password": "password123",
    "firstName": "John",
    "lastName": "Doe",
    "phoneNumber": "+1234567890"
  }'
```

### 2. Login
```bash
curl -X POST http://localhost:5218/api/auth/login \
  -H "Content-Type: application/json" \
  -d '{
    "email": "user@example.com",
    "password": "password123"
  }'
```

### 3. Browse Products
```bash
curl http://localhost:5218/api/products
```

### 4. Add Item to Cart
```bash
curl -X POST http://localhost:5218/api/cart/items \
  -H "Content-Type: application/json" \
  -H "Authorization: Bearer YOUR_JWT_TOKEN" \
  -d '{
    "productId": 1,
    "quantity": 2
  }'
```

### 5. Create Order
```bash
curl -X POST http://localhost:5218/api/orders \
  -H "Content-Type: application/json" \
  -H "Authorization: Bearer YOUR_JWT_TOKEN" \
  -d '{
    "shippingAddress": "123 Main St, City, State 12345",
    "billingAddress": "123 Main St, City, State 12345",
    "notes": "Please deliver during business hours"
  }'
```

## 🧪 Testing with HTTP Files

The project includes an `EcommerceApp.http` file with sample requests for testing all endpoints. You can use this with:

- **Visual Studio Code** with REST Client extension
- **JetBrains Rider** built-in HTTP client
- **Postman** (import the requests)

## 🔧 Configuration

### Database Connection

The application uses SQLite by default. The connection string is configured in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=ecommerce.db"
  }
}
```

### JWT Settings

JWT configuration is also in `appsettings.json`:

```json
{
  "JwtSettings": {
    "SecretKey": "YourSuperSecretKeyThatIsAtLeast32CharactersLong!",
    "Issuer": "EcommerceApp",
    "Audience": "EcommerceAppUsers",
    "ExpirationHours": 24
  }
}
```

## 🗄️ Database Schema

### Users
- `Id` (Primary Key)
- `Email` (Unique)
- `PasswordHash`
- `FirstName`, `LastName`
- `PhoneNumber`
- `CreatedAt`, `UpdatedAt`

### Products
- `Id` (Primary Key)
- `Name`, `Description`
- `Price`, `StockQuantity`
- `ImageUrl`, `Category`
- `CreatedAt`, `UpdatedAt`

### Orders
- `Id` (Primary Key)
- `UserId` (Foreign Key)
- `OrderDate`, `Status`
- `TotalAmount`
- `ShippingAddress`, `BillingAddress`
- `Notes`

### OrderItems
- `Id` (Primary Key)
- `OrderId` (Foreign Key)
- `ProductId` (Foreign Key)
- `Quantity`, `UnitPrice`

### CartItems
- `Id` (Primary Key)
- `UserId` (Foreign Key)
- `ProductId` (Foreign Key)
- `Quantity`, `AddedAt`

## 📦 Sample Data

The application automatically seeds the database with 10 sample products across different categories:

- **Electronics**: Wireless headphones, fitness watch, phone charger
- **Clothing**: Organic cotton t-shirt
- **Food & Beverages**: Premium coffee beans
- **Sports & Fitness**: Yoga mat, running shoes
- **Home & Kitchen**: Ceramic dinner set, LED desk lamp
- **Accessories**: Leather wallet

## 🔒 Security Features

- **JWT Authentication**: Secure token-based authentication
- **Password Hashing**: BCrypt for secure password storage
- **Input Validation**: Data annotations for request validation
- **SQL Injection Protection**: Entity Framework parameterized queries
- **CORS Configuration**: Configurable cross-origin requests

## 🚀 Deployment

### Development
```bash
dotnet run
```

### Production Build
```bash
dotnet publish -c Release -o ./publish
```

### Docker (Optional)
```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY ./publish .
ENTRYPOINT ["dotnet", "EcommerceApp.dll"]
```

## 📊 API Response Codes

| Code | Description |
|------|-------------|
| 200 | OK - Request successful |
| 201 | Created - Resource created successfully |
| 204 | No Content - Request successful, no content returned |
| 400 | Bad Request - Invalid request data |
| 401 | Unauthorized - Authentication required |
| 403 | Forbidden - Access denied |
| 404 | Not Found - Resource not found |
| 500 | Internal Server Error - Server error |

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🆘 Support

If you encounter any issues or have questions:

1. Check the [Issues](https://github.com/your-repo/issues) page
2. Create a new issue with detailed description
3. Contact the development team

## 🔮 Future Enhancements

- [ ] Role-based authorization (Admin, Customer)
- [ ] Email notifications for orders
- [ ] Payment integration
- [ ] Product reviews and ratings
- [ ] Inventory management
- [ ] Order tracking with shipping providers
- [ ] Admin dashboard
- [ ] API rate limiting
- [ ] Caching for better performance
- [ ] Logging and monitoring

---

**Happy Coding! 🎉**