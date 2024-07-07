-- Wstawianie rekordów do tabeli users
INSERT INTO NetFilmx.users (username, email, password_hash)
VALUES 
('john_doe', 'john@example.com', 'hashedpassword123'),
('jane_smith', 'jane@example.com', 'hashedpassword456'),
('alice_wonder', 'alice@example.com', 'hashedpassword789');

-- Wstawianie rekordów do tabeli categories
INSERT INTO NetFilmx.categories (name, description)
VALUES 
('Action', 'Action movies'),
('Comedy', 'Comedy movies'),
('Drama', 'Drama movies');

-- Wstawianie rekordów do tabeli tags
INSERT INTO NetFilmx.tags (name)
VALUES 
('Exciting'),
('Funny'),
('Sad');

-- Wstawianie rekordów do tabeli series
INSERT INTO NetFilmx.series (name, price, description)
VALUES 
('Series 1', 19.99, 'First series'),
('Series 2', 24.99, 'Second series'),
('Series 3', 29.99, 'Third series');

-- Wstawianie rekordów do tabeli videos
INSERT INTO NetFilmx.videos (title, description, price, video_url, thumbnail_url, views)
VALUES 
('Video 1', 'First video description', 4.99, 'https://www.youtube.com/watch?v=5kozt0uDa4c', 'https://i.ytimg.com/vi/5kozt0uDa4c/hqdefault.jpg?sqp=-oaymwEbCKgBEF5IVfKriqkDDggBFQAAiEIYAXABwAEG\u0026rs=AOn4CLCY6jwMkYEkVikHjNGKdocMX6RFJg', 100),
('Video 2', 'Second video description', 5.99, 'https://www.youtube.com/watch?v=Zv11L-ZfrSg', 'https://i.ytimg.com/vi/Zv11L-ZfrSg/hqdefault.jpg?sqp=-oaymwEbCKgBEF5IVfKriqkDDggBFQAAiEIYAXABwAEG\u0026rs=AOn4CLB0dDN2i9Pfn-M4oJsvZWmuRxumUA', 200),
('Video 3', 'Third video description', 6.99, 'https://www.youtube.com/watch?v=oRDRfikj2z8', 'https://i.ytimg.com/vi/oRDRfikj2z8/hqdefault.jpg?sqp=-oaymwEbCKgBEF5IVfKriqkDDggBFQAAiEIYAXABwAEG\u0026rs=AOn4CLBHPvBaFuF4cioIuImk6WumMXetWQ', 300);

-- Wstawianie rekordów do tabeli video_tags
INSERT INTO NetFilmx.video_tags (tag_id, video_id)
VALUES 
((SELECT id FROM NetFilmx.tags WHERE name = 'Exciting'), (SELECT id FROM NetFilmx.videos WHERE title = 'Video 1')),
((SELECT id FROM NetFilmx.tags WHERE name = 'Funny'), (SELECT id FROM NetFilmx.videos WHERE title = 'Video 2')),
((SELECT id FROM NetFilmx.tags WHERE name = 'Sad'), (SELECT id FROM NetFilmx.videos WHERE title = 'Video 3'));

-- Wstawianie rekordów do tabeli video_series
INSERT INTO NetFilmx.video_series (playlist_id, video_id)
VALUES 
((SELECT id FROM NetFilmx.series WHERE name = 'Series 1'), (SELECT id FROM NetFilmx.videos WHERE title = 'Video 1')),
((SELECT id FROM NetFilmx.series WHERE name = 'Series 2'), (SELECT id FROM NetFilmx.videos WHERE title = 'Video 2')),
((SELECT id FROM NetFilmx.series WHERE name = 'Series 3'), (SELECT id FROM NetFilmx.videos WHERE title = 'Video 3'));

-- Wstawianie rekordów do tabeli video_categories
INSERT INTO NetFilmx.video_categories (video_id, category_id)
VALUES 
((SELECT id FROM NetFilmx.videos WHERE title = 'Video 1'), (SELECT id FROM NetFilmx.categories WHERE name = 'Action')),
((SELECT id FROM NetFilmx.videos WHERE title = 'Video 2'), (SELECT id FROM NetFilmx.categories WHERE name = 'Comedy')),
((SELECT id FROM NetFilmx.videos WHERE title = 'Video 3'), (SELECT id FROM NetFilmx.categories WHERE name = 'Drama'));

-- Wstawianie rekordów do tabeli comments
INSERT INTO NetFilmx.comments (video_id, user_id, content)
VALUES 
((SELECT id FROM NetFilmx.videos WHERE title = 'Video 1'), (SELECT id FROM NetFilmx.users WHERE username = 'john_doe'), 'Great video!'),
((SELECT id FROM NetFilmx.videos WHERE title = 'Video 2'), (SELECT id FROM NetFilmx.users WHERE username = 'jane_smith'), 'Very funny!'),
((SELECT id FROM NetFilmx.videos WHERE title = 'Video 3'), (SELECT id FROM NetFilmx.users WHERE username = 'alice_wonder'), 'So sad!');

-- Wstawianie rekordów do tabeli likes
INSERT INTO NetFilmx.likes (video_id, user_id)
VALUES 
((SELECT id FROM NetFilmx.videos WHERE title = 'Video 1'), (SELECT id FROM NetFilmx.users WHERE username = 'john_doe')),
((SELECT id FROM NetFilmx.videos WHERE title = 'Video 2'), (SELECT id FROM NetFilmx.users WHERE username = 'jane_smith')),
((SELECT id FROM NetFilmx.videos WHERE title = 'Video 3'), (SELECT id FROM NetFilmx.users WHERE username = 'alice_wonder'));
