# 🛒 E-commerce Backend API - Complete Guide

> **A fully functional online store backend that anyone can run and use!**

This is a complete e-commerce system that handles user registration, product management, shopping carts, and order processing. Think of it as the "brain" behind an online store like Amazon or eBay.

## 📋 Table of Contents

1. [What is this?](#-what-is-this)
2. [What you'll need](#-what-youll-need)
3. [How to run it](#-how-to-run-it)
4. [How to use it](#-how-to-use-it)
5. [Complete API Guide](#-complete-api-guide)
6. [Troubleshooting](#-troubleshooting)
7. [Understanding the system](#-understanding-the-system)

---

## 🎯 What is this?

This is a **backend API** (Application Programming Interface) for an online store. It's like the engine that powers websites like Amazon, but you can run it on your own computer!

### What it can do:
- ✅ **User Management**: Register users, login, manage profiles
- ✅ **Product Catalog**: Browse, search, and manage products
- ✅ **Shopping Cart**: Add items, update quantities, checkout
- ✅ **Order Processing**: Create orders, track status, view history
- ✅ **Security**: Password protection, secure authentication

### Real-world example:
When you shop on Amazon:
1. You create an account (User Management)
2. You browse products (Product Catalog)
3. You add items to cart (Shopping Cart)
4. You checkout (Order Processing)

This API does all of that!

---

## 🛠️ What you'll need

### Required Software:
1. **.NET 9.0 SDK** - Download from [Microsoft's website](https://dotnet.microsoft.com/download/dotnet/9.0)
2. **A code editor** - VS Code (free), Visual Studio, or any text editor
3. **Terminal/Command Prompt** - Usually comes with your computer

### How to check if you have .NET:
Open your terminal/command prompt and type:
```bash
dotnet --version
```
If you see a version number (like 9.0.303), you're good to go!

---

## 🚀 How to run it

### Step 1: Download the project
```bash
# If you have git installed:
git clone <your-repository-url>
cd EcommerceApp

# Or download the ZIP file and extract it
```

### Step 2: Open terminal in the project folder
- **Windows**: Right-click in folder → "Open in Terminal"
- **Mac**: Right-click in folder → "Services" → "New Terminal at Folder"
- **Linux**: Right-click in folder → "Open Terminal Here"

### Step 3: Install dependencies
```bash
dotnet restore
```
*This downloads all the required libraries*

### Step 4: Build the project
```bash
dotnet build
```
*This compiles the code*

### Step 5: Run the API
```bash
dotnet run
```

### ✅ Success! 
You should see:
```
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: http://localhost:5218
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
```

**Your API is now running at: `http://localhost:5218`**

---

## 🎮 How to use it

### Method 1: Using VS Code Terminal (Recommended)

1. **Open VS Code**
2. **Open the project folder**
3. **Open Terminal** (Terminal → New Terminal)
4. **Run the commands** from this guide

### Method 2: Using Command Prompt/Terminal

1. **Open Command Prompt** (Windows) or **Terminal** (Mac/Linux)
2. **Navigate to project folder**:
   ```bash
   cd /path/to/EcommerceApp
   ```
3. **Run the commands** from this guide

### Method 3: Using Postman (GUI Tool)

1. **Download Postman** from [postman.com](https://www.postman.com/downloads/)
2. **Import the requests** from the `EcommerceApp.http` file
3. **Click "Send"** to test endpoints

---

## 📚 Complete API Reference

### 🚀 How to Run the API

1. **Start the API**:
   ```bash
   dotnet run
   ```

2. **Verify it's running**:
   ```bash
   curl http://localhost:5218/api/products
   ```

3. **API Base URL**: `http://localhost:5218`

---

## 📋 API Endpoints Table

| Category | Method | Endpoint | Description | Auth Required | Input | Output |
|----------|--------|----------|-------------|---------------|-------|--------|
| **Authentication** | POST | `/api/auth/register` | Register new user | ❌ | User details | Token + User info |
| **Authentication** | POST | `/api/auth/login` | Login user | ❌ | Email + Password | Token + User info |
| **Authentication** | GET | `/api/auth/me` | Get current user | ✅ | JWT Token | User info |
| **Products** | GET | `/api/products` | Get all products | ❌ | None | Product list |
| **Products** | GET | `/api/products/{id}` | Get product by ID | ❌ | Product ID | Product details |
| **Products** | GET | `/api/products/search?q={term}` | Search products | ❌ | Search term | Filtered products |
| **Products** | GET | `/api/products/category/{category}` | Get products by category | ❌ | Category name | Category products |
| **Products** | POST | `/api/products` | Create new product | ❌ | Product details | Created product |
| **Products** | PUT | `/api/products/{id}` | Update product | ❌ | Product ID + Details | Updated product |
| **Products** | DELETE | `/api/products/{id}` | Delete product | ❌ | Product ID | Success message |
| **Cart** | GET | `/api/cart` | Get user's cart | ✅ | JWT Token | Cart items |
| **Cart** | POST | `/api/cart/items` | Add item to cart | ✅ | JWT Token + Item | Cart item |
| **Cart** | PUT | `/api/cart/items/{id}` | Update cart item | ✅ | JWT Token + Quantity | Updated item |
| **Cart** | DELETE | `/api/cart/items/{id}` | Remove cart item | ✅ | JWT Token | Success message |
| **Cart** | DELETE | `/api/cart` | Clear entire cart | ✅ | JWT Token | Success message |
| **Orders** | POST | `/api/orders` | Create order | ✅ | JWT Token + Address | Order details |
| **Orders** | GET | `/api/orders` | Get user's orders | ✅ | JWT Token | Order list |
| **Orders** | GET | `/api/orders/{id}` | Get order by ID | ✅ | JWT Token + Order ID | Order details |
| **Orders** | PUT | `/api/orders/{id}/status` | Update order status | ✅ | JWT Token + Status | Updated order |

---

## 🔐 Authentication Endpoints

### 1. Register New User
**Purpose**: Creates a new user account

**cURL Command**:
```bash
curl -X POST http://localhost:5218/api/auth/register \
  -H "Content-Type: application/json" \
  -d '{
    "email": "john@example.com",
    "password": "password123",
    "firstName": "John",
    "lastName": "Doe",
    "phoneNumber": "+1234567890"
  }'
```

**Input**:
```json
{
  "email": "john@example.com",
  "password": "password123",
  "firstName": "John",
  "lastName": "Doe",
  "phoneNumber": "+1234567890"
}
```

**Output**:
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIxIiwiZW1haWwiOiJqb2huQGV4YW1wbGUuY29tIiwidW5pcXVlX25hbWUiOiJKb2huIERvZSIsIm5iZiI6MTc1Nzg3MTIzNCwiZXhwIjoxNzU3OTU3NjM0LCJpYXQiOjE3NTc4NzEyMzQsImlzcyI6IkVjb21tZXJjZUFwcCIsImF1ZCI6IkVjb21tZXJjZUFwcFVzZXJzIn0.4_3yZgxMSz7HLMeYf6vWC8mOxOOW5xp_zsBbLaEXU88",
  "user": {
    "id": 1,
    "email": "john@example.com",
    "firstName": "John",
    "lastName": "Doe",
    "phoneNumber": "+1234567890",
    "createdAt": "2024-01-15T10:30:00Z"
  }
}
```

### 2. Login User
**Purpose**: Authenticates existing user

**cURL Command**:
```bash
curl -X POST http://localhost:5218/api/auth/login \
  -H "Content-Type: application/json" \
  -d '{
    "email": "john@example.com",
    "password": "password123"
  }'
```

**Input**:
```json
{
  "email": "john@example.com",
  "password": "password123"
}
```

**Output**: Same as registration (token + user info)

### 3. Get Current User Info
**Purpose**: Retrieves logged-in user information

**cURL Command**:
```bash
curl -X GET http://localhost:5218/api/auth/me \
  -H "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
```

**Input**: JWT Token in Authorization header

**Output**:
```json
{
  "id": 1,
  "email": "john@example.com",
  "firstName": "John",
  "lastName": "Doe",
  "phoneNumber": "+1234567890",
  "createdAt": "2024-01-15T10:30:00Z"
}
```

---

## 📦 Product Endpoints

### 1. Get All Products
**Purpose**: Retrieves complete product catalog

**cURL Command**:
```bash
curl -X GET http://localhost:5218/api/products
```

**Input**: None

**Output**:
```json
[
  {
    "id": 1,
    "name": "Wireless Bluetooth Headphones",
    "description": "High-quality wireless headphones with noise cancellation and 30-hour battery life",
    "price": 199.99,
    "stockQuantity": 50,
    "imageUrl": "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?w=500",
    "category": "Electronics",
    "createdAt": "2024-01-15T10:30:00Z",
    "updatedAt": "2024-01-15T10:30:00Z"
  },
  {
    "id": 2,
    "name": "Smart Fitness Watch",
    "description": "Advanced fitness tracking watch with heart rate monitor, GPS, and water resistance",
    "price": 299.99,
    "stockQuantity": 30,
    "imageUrl": "https://images.unsplash.com/photo-1523275335684-37898b6baf30?w=500",
    "category": "Electronics",
    "createdAt": "2024-01-15T10:30:00Z",
    "updatedAt": "2024-01-15T10:30:00Z"
  }
]
```

### 2. Get Product by ID
**Purpose**: Retrieves specific product details

**cURL Command**:
```bash
curl -X GET http://localhost:5218/api/products/1
```

**Input**: Product ID in URL path

**Output**:
```json
{
  "id": 1,
  "name": "Wireless Bluetooth Headphones",
  "description": "High-quality wireless headphones with noise cancellation and 30-hour battery life",
  "price": 199.99,
  "stockQuantity": 50,
  "imageUrl": "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?w=500",
  "category": "Electronics",
  "createdAt": "2024-01-15T10:30:00Z",
  "updatedAt": "2024-01-15T10:30:00Z"
}
```

### 3. Search Products
**Purpose**: Finds products matching search criteria

**cURL Command**:
```bash
curl -X GET "http://localhost:5218/api/products/search?q=headphones"
```

**Input**: Search query parameter `q`

**Output**:
```json
[
  {
    "id": 1,
    "name": "Wireless Bluetooth Headphones",
    "description": "High-quality wireless headphones with noise cancellation and 30-hour battery life",
    "price": 199.99,
    "stockQuantity": 50,
    "imageUrl": "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?w=500",
    "category": "Electronics",
    "createdAt": "2024-01-15T10:30:00Z",
    "updatedAt": "2024-01-15T10:30:00Z"
  }
]
```

### 4. Get Products by Category
**Purpose**: Filters products by category

**cURL Command**:
```bash
curl -X GET "http://localhost:5218/api/products/category/Electronics"
```

**Input**: Category name in URL path

**Available Categories**: Electronics, Clothing, Food & Beverages, Sports & Fitness, Home & Kitchen, Accessories

**Output**: Array of products in specified category

### 5. Create New Product
**Purpose**: Adds new product to catalog

**cURL Command**:
```bash
curl -X POST http://localhost:5218/api/products \
  -H "Content-Type: application/json" \
  -d '{
    "name": "Gaming Mouse",
    "description": "High-precision gaming mouse with RGB lighting",
    "price": 79.99,
    "stockQuantity": 25,
    "category": "Electronics",
    "imageUrl": "https://example.com/gaming-mouse.jpg"
  }'
```

**Input**:
```json
{
  "name": "Gaming Mouse",
  "description": "High-precision gaming mouse with RGB lighting",
  "price": 79.99,
  "stockQuantity": 25,
  "category": "Electronics",
  "imageUrl": "https://example.com/gaming-mouse.jpg"
}
```

**Output**:
```json
{
  "id": 11,
  "name": "Gaming Mouse",
  "description": "High-precision gaming mouse with RGB lighting",
  "price": 79.99,
  "stockQuantity": 25,
  "imageUrl": "https://example.com/gaming-mouse.jpg",
  "category": "Electronics",
  "createdAt": "2024-01-15T10:30:00Z",
  "updatedAt": "2024-01-15T10:30:00Z"
}
```

---

## 🛍️ Shopping Cart Endpoints

> **⚠️ Important**: All cart endpoints require JWT authentication token

### 1. Get User's Cart
**Purpose**: Retrieves current user's shopping cart

**cURL Command**:
```bash
curl -X GET http://localhost:5218/api/cart \
  -H "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
```

**Input**: JWT Token in Authorization header

**Output**:
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

### 2. Add Item to Cart
**Purpose**: Adds product to user's cart

**cURL Command**:
```bash
curl -X POST http://localhost:5218/api/cart/items \
  -H "Content-Type: application/json" \
  -H "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..." \
  -d '{
    "productId": 1,
    "quantity": 2
  }'
```

**Input**:
```json
{
  "productId": 1,
  "quantity": 2
}
```

**Output**:
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

### 3. Update Cart Item Quantity
**Purpose**: Modifies quantity of cart item

**cURL Command**:
```bash
curl -X PUT http://localhost:5218/api/cart/items/1 \
  -H "Content-Type: application/json" \
  -H "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..." \
  -d '3'
```

**Input**: New quantity (number)

**Output**: Updated cart item details

### 4. Remove Item from Cart
**Purpose**: Removes specific item from cart

**cURL Command**:
```bash
curl -X DELETE http://localhost:5218/api/cart/items/1 \
  -H "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
```

**Input**: Cart item ID in URL path

**Output**: Success response (204 No Content)

### 5. Clear Entire Cart
**Purpose**: Removes all items from cart

**cURL Command**:
```bash
curl -X DELETE http://localhost:5218/api/cart \
  -H "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
```

**Input**: JWT Token only

**Output**: Success response (204 No Content)

---

## 📋 Order Endpoints

> **⚠️ Important**: All order endpoints require JWT authentication token

### 1. Create Order from Cart
**Purpose**: Converts cart items into an order

**cURL Command**:
```bash
curl -X POST http://localhost:5218/api/orders \
  -H "Content-Type: application/json" \
  -H "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..." \
  -d '{
    "shippingAddress": "123 Main St, New York, NY 10001",
    "billingAddress": "123 Main St, New York, NY 10001",
    "notes": "Please deliver during business hours"
  }'
```

**Input**:
```json
{
  "shippingAddress": "123 Main St, New York, NY 10001",
  "billingAddress": "123 Main St, New York, NY 10001",
  "notes": "Please deliver during business hours"
}
```

**Output**:
```json
{
  "id": 1,
  "userId": 1,
  "orderDate": "2024-01-15T10:30:00Z",
  "status": "Pending",
  "totalAmount": 399.98,
  "shippingAddress": "123 Main St, New York, NY 10001",
  "billingAddress": "123 Main St, New York, NY 10001",
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

### 2. Get User's Orders
**Purpose**: Retrieves all orders for current user

**cURL Command**:
```bash
curl -X GET http://localhost:5218/api/orders \
  -H "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
```

**Input**: JWT Token in Authorization header

**Output**: Array of user's orders

### 3. Get Order by ID
**Purpose**: Retrieves specific order details

**cURL Command**:
```bash
curl -X GET http://localhost:5218/api/orders/1 \
  -H "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
```

**Input**: Order ID in URL path

**Output**: Complete order details with items

### 4. Update Order Status
**Purpose**: Changes order status (Admin function)

**cURL Command**:
```bash
curl -X PUT http://localhost:5218/api/orders/1/status \
  -H "Content-Type: application/json" \
  -H "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..." \
  -d '"Processing"'
```

**Input**: New status as string

**Available Statuses**: Pending, Processing, Shipped, Delivered, Cancelled

**Output**: Updated order with new status

---

## 🔧 Complete Shopping Flow Example

Let's walk through a complete shopping experience:

### Step 1: Register a new user
```bash
curl -X POST http://localhost:5218/api/auth/register \
  -H "Content-Type: application/json" \
  -d '{
    "email": "shopper@example.com",
    "password": "password123",
    "firstName": "Jane",
    "lastName": "Smith"
  }'
```

**Save the token from the response!**

### Step 2: Browse products
```bash
curl -X GET http://localhost:5218/api/products
```

### Step 3: Add items to cart
```bash
# Add headphones
curl -X POST http://localhost:5218/api/cart/items \
  -H "Content-Type: application/json" \
  -H "Authorization: Bearer YOUR_TOKEN" \
  -d '{"productId": 1, "quantity": 1}'

# Add t-shirt
curl -X POST http://localhost:5218/api/cart/items \
  -H "Content-Type: application/json" \
  -H "Authorization: Bearer YOUR_TOKEN" \
  -d '{"productId": 3, "quantity": 2}'
```

### Step 4: View cart
```bash
curl -X GET http://localhost:5218/api/cart \
  -H "Authorization: Bearer YOUR_TOKEN"
```

### Step 5: Create order
```bash
curl -X POST http://localhost:5218/api/orders \
  -H "Content-Type: application/json" \
  -H "Authorization: Bearer YOUR_TOKEN" \
  -d '{
    "shippingAddress": "456 Oak Ave, Los Angeles, CA 90210",
    "billingAddress": "456 Oak Ave, Los Angeles, CA 90210",
    "notes": "Please ring the doorbell"
  }'
```

### Step 6: View order history
```bash
curl -X GET http://localhost:5218/api/orders \
  -H "Authorization: Bearer YOUR_TOKEN"
```

---

## 🚨 Troubleshooting

### Problem: "jq: parse error"
**Cause**: The API returned an error message instead of JSON
**Solution**: Run the command without `| jq .` first to see the actual response

```bash
# Wrong way:
curl -X POST http://localhost:5218/api/auth/register -d '...' | jq .

# Right way:
curl -X POST http://localhost:5218/api/auth/register -d '...'
# If response is JSON, then add | jq .
```

### Problem: "User with this email already exists"
**Cause**: You're trying to register with an email that's already in use
**Solution**: Use a different email address

```bash
# Use a unique email:
curl -X POST http://localhost:5218/api/auth/register \
  -d '{"email": "unique@example.com", "password": "password123", "firstName": "John", "lastName": "Doe"}'
```

### Problem: "401 Unauthorized"
**Cause**: Missing or invalid JWT token
**Solution**: Make sure you're using the correct token from login

```bash
# Get a fresh token:
curl -X POST http://localhost:5218/api/auth/login \
  -d '{"email": "your@email.com", "password": "yourpassword"}'

# Use the token in the Authorization header:
curl -X GET http://localhost:5218/api/cart \
  -H "Authorization: Bearer YOUR_ACTUAL_TOKEN"
```

### Problem: "Connection refused"
**Cause**: The API is not running
**Solution**: Start the API

```bash
cd /path/to/EcommerceApp
dotnet run
```

### Problem: "dotnet: command not found"
**Cause**: .NET SDK is not installed
**Solution**: Download and install .NET 9.0 SDK from [Microsoft's website](https://dotnet.microsoft.com/download/dotnet/9.0)

---

## 🧠 Understanding the System

### System Architecture

```
┌─────────────────┐    ┌─────────────────┐    ┌─────────────────┐
│   You (Client)  │    │   ASP.NET Core  │    │   SQLite        │
│                 │    │   Web API       │    │   Database      │
│ • curl commands │───▶│                 │───▶│                 │
│ • VS Code       │    │ • Controllers   │    │ • Users         │
│ • Postman       │    │ • Services      │    │ • Products      │
│ • Web Browser   │    │ • Authentication│    │ • Orders        │
└─────────────────┘    └─────────────────┘    └─────────────────┘
```

### How Authentication Works

1. **Register/Login** → Get JWT token
2. **Include token** in requests: `Authorization: Bearer TOKEN`
3. **API validates** token and extracts user ID
4. **Database operations** use the user ID

### Database Tables

- **Users**: Store user account information
- **Products**: Store product catalog
- **CartItems**: Store items in shopping carts
- **Orders**: Store order information
- **OrderItems**: Store individual items within orders

### Request Flow

1. **Client** sends HTTP request
2. **Controller** receives request
3. **Service** processes business logic
4. **Database** stores/retrieves data
5. **Response** sent back to client

---

## 📊 Sample Data

The system comes with 10 pre-loaded products:

| Product | Category | Price | Description |
|---------|----------|-------|-------------|
| Wireless Bluetooth Headphones | Electronics | $199.99 | High-quality wireless headphones |
| Smart Fitness Watch | Electronics | $299.99 | Advanced fitness tracking watch |
| Organic Cotton T-Shirt | Clothing | $29.99 | Comfortable organic cotton t-shirt |
| Premium Coffee Beans | Food & Beverages | $24.99 | Artisan roasted coffee beans |
| Yoga Mat Pro | Sports & Fitness | $79.99 | Non-slip yoga mat |
| Ceramic Dinner Set | Home & Kitchen | $149.99 | Handcrafted ceramic dinner set |
| LED Desk Lamp | Home & Kitchen | $89.99 | Adjustable LED desk lamp |
| Running Shoes | Sports & Fitness | $129.99 | Lightweight running shoes |
| Wireless Phone Charger | Electronics | $39.99 | Fast wireless charging pad |
| Leather Wallet | Accessories | $59.99 | Genuine leather wallet |

---

## 🎯 Quick Start Commands

Copy and paste these commands to get started:

```bash
# 1. Start the API
dotnet run

# 2. Register a user
curl -X POST http://localhost:5218/api/auth/register \
  -H "Content-Type: application/json" \
  -d '{"email": "test@example.com", "password": "password123", "firstName": "Test", "lastName": "User"}'

# 3. Login (use the token from registration)
curl -X POST http://localhost:5218/api/auth/login \
  -H "Content-Type: application/json" \
  -d '{"email": "test@example.com", "password": "password123"}'

# 4. Browse products
curl http://localhost:5218/api/products

# 5. Add to cart (replace TOKEN with actual token)
curl -X POST http://localhost:5218/api/cart/items \
  -H "Content-Type: application/json" \
  -H "Authorization: Bearer TOKEN" \
  -d '{"productId": 1, "quantity": 1}'

# 6. Create order
curl -X POST http://localhost:5218/api/orders \
  -H "Content-Type: application/json" \
  -H "Authorization: Bearer TOKEN" \
  -d '{"shippingAddress": "123 Main St", "billingAddress": "123 Main St"}'
```

---

## 🎉 Congratulations!

You now have a fully functional e-commerce API running on your computer! 

This system includes:
- ✅ User authentication and management
- ✅ Product catalog with search and filtering
- ✅ Shopping cart functionality
- ✅ Order processing and tracking
- ✅ Secure password handling
- ✅ Database persistence

You can use this as a foundation to build a complete online store or learn how modern web applications work.

---

## 📞 Need Help?

If you run into any issues:

1. **Check the troubleshooting section** above
2. **Make sure the API is running** (`dotnet run`)
3. **Verify your commands** match the examples exactly
4. **Check your JWT token** is valid and included in requests
5. **Use unique email addresses** for registration

---

**Happy coding! 🚀**