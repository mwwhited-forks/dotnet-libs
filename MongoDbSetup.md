# Mongo Database Setup

## Setting up Initial Collections
This application requires 6 initial collections to be created on the target MongoDatabase
- Modules
- Documents
- Users
- Projects
- Lessons
- Blogs

All Collection Names are defined within the appsettings.json under the "MongoDatabase" Node
- "ModuleCollectionName": "modules",
- "DocumentsCollectionName": "documents",
- "BlogsCollectionName": "blog",
- "LessonsCollectionName": "lesson",
- "ProjectsCollectionName": "project",
- "UsersCollectionName": "users"

## Setting up required indexes
The application requires a text based index to be setup on the following collections so-as basic search
features can be performed.

- Projects (content, title fields should be added to the text index)
- Lessons (content, title fields should be added to the text index)
- Blogs (content, title, and tags fields should be added to the text index)

## Sample Datasets
You can get the application up and running right away by importing the files into the respective
collections from the following project folder

{project root}\Conf\MongoDb\SampleData\