-- Insert Default Role-Privilege Mappings
INSERT INTO [RolePrivilege] ([role_id], [privilege_id]) VALUES (1, 1);
INSERT INTO [RolePrivilege] ([role_id], [privilege_id]) VALUES (2, 1);
INSERT INTO [RolePrivilege] ([role_id], [privilege_id]) VALUES (3, 1);

-- Insert Default Topics and Keywords
INSERT INTO [Topic] ([name]) VALUES ('Artificial Intelligence');
INSERT INTO [Topic] ([name]) VALUES ('Computer Science');
INSERT INTO [Topic] ([name]) VALUES ('Data Science');
INSERT INTO [Topic] ([name]) VALUES ('Machine Learning');
INSERT INTO [Keyword] ([name]) VALUES ('Deep Learning');
INSERT INTO [Keyword] ([name]) VALUES ('Neural Networks');
INSERT INTO [Keyword] ([name]) VALUES ('Big Data');
INSERT INTO [Keyword] ([name]) VALUES ('Python');
INSERT INTO [Keyword] ([name]) VALUES ('Statistics');

-- Insert Default Resources
INSERT INTO [Resource] ([hyper_link]) VALUES ('https://www.coursera.org/learn/deep-learning');
INSERT INTO [Resource] ([hyper_link]) VALUES ('https://www.edx.org/course/cs50s-introduction-to-computer-science');
INSERT INTO [Resource] ([hyper_link]) VALUES ('https://www.kaggle.com/datasets');
INSERT INTO [Resource] ([hyper_link]) VALUES ('https://www.youtube.com/watch?v=Ilg3gGewQ5U');
INSERT INTO [Resource] ([hyper_link]) VALUES ('https://www.journals.elsevier.com/neural-networks');

-- Insert Default Resource-Topic Mappings
INSERT INTO [ResourceTopic] ([resource_id], [topic_id]) VALUES (1, 1);
INSERT INTO [ResourceTopic] ([resource_id], [topic_id]) VALUES (1, 4);
INSERT INTO [ResourceTopic] ([resource_id], [topic_id]) VALUES (2, 2);
INSERT INTO [ResourceTopic] ([resource_id], [topic_id]) VALUES (3, 2);
INSERT INTO [ResourceTopic] ([resource_id], [topic_id]) VALUES (3, 3);
INSERT INTO [ResourceTopic] ([resource_id], [topic_id]) VALUES (3, 4);
INSERT INTO [ResourceTopic] ([resource_id], [topic_id]) VALUES (4, 1);
INSERT INTO [ResourceTopic] ([resource_id], [topic_id]) VALUES (4, 4);
INSERT INTO [ResourceTopic] ([resource_id], [topic_id]) VALUES (5, 1);
INSERT INTO [ResourceTopic] ([resource_id], [topic_id]) VALUES (5, 2);

-- Insert Default Textbooks
INSERT INTO [Textbook] ([publisher], [resource_id]) VALUES ('MIT Press', 1);
INSERT INTO [Textbook] ([publisher], [resource_id]) VALUES ('Harvard University Press', 2);

-- Insert Default Research Papers
INSERT INTO [ResearchPaper] ([DOI], [citations], [resource_id]) VALUES ('10.1016/j.neunet.2021.02.027', 10, 5);
INSERT INTO [ResearchPaper] ([DOI], [citations], [resource_id]) VALUES ('10.1145/3442188.3445929', 5, 3);

-- Insert Default Community Posts
INSERT INTO [CommunityPost] ([content], [creator_id]) VALUES ('What are some good resources to learn about neural networks?', 3);
INSERT INTO [CommunityPost] ([content], [creator_id]) VALUES ('Best intro to computer science course for beginners?', 2);
INSERT INTO [CommunityPost] ([content], [creator_id]) VALUES ('What are some interesting data science projects to work on?', 1);

-- Insert Default Resource Posts
INSERT INTO [ResourcePost] ([resource_id]) VALUES (1);
INSERT INTO [ResourcePost] ([resource_id]) VALUES (3);
INSERT INTO [ResourcePost] ([resource_id]) VALUES (5);

