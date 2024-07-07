-- Tworzenie schematu NetFilmx
CREATE SCHEMA NetFilmx;


-- Tworzenie tabel
CREATE TABLE NetFilmx.videos(
    id BIGINT NOT NULL IDENTITY(1,1),
    title VARCHAR(255) NOT NULL,
    description VARCHAR(255) NULL,
    price DECIMAL(8, 2) NOT NULL,
    video_url VARCHAR(255) NOT NULL,
    thumbnail_url VARCHAR(255) NULL,
    views BIGINT NULL DEFAULT 0,
    created_at DATETIME NULL DEFAULT GETDATE(),
    updated_at DATETIME NULL DEFAULT GETDATE(),
    PRIMARY KEY (id)
);

CREATE TABLE NetFilmx.tags(
    id BIGINT NOT NULL IDENTITY(1,1),
    name VARCHAR(255) NOT NULL,
    PRIMARY KEY (id)
);

CREATE TABLE NetFilmx.categories(
    id BIGINT NOT NULL IDENTITY(1,1),
    name VARCHAR(50) NOT NULL,
    description VARCHAR(255) NULL,
    PRIMARY KEY (id)
);

CREATE TABLE NetFilmx.series(
    id BIGINT NOT NULL IDENTITY(1,1),
    name VARCHAR(255) NOT NULL,
    price DECIMAL(8, 2) NOT NULL,
    description VARCHAR(255) NULL,
    created_at DATETIME NULL DEFAULT GETDATE(),
    updated_at DATETIME NULL DEFAULT GETDATE(),
    PRIMARY KEY (id)
);

CREATE TABLE NetFilmx.video_tags(
    id BIGINT NOT NULL IDENTITY(1,1),
    tag_id BIGINT NOT NULL,
    video_id BIGINT NOT NULL,
    PRIMARY KEY (id),
    FOREIGN KEY (tag_id) REFERENCES NetFilmx.tags(id),
    FOREIGN KEY (video_id) REFERENCES NetFilmx.videos(id)
);

CREATE TABLE NetFilmx.video_series(
    id BIGINT NOT NULL IDENTITY(1,1),
    playlist_id BIGINT NOT NULL,
    video_id BIGINT NOT NULL,
    PRIMARY KEY (id),
    FOREIGN KEY (playlist_id) REFERENCES NetFilmx.series(id),
    FOREIGN KEY (video_id) REFERENCES NetFilmx.videos(id)
);

CREATE TABLE NetFilmx.video_categories(
    id BIGINT NOT NULL IDENTITY(1,1),
    video_id BIGINT NOT NULL,
    category_id BIGINT NOT NULL,
    PRIMARY KEY (id),
    FOREIGN KEY (video_id) REFERENCES NetFilmx.videos(id),
    FOREIGN KEY (category_id) REFERENCES NetFilmx.categories(id)
);



CREATE TABLE NetFilmx.users(
    id BIGINT NOT NULL IDENTITY(1,1),
    username VARCHAR(50) NOT NULL,
    email VARCHAR(100) NOT NULL,
    password_hash VARCHAR(255) NOT NULL,
    created_at DATETIME NULL DEFAULT GETDATE(),
    updated_at DATETIME NULL DEFAULT GETDATE(),
    PRIMARY KEY (id)
);

CREATE TABLE NetFilmx.comments(
    id BIGINT NOT NULL IDENTITY(1,1),
    video_id BIGINT NOT NULL,
    user_id BIGINT NOT NULL,
    content VARCHAR(255) NOT NULL,
    created_at DATETIME NULL DEFAULT GETDATE(),
    updated_at DATETIME NULL DEFAULT GETDATE(),
    PRIMARY KEY (id),
    FOREIGN KEY (video_id) REFERENCES NetFilmx.videos(id),
    FOREIGN KEY (user_id) REFERENCES NetFilmx.users(id)
);

CREATE TABLE NetFilmx.likes(
    id BIGINT NOT NULL IDENTITY(1,1),
    video_id BIGINT NOT NULL,
    user_id BIGINT NOT NULL,
    created_at DATETIME NULL DEFAULT GETDATE(),
    PRIMARY KEY (id),
    FOREIGN KEY (video_id) REFERENCES NetFilmx.videos(id),
    FOREIGN KEY (user_id) REFERENCES NetFilmx.users(id)
);
