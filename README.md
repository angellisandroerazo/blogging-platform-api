# BloggingPlatformAPI

This project is a basic RESTful API for a personal blogging platform. The API allows performing CRUD (Create, Read, Update, and Delete) operations on blog posts. Additionally, blog posts can be filtered by a search term.

## Getting Started
1. Clone the repository:
   ```bash
   git clone https://github.com/angellisandroerazo/blogging-platform-api.git
   ```
2. Navigate to the project directory:
   ```bash
   cd blogging-platform-api
   ```

3. Open the project in Visual Studio 2022
   
4. Configure the connection string in the appsettings.json file:
   ```json
    "ConnectionStrings": {
    "DefaultConnection": "Data Source=localhost;Initial Catalog=UrlShorteningService;Integrated Security=True;Encrypt=False"
    }
   ```

5. Run the migration script:
   ```bash
   dotnet ef database update
   ```
   
6. Run the application


## Usage
### Create Blog Post

Create a new blog post using the POST method

```json
POST /posts
{
  "title": "My First Blog Post",
  "content": "This is the content of my first blog post.",
  "category": "Technology",
  "tags": ["Tech", "Programming"]
}
```

Response:

```json
{
  "id": "00000000-0000-0000-0000-000000000000",
  "title": "My First Blog Post",
  "content": "This is the content of my first blog post.",
  "category": "Technology",
  "tags": ["Tech", "Programming"],
  "createdAt": "2023-03-01T00:00:00.0000000",
  "updatedAt": "2023-03-01T00:00:00.0000000"
}
```


### Update Blog Post

Update an existing blog post using the PUT method

```json
PUT /posts/00000000-0000-0000-0000-000000000000
{
  "title": "My Updated Blog Post",
  "content": "This is the updated content of my first blog post.",
  "category": "Technology",
  "tags": ["Tech", "Programming"]
}
```

Response:

```json
{
  "id": "00000000-0000-0000-0000-000000000000",
  "title": "My Updated Blog Post",
  "content": "This is the updated content of my first blog post.",
  "category": "Technology",
  "tags": ["Tech", "Programming"],
  "createdAt": "2021-09-01T12:00:00Z",
  "updatedAt": "2021-09-01T12:30:00Z"
}
```

### Delete Blog Post

Delete an existing blog post using the DELETE method

```json
DELETE /posts/00000000-0000-0000-0000-000000000000
```

Response:

```json
{
  "00000000-0000-0000-0000-000000000000"
}
```

### Get Blog Post

Get a single blog post using the GET method

```json
GET /posts/00000000-0000-0000-0000-000000000000
```

Response:

```json
{
  "id": "00000000-0000-0000-0000-000000000000",
  "title": "My Updated Blog Post",
  "content": "This is the updated content of my first blog post.",
  "category": "Technology",
  "tags": ["Tech", "Programming"],
  "createdAt": "2021-09-01T12:00:00Z",
  "updatedAt": "2021-09-01T12:30:00Z"
}
```

### Get All Blog Posts

Get all blog posts using the GET method

```json
GET /posts
```

Response:

```json
[
  {
    "id": "00000000-0000-0000-0000-000000000000",
    "title": "My Updated Blog Post",
    "content": "This is the updated content of my first blog post.",
    "category": "Technology",
    "tags": ["Tech", "Programming"],
    "createdAt": "2021-09-01T12:00:00Z",
    "updatedAt": "2021-09-01T12:30:00Z"
  },
  {
    "id": "00000000-0000-0000-0000-000000000001",
    "title": "My Second Blog Post",
    "content": "This is the content of my second blog post.",
    "category": "Technology",
    "tags": ["Tech", "Programming"],
    "createdAt": "2021-09-01T12:00:00Z",
    "updatedAt": "2021-09-01T12:30:00Z"
  }
]
```


## Problem Statement

This project addresses a task management problem inspired by the challenges outlined in the [Blogging Platform API](https://roadmap.sh/projects/blogging-platform-api).