--Insert Default Comments
INSERT INTO [Comment] ([content], [parent_comment_id]) VALUES ('Thanks for the resource!', NULL);
INSERT INTO [Comment] ([content], [parent_comment_id]) VALUES ('I found this course really helpful for learning about computer science: https://www.edx.org/course/cs50s-introduction-to-computer-science', NULL);
INSERT INTO [Comment] ([content], [parent_comment_id]) VALUES ('I recommend checking out Kaggle for some interesting data science projects: https://www.kaggle.com/datasets', NULL);

-- Insert Default Votes
INSERT INTO [Vote] ([user_id], [community_post_id], [vote_type]) VALUES (1, 1, 1);
INSERT INTO [Vote] ([user_id], [community_post_id], [vote_type]) VALUES (2, 1, 1);
INSERT INTO [Vote] ([user_id], [community_post_id], [vote_type]) VALUES (3, 1, 0);
INSERT INTO [Vote] ([user_id], [community_post_id], [vote_type]) VALUES (1, 2, 0);
INSERT INTO [Vote] ([user_id], [community_post_id], [vote_type]) VALUES (2, 2, 1);
INSERT INTO [Vote] ([user_id], [community_post_id], [vote_type]) VALUES (3, 2, 0);

-- Insert Default Topics
INSERT INTO [Topic] ([name]) VALUES ('Artificial Intelligence');
INSERT INTO [Topic] ([name]) VALUES ('Machine Learning');
INSERT INTO [Topic] ([name]) VALUES ('Computer Vision');

-- Insert Default Keywords
INSERT INTO [Keyword] ([name]) VALUES ('Deep Learning');
INSERT INTO [Keyword] ([name]) VALUES ('Neural Networks');
INSERT INTO [Keyword] ([name]) VALUES ('Image Recognition');
INSERT INTO [Keyword] ([name]) VALUES ('Natural Language Processing');

-- Insert Default TopicKeywords
INSERT INTO [TopicKeyword] ([keyword_id], [topic_id]) VALUES (1, 1);
INSERT INTO [TopicKeyword] ([keyword_id], [topic_id]) VALUES (2, 1);
INSERT INTO [TopicKeyword] ([keyword_id], [topic_id]) VALUES (1, 2);
INSERT INTO [TopicKeyword] ([keyword_id], [topic_id]) VALUES (2, 2);
INSERT INTO [TopicKeyword] ([keyword_id], [topic_id]) VALUES (3, 2);
INSERT INTO [TopicKeyword] ([keyword_id], [topic_id]) VALUES (1, 3);
INSERT INTO [TopicKeyword] ([keyword_id], [topic_id]) VALUES (3, 3);

-- Insert Default Resources
INSERT INTO [Resource] ([hyper_link]) VALUES ('https://arxiv.org/pdf/2105.01227.pdf');
INSERT INTO [Resource] ([hyper_link]) VALUES ('https://www.nature.com/articles/s41586-021-03570-8');
INSERT INTO [Resource] ([hyper_link]) VALUES ('https://www.sciencedirect.com/science/article/pii/S1364815221001823');

-- Insert Default ResearchInterests
INSERT INTO [ResearchInterest] ([user_id], [topic_id]) VALUES (1, 1);
INSERT INTO [ResearchInterest] ([user_id], [topic_id]) VALUES (1, 2);
INSERT INTO [ResearchInterest] ([user_id], [topic_id]) VALUES (2, 1);
INSERT INTO [ResearchInterest] ([user_id], [topic_id]) VALUES (2, 2);
INSERT INTO [ResearchInterest] ([user_id], [topic_id]) VALUES (2, 3);
INSERT INTO [ResearchInterest] ([user_id], [topic_id]) VALUES (3, 3);

-- Insert Default Resource Posts
INSERT INTO [ResourcePost] ([resource_id]) VALUES (1);
INSERT INTO [ResourcePost] ([resource_id]) VALUES (2);

-- Insert Default Textbooks
INSERT INTO [Textbook] ([publisher], [resource_id]) VALUES ('Oxford University Press', 3);
INSERT INTO [Textbook] ([publisher], [resource_id]) VALUES ('Springer', 1);

-- Insert Default Research Papers
INSERT INTO [ResearchPaper] ([DOI], [citations], [resource_id]) VALUES ('10.1126/science.abh4567', 100, 2);
INSERT INTO [ResearchPaper] ([DOI], [citations], [resource_id]) VALUES ('10.1145/3447786.3456263', 50, 1);

-- Insert Default Comments
INSERT INTO [Comment] ([content], [parent_comment_id]) VALUES ('Great post!', NULL);
INSERT INTO [Comment] ([content], [parent_comment_id]) VALUES ('I found this really interesting.', 1);

