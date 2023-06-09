-- Drop the database
DROP DATABASE IF EXISTS ScholarStack;

-- Create the database
CREATE DATABASE ScholarStack;

-- Use the newly created database
USE ScholarStack;

-- Create Role table
CREATE TABLE [Role] (
    [id] INT IDENTITY(1,1) PRIMARY KEY,
    [role_name] VARCHAR(100)
);

-- Create Privilege table
CREATE TABLE [Privilege] (
    [id] INT IDENTITY(1,1) PRIMARY KEY,
    [privilege_name] VARCHAR(100)
);

-- Create RolePrivilege table
CREATE TABLE [RolePrivilege] (
    [role_id] INT PRIMARY KEY,
    [privilege_id] INT,
    FOREIGN KEY ([role_id]) REFERENCES [Role]([id]),
    FOREIGN KEY ([privilege_id]) REFERENCES [Privilege]([id])
);

-- Create User table
CREATE TABLE [User] (
  [id] INT IDENTITY(1,1) PRIMARY KEY,
  [first_name] NVARCHAR(100) NOT NULL,
  [last_name] NVARCHAR(100) NOT NULL,
  [username] NVARCHAR(100) NOT NULL,
  [role] INT NOT NULL,
  [profile_picture] NVARCHAR(500) ,
  [google_scholar_url] NVARCHAR(200) UNIQUE,
  [email] NVARCHAR(100) UNIQUE NOT NULL,
  [password] NVARCHAR(100) NOT NULL,
  [timestamp] DATETIME NOT NULL DEFAULT GETDATE(),
  [is_banned] BIT NOT NULL DEFAULT 0,
  FOREIGN KEY ([role]) REFERENCES Role (Id)
);

-- Create Community Post table
CREATE TABLE [CommunityPost] (
  [id] INT IDENTITY(1,1) PRIMARY KEY,
  [content] NVARCHAR(MAX) NOT NULL,
  [timestamp] DATETIME NOT NULL DEFAULT GETDATE(),
  [creator_id] INT NOT NULL,
  FOREIGN KEY ([creator_id]) REFERENCES [User]([id]) ON DELETE CASCADE
);

-- Create Resource table
CREATE TABLE [Resource] (
  [id] INT IDENTITY(1,1) PRIMARY KEY,
  [hyper_link] NVARCHAR(500) UNIQUE NOT NULL,
  [timestamp] DATETIME NOT NULL DEFAULT GETDATE()
);

-- Create ResourcePost table
CREATE TABLE [ResourcePost] (
  [id] INT IDENTITY(1,1) PRIMARY KEY,
  [timestamp] DATETIME NOT NULL DEFAULT GETDATE(),
  [resource_id] INT NOT NULL,
  FOREIGN KEY ([resource_id]) REFERENCES [Resource]([id])
);

-- Create Textbook table
CREATE TABLE [Textbook] (
  [id] INT IDENTITY(1,1) PRIMARY KEY,
  [publisher] NVARCHAR(100),
  [resource_id] INT NOT NULL,
  FOREIGN KEY ([resource_id]) REFERENCES [Resource]([id])
);

-- Create ResearchPaper table
CREATE TABLE [ResearchPaper] (
  [id] INT IDENTITY(1,1) PRIMARY KEY,
  [DOI] NVARCHAR(100) UNIQUE NOT NULL,
  [citations] INT,
  [resource_id] INT NOT NULL,
  FOREIGN KEY ([resource_id]) REFERENCES [Resource]([id])
);

-- Create Comment table
CREATE TABLE [Comment] (
  [id] INT IDENTITY(1,1) PRIMARY KEY,
  [content] NVARCHAR(MAX) NOT NULL,
  [timestamp] DATETIME NOT NULL DEFAULT GETDATE(),
  [parent_comment_id] INT,
  FOREIGN KEY ([parent_comment_id]) REFERENCES [Comment]([id])
);

-- Create Rating table
CREATE TABLE [Rating] (
  [resource_id] INT NOT NULL,
  [user_id] INT NOT NULL,
  [value] INT NOT NULL,
  PRIMARY KEY ([resource_id], [user_id]),
  FOREIGN KEY ([user_id]) REFERENCES [User]([id]) ON DELETE CASCADE,
  FOREIGN KEY ([resource_id]) REFERENCES [Resource]([id])
);

-- Create Vote table
CREATE TABLE [Vote] (
  [user_id] INT NOT NULL,
  [community_post_id] INT NOT NULL,
  [vote_type] BIT NOT NULL,
  PRIMARY KEY ([user_id], [community_post_id]),
  FOREIGN KEY ([user_id]) REFERENCES [User]([id]) ON DELETE CASCADE,
  FOREIGN KEY ([community_post_id]) REFERENCES [CommunityPost]([id])
);

-- Create Ticket table
CREATE TABLE [Ticket] (
  [id] INT IDENTITY(1,1) PRIMARY KEY,
  [content] NVARCHAR(MAX) NOT NULL,
  [timestamp] DATETIME NOT NULL DEFAULT GETDATE(),
  [user_id] INT NOT NULL,
  FOREIGN KEY ([user_id]) REFERENCES [User]([id]) ON DELETE CASCADE
);

