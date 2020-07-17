CREATE VIEW View_SearchSet(post_id, post_title, content, date, type) AS
(SELECT post_id, post_title, post_content, post_date, 'POST'
FROM post
UNION 
SELECT post.post_id, post.post_title, comment, date, 'COMMENT'
FROM comments
JOIN post
on post.post_id = comments.post_id
)