-- Insert Default Ratings
INSERT INTO [Rating] ([resource_id], [user_id], [value]) VALUES (1, 1, 4);
INSERT INTO [Rating] ([resource_id], [user_id], [value]) VALUES (2, 2, 5);
INSERT INTO [Rating] ([resource_id], [user_id], [value]) VALUES (3, 3, 3);

INSERT INTO [User] (first_name, last_name, username, role, google_scholar_url, email, password) 
  VALUES 
    ('John', 'Doe', 'johndoe', 1, 'https://scholar.google.com.eg/citations?user=wejiWMcAAAAJ&hl=en', 'john.doe@example.com', 'AQAAAAIAAYagAAAAEJaZReAXvzI1Svsu2dDA0Vi9y0UA4IRZj3AkMY5NPMgN5nT8kmEo7ThWduWIJwtzKQ=='),
    ('Jane', 'Doe', 'janedoe', 2, 'https://scholar.google.com/citations?user=abcdefg', 'jane.doe@example.com', 'AQAAAAIAAYagAAAAEJaZReAXvzI1Svsu2dDA0Vi9y0UA4IRZj3AkMY5NPMgN5nT8kmEo7ThWduWIJwtzKQ=='),
    ('Bob', 'Smith', 'bobsmith', 1, 'https://www.linkedin.com/in/elsayed-hemayed-27813a7/?originalSubdomain=eg', 'bob.smith@example.com', 'AQAAAAIAAYagAAAAEJaZReAXvzI1Svsu2dDA0Vi9y0UA4IRZj3AkMY5NPMgN5nT8kmEo7ThWduWIJwtzKQ=='),
    ('Alice', 'Johnson', 'alicej', 2, 'https://scholar.google.com/citations?user=hijklmn', 'alice.johnson@example.com', 'AQAAAAIAAYagAAAAEJaZReAXvzI1Svsu2dDA0Vi9y0UA4IRZj3AkMY5NPMgN5nT8kmEo7ThWduWIJwtzKQ=='),
    ('Michael', 'Lee', 'mikelee', 1, 'https://scholar.google.com/citations?user=CGAQETUAAAAJ&hl=en', 'michael.lee@example.com', 'AQAAAAIAAYagAAAAEJaZReAXvzI1Svsu2dDA0Vi9y0UA4IRZj3AkMY5NPMgN5nT8kmEo7ThWduWIJwtzKQ=='),
	('Emily', 'Wang', 'emilywang', 2, 'https://scholar.google.com/citations?user=opqrstu', 'emily.wang@example.com', 'AQAAAAIAAYagAAAAEJaZReAXvzI1Svsu2dDA0Vi9y0UA4IRZj3AkMY5NPMgN5nT8kmEo7ThWduWIJwtzKQ=='),
    ('David', 'Nguyen', 'davidng', 1, 'https://scholar.google.com/citations?user=vwxyz12', 'david.nguyen@example.com', 'AQAAAAIAAYagAAAAEJaZReAXvzI1Svsu2dDA0Vi9y0UA4IRZj3AkMY5NPMgN5nT8kmEo7ThWduWIJwtzKQ=='),
    ('Sarah', 'Kim', 'sarahkim', 1, 'https://scholar.google.com/citations?user=3456789', 'sarah.kim@example.com', 'AQAAAAIAAYagAAAAEJaZReAXvzI1Svsu2dDA0Vi9y0UA4IRZj3AkMY5NPMgN5nT8kmEo7ThWduWIJwtzKQ=='),
    ('Kevin', 'Chen', 'kevinchen', 2, 'https://scholar.google.com/citations?user=abcdefggg', 'kevin.chen@example.com', 'AQAAAAIAAYagAAAAEJaZReAXvzI1Svsu2dDA0Vi9y0UA4IRZj3AkMY5NPMgN5nT8kmEo7ThWduWIJwtzKQ=='),
    ('Jessica', 'Lee', 'jessicalee', 1, 'https://scholar.google.com/citations?user=hkkijklmn', 'jessica.lee@example.com', 'AQAAAAIAAYagAAAAEJaZReAXvzI1Svsu2dDA0Vi9y0UA4IRZj3AkMY5NPMgN5nT8kmEo7ThWduWIJwtzKQ==')
