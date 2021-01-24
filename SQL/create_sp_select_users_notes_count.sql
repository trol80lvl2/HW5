CREATE PROCEDURE sp_select_users_notes_count()
LANGUAGE SQL
AS $$
SELECT users.id, users.first_name, users.last_name, COUNT(notes.id)
FROM users
join notes on notes.user_id = users.id AND notes.is_deleted = false 
GROUP BY(users.id, users.first_name, users.last_name)
$$;