-- Create CommunityPostComment table
CREATE TABLE [CommunityPostComment] (
  [comment_id] INT NOT NULL,
  [user_id] INT NOT NULL,
  [community_post_id] INT NOT NULL,
  PRIMARY KEY ([comment_id]),
  FOREIGN KEY ([comment_id]) REFERENCES [Comment]([id]),
  FOREIGN KEY ([user_id]) REFERENCES [User]([id]) ON DELETE CASCADE,
  FOREIGN KEY ([community_post_id]) REFERENCES [CommunityPost]([id])
);

-- Create ResourcePostComment table
CREATE TABLE [ResourcePostComment] (
  [comment_id] INT NOT NULL,
  [user_id] INT NOT NULL,
  [resource_post_id] INT NOT NULL,
  PRIMARY KEY ([comment_id]),
  FOREIGN KEY ([comment_id]) REFERENCES [Comment]([id]),
  FOREIGN KEY ([user_id]) REFERENCES [User]([id]) ON DELETE CASCADE,
  FOREIGN KEY ([resource_post_id]) REFERENCES [ResourcePost]([id])
);

-- Create CommunityPostAttachment table
CREATE TABLE [CommunityPostAttachment] (
  [id] INT IDENTITY(1,1) PRIMARY KEY,
  [url] NVARCHAR(500) NOT NULL UNIQUE,
  [community_post_id] INT NOT NULL,
  FOREIGN KEY ([community_post_id]) REFERENCES [CommunityPost]([id]) ON DELETE CASCADE
);

-- Create Topic table
CREATE TABLE [Topic] (
  [id] INT IDENTITY(1,1) PRIMARY KEY,
  [name] NVARCHAR(100) NOT NULL
);

-- Create Keyword table
CREATE TABLE [Keyword] (
  [id] INT IDENTITY(1,1) PRIMARY KEY,
  [name] NVARCHAR(100) NOT NULL
);

-- Create TopicKeyword table
CREATE TABLE [TopicKeyword] (
  [keyword_id] INT NOT NULL,
  [topic_id] INT NOT NULL,
  PRIMARY KEY ([keyword_id], [topic_id]),
  FOREIGN KEY ([keyword_id]) REFERENCES [Keyword]([id]),
  FOREIGN KEY ([topic_id]) REFERENCES [Topic]([id])
);

-- Create ResourceTopic table
CREATE TABLE [ResourceTopic] (
  [resource_id] INT NOT NULL,
  [topic_id] INT NOT NULL,
  PRIMARY KEY ([resource_id], [topic_id]),
  FOREIGN KEY ([resource_id]) REFERENCES [Resource]([id]),
  FOREIGN KEY ([topic_id]) REFERENCES [Topic]([id])
);

-- Create ResearchInterest table
CREATE TABLE [ResearchInterest] (
  [user_id] INT NOT NULL,
  [topic_id] INT NOT NULL,
  PRIMARY KEY ([user_id], [topic_id]),
  FOREIGN KEY ([user_id]) REFERENCES [User]([id]) ON DELETE CASCADE,
  FOREIGN KEY ([topic_id]) REFERENCES [Topic]([id])
);

-- Insert Default User Roles
INSERT INTO [Role] ([role_name]) VALUES ('user');
INSERT INTO [Role] ([role_name]) VALUES ('manager');
INSERT INTO [Role] ([role_name]) VALUES ('admin');

-- Insert Default Users (Password: 111111)
INSERT INTO [User] (first_name, last_name, username, role, google_scholar_url, email, password) 
  VALUES ('Mohammed', 'Ayman', 'muhammed-ayman', 3, 'https://www.google.com', 'ayman@mohz.com', 'AQAAAAIAAYagAAAAEJaZReAXvzI1Svsu2dDA0Vi9y0UA4IRZj3AkMY5NPMgN5nT8kmEo7ThWduWIJwtzKQ==')
  INSERT INTO [User] (first_name, last_name, username, role, google_scholar_url, email, password) 
  VALUES ('Mohmmed', 'Magdy', 'mohzz', 3, 'https://scholar.google.com/citations?hl=en&user=r2USopUAAAAJ&view_op=list_works&sortby=pubdate', 'mohz@mohz.com', 'AQAAAAIAAYagAAAAEJaZReAXvzI1Svsu2dDA0Vi9y0UA4IRZj3AkMY5NPMgN5nT8kmEo7ThWduWIJwtzKQ==')
  INSERT INTO [User] (first_name, last_name, username, role, google_scholar_url, email, password) 
  VALUES ('Ahmed', 'Hesham', 'KingH', 3, 'https://pubmed.ncbi.nlm.nih.gov/37170417/', 'ahmed@h.com', 'AQAAAAIAAYagAAAAEJaZReAXvzI1Svsu2dDA0Vi9y0UA4IRZj3AkMY5NPMgN5nT8kmEo7ThWduWIJwtzKQ==')

-- Insert Default Priviliges
INSERT INTO [Privilege] ([privilege_name]) VALUES ('add_user');
INSERT INTO [Privilege] ([privilege_name]) VALUES ('delete_user');
INSERT INTO [Privilege] ([privilege_name]) VALUES ('update_user');
