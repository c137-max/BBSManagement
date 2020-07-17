create table users
(
    user_id     int identity
        constraint PK_user
            primary key,
    password    nchar(30)                   not null,
    sex         nchar(4)
        constraint DF_user_sex default N'男' not null,
    nickname    nchar(20)                   not null,
    permissions nchar(15)                   not null
)
go

create table post
(
    post_id      int identity
        constraint PK_post
            primary key,
    user_id      int           not null
        constraint FK_user_post
            references users
            on update cascade on delete cascade,
    post_content nvarchar(max) not null,
    post_title   nchar(127)    not null,
    post_date    datetime      not null
)
go

create table comments
(
    comment_id int identity
        constraint PK_comments
            primary key,
    post_id    int           not null
        constraint FK_Comments_post
            references post
            on update cascade on delete cascade,
    user_id    int           not null
        constraint FK_comments_user
            references users,
    comment    nvarchar(max) not null,
    date       datetime      not null
)
go

create unique index users_nickname_uindex
    on users (nickname)